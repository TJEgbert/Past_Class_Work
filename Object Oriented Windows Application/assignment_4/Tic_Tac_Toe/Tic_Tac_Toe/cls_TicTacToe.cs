using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tic_Tac_Toe
{
    public class cls_TicTacToe
    {
        #region Attributes
        /// <summary>
        /// Stores the array for the tic tac to board
        /// </summary>
        private string[,] _saBoard;
        /// <summary>
        /// The number of times player one wins
        /// </summary>
        private int _player1Wins;
        /// <summary>
        /// The number of times player two wins
        /// </summary>
        private int _player2Wins;

        /// <summary>
        /// The number of times player one and two ties
        /// </summary>
        private int _ties;
        /// <summary>
        /// How the winning move was made
        /// </summary>
        private WinningMove eWinningMove;

        /// <summary>
        /// Thie different states of winning the game
        /// </summary>
        public enum WinningMove
        {
            Row1,
            Row2,
            Row3,
            Col1,
            Col2,
            Col3,
            Diag1,
            Diag2
        }

        #endregion

        #region Methods
        /// <summary>
        /// The number of times player one has won
        /// </summary>
        public int Player1Wins
        {
            get { return _player1Wins; }
            set { _player1Wins = value; }
        }

        /// <summary>
        /// The number of times player two has won
        /// </summary>
        public int Player2Wins
        {
            get { return _player2Wins; }
            set { _player2Wins = value; }
        }

        /// <summary>
        /// The number of time player one and two have tied
        /// </summary>
        public int Ties
        {
            get { return _ties; }
            set { _ties = value; }
        }
           
        /// <summary>
        /// The 2D array used for the tic tac toe game
        /// </summary>
        public string[,] Board
        {
            get { return _saBoard; }
            set { _saBoard = value; }
        }

        /// <summary>
        /// The current way move have won the game
        /// </summary>
        public WinningMove WinningMoveState
        {
            get { return eWinningMove; }
            set { eWinningMove = value; }
        }

        /// <summary>
        /// The non default constructor for TicTacToe class
        /// </summary>
        /// <param name="array">A 2D array passed in for the tic tak toe game</param>
        /// <param name="currentMark"></param>
        public cls_TicTacToe() 
        {
            _saBoard = new string[3,3];
        }

        /// <summary>
        /// Checks to see if the current play caused a win
        /// </summary>
        /// <returns>True if there is a win false if not</returns>
        public bool isWinningMove()
        {
            if(isDiagonalWin() || isHorizontalWin() ||  isVerticalWin())
            {
                return true;
            }
            else if(isTie())
            {
                return false;
            }
            return false;
        }

        /// <summary>
        /// Checks to see if all spaces have been played on
        /// </summary>
        /// <returns>Return true if they have and false if not</returns>
        public bool isTie()
        {
            int totalPlays = 0;

            for (int row = 0; row < _saBoard.GetLength(0); row++)
            {

                for (int col = 0; col < _saBoard.GetLength(1); col++)
                {
                    if (_saBoard[row, col] == "X" || _saBoard[row, col] == "O")
                    {
                        totalPlays++;
                    }
                    
                }
            }

            if(totalPlays == (_saBoard.GetLength(0)* _saBoard.GetLength(1)))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Checks the spots that would form a diagonal win 
        /// </summary>
        /// <returns>True if either player has a diagonal and updates eWinningMove accordingly
        ///          if not returns false</returns>
        private bool isDiagonalWin()
        {
           
            if (_saBoard[1,1] == "X")
            {
                if (_saBoard[0, 0] == "X")
                {
                    if (_saBoard[2, 2] == "X")
                    {
                        eWinningMove = WinningMove.Diag1;
                        return true;
                    }
                }

                if (_saBoard[0, 2] == "X")
                {
                    if (_saBoard[2, 0] == "X")
                    {
                        eWinningMove = WinningMove.Diag2;
                        return true;
                    }
                }
            }

            if(_saBoard[1, 1] == "O")
            {
                if (_saBoard[0, 0] == "O")
                {
                    if (_saBoard[2, 2] == "O")
                    {
                        eWinningMove = WinningMove.Diag1;
                        return true;
                    }
                }

                if (_saBoard[0, 2] == "O")
                {
                    if (_saBoard[2, 0] == "O")
                    {
                        eWinningMove = WinningMove.Diag2;
                        return true;
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// Checks to see if there is a wins in the Horizontal
        /// </summary>
        /// <returns>True if there is and updates eWinningMove accordingly
        ///          if not it reutrns false</returns>
        private bool isHorizontalWin()
        {
            
            for (int row = 0; row < _saBoard.GetLength(0); row++) 
            {
                int XCount = 0;
                int OCount = 0;

                for(int col = 0; col < _saBoard.GetLength(1); col++) 
                {
                    if (_saBoard[row,col] == "X")
                    {
                        XCount++; 
                        if (XCount == 3) 
                        {
                            switch (row)
                            {
                                case 0: 
                                    eWinningMove = WinningMove.Row1; 
                                    break;
                                case 1:
                                    eWinningMove = WinningMove.Row2;
                                    break;
                                case 2:
                                    eWinningMove= WinningMove.Row3; 
                                    break;
                            }

                            return true;
                        }
                    }

                    if (_saBoard[row, col] == "O")
                    {
                        OCount++;
                        if (OCount == 3)
                        {
                            switch (row)
                            {
                                case 0:
                                    eWinningMove = WinningMove.Row1;
                                    break;
                                case 1:
                                    eWinningMove = WinningMove.Row2;
                                    break;
                                case 2:
                                    eWinningMove = WinningMove.Row3;
                                    break;
                            }
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// Checks to see there is a win in the vertical
        /// </summary>
        /// <returns>If so it returns true and updates eWinningMove accordingly 
        ///          if not it returns false</returns>
        private bool isVerticalWin() 
        {
            for (int col = 0; col < _saBoard.GetLength(0); col++)
            {
                int XCount = 0;
                int OCount = 0;

                for (int row = 0; row < _saBoard.GetLength(1); row++)
                {
                    if (_saBoard[row, col] == "X")
                    {
                        XCount++;
                        if (XCount == 3)
                        {
                            switch (col)
                            {
                                case 0:
                                    eWinningMove = WinningMove.Col1;
                                    break;
                                case 1:
                                    eWinningMove = WinningMove.Col2;
                                    break;
                                case 2:
                                    eWinningMove = WinningMove.Col3;
                                    break;
                            }

                            return true;
                        }
                    }
                    
                    if (_saBoard[row, col] == "O")
                    {
                        OCount++;
                        if (OCount == 3)
                        {
                            switch (col)
                            {
                                case 0:
                                    eWinningMove = WinningMove.Col1;
                                    break;
                                case 1:
                                    eWinningMove = WinningMove.Col2;
                                    break;
                                case 2:
                                    eWinningMove = WinningMove.Col3;
                                    break;
                            }
                            return true;
                        }
                    }
                }
            }
            return false;
        }
        #endregion
    }
}
