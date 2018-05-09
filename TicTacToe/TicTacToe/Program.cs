using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public enum State { Undecided, X, O };

    class Program
    {
        static void Main(string[] args)
        {
            Board board = new Board();
            WinChecker winChecker = new WinChecker();
            Renderer renderer = new Renderer();
            Player player1 = new Player();
            Player player2 = new Player();

            while(!winChecker.IsDraw(board) && winChecker.Check(board) == State.Undecided)
            {
                renderer.Render(board);
                Position nextMove;
                if (board.NextTurn == State.X)
                    nextMove = player1.GetPosition(board);
                else
                    nextMove = player2.GetPosition(board);
                if (!board.SetState(nextMove, board.NextTurn))
                    Console.WriteLine("That is not a legal move.");
            }

            renderer.Render(board);
            renderer.RenderResults(winChecker.Check(board));

            Console.ReadKey();
        }
    }
}

// Requirements:
// Console based (no GUI)
// Two players take turns using same keyboard
// Player designates which square they want to play using keyboard
    // Possible approach: number the squares in board with digits 1-9
    // Ex: If player enters 7, top left corner of board is chosen
// Game should ensure only legal moves are made
    // Cannot play a square that already has something
    // Wrong player cannot take a turn
    // If player makes illegal move, board should remain unchanged
// Game should be able to detect when a player wins or when a draw happens (board is full)
// When game is over, outcome is displayed to user
// Only a single round of play is required