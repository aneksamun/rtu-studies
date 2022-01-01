using System;
using System.Collections.Generic;
using System.Text;

namespace NougthAndCroses.GameAbstraction {

    public class GameBehavior {
        /// <summary>
        /// Determinates which player'll go first.
        /// </summary>
        /// <remarks>
        /// Odd number: first player,
        /// Even number: second player.
        /// </remarks>
        public static bool DeterminePlayerType() {
            Random random = new Random();
            int number = random.Next(1, 20);

            return ((number & 1) == 0);
        }

        /// <summary>
        /// Determinates whether player wins.
        /// </summary>
        /// <returns></returns>
        public static bool PlayerWins(char[,] board, Player player) {
            bool wins = true;

            // Checking rows columns sequencly.
            //---
            //---
            //---
            for (int i = 0; i < board.GetLength(0); i++) {
                for (int j = 0; j < board.GetLength(1); j++)
                    if (board[i, j] != player.Remark) {
                        wins = false;
                        break;
                    }

                if (wins)
                    return true;
                else
                    wins = true;
            }

            // Checking rows and columns verticaly.
            // |||
            // |||
            // |||
            for (int j = 0; j < board.GetLength(1); j++) {
                for (int i = 0; i < board.GetLength(0); i++)
                    if (board[i, j] != player.Remark) {
                        wins = false;
                        break;
                    }

                if (wins)
                    return true;
                else
                    wins = true;
            }

            // Checking left side diagonale.
            // \||
            // |\|
            // ||\
            for (int i = 0, j = 0; i < board.GetLength(0) && j < board.GetLength(1); i++, j++)
                if (board[i, j] != player.Remark) {
                    wins = false;
                    break;
                }

            if (wins)
                return true;

            wins = true;
            // Checking right side diagonale.
            // ||/
            // |/|
            // /||
            for (int i = 0, j = board.GetLength(1) - 1; i < board.GetLength(0) && j > -1; i++, j--)
                if (board[i, j] != player.Remark) {
                    wins = false;
                    break;
                }

            return wins;
        }

        /// <summary>
        /// Indicates whether players plays draw.
        /// </summary>
        /// <returns></returns>
        public static bool IsDraw(char[,] board) {
            for (int i = 0; i < board.GetLength(0); i++)
                for (int j = 0; j < board.GetLength(1); j++)
                    if (board[i, j] == '\0') {
                        return false;
                    }

            return true;
        }
    }
}
