using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Tic_Tac_Toe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Attributes
  
        /// <summary>
        /// Runs the core code of the Tic Tac Toe game
        /// </summary>
        private cls_TicTacToe _TicTacToe;

        /// <summary>
        /// A bool used to check if the game has been started or not
        /// </summary>
        private bool _bGameHasStarted;

        /// <summary>
        /// Keeps track of who turn it is
        /// </summary>
        private ePlayerTurn _whosTurn;

        /// <summary>
        /// The possible players for the game
        /// </summary>
        private enum ePlayerTurn
        {
            Player1,
            Player2
        }

        #endregion
        public MainWindow()
        {
            InitializeComponent();
            _TicTacToe = new cls_TicTacToe();

        }

        #region Methods
     
        /// <summary>
        /// Updates corresponding labels content to the current player letter.
        /// Uses methods from _TicTacToe to handle winning moves.
        /// Updates the board using methods from this class
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void labelClick(object sender, MouseButtonEventArgs e)
        {
            var labelClicked = (Label)sender;
            if(_bGameHasStarted)
            {
                if(labelClicked.Content.ToString() == "") 
                {
                    // Checks who turn it is
                    if(_whosTurn == ePlayerTurn.Player1) 
                    {
                        labelClicked.Content = "X";
                        LoadBoard();

                        // Checks to see if there is a winning move
                        if(_TicTacToe.isWinningMove())
                        {
                            HightlightWinningMove();
                            txt_gameState.Text = "Player 1 Wins!";
                            _TicTacToe.Player1Wins++;
                            DisplayScores();
                            _bGameHasStarted = false;
                        }
                        else
                        {
                            // Checks to see if its a tie
                            if (_TicTacToe.isTie())
                            {
                                txt_gameState.Text = "Its a Tie";
                                _TicTacToe.Ties++;
                                DisplayScores();
                                _bGameHasStarted = false;
                            }
                            else
                            {
                                // Updates _whosTurn to Player2
                                txt_gameState.Text = "Player 2 turn";
                                _whosTurn = ePlayerTurn.Player2;
                            }
                        }

                    }
                    else if(_whosTurn == ePlayerTurn.Player2)
                    {
                        labelClicked.Content = "O";
                        LoadBoard();
                        if (_TicTacToe.isWinningMove())
                        {
                            // Checks to see if there is a winning move
                            HightlightWinningMove();
                            txt_gameState.Text = "Player 2 Wins!";
                            _TicTacToe.Player2Wins++;
                            DisplayScores();
                            _bGameHasStarted = false;
                        }
                        else
                        {
                            // Checks to see if its a tie
                            if (_TicTacToe.isTie())
                            {
                                txt_gameState.Text = "Its a Tie";
                                _TicTacToe.Ties++;
                                DisplayScores();
                                _bGameHasStarted = false;
                            }
                            else
                            {
                                // Updates _whosTurn to Player2
                                txt_gameState.Text = "Player 1 turn";
                                _whosTurn = ePlayerTurn.Player1;
                            }

                        }
                    }

                }
            }
        }

        /// <summary>
        /// Updates the _bGameHasStarted, text of txt_gameStat, and _whosTurn.
        /// Then calls other methods to get the board ready for play.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmd_startGame_Click(object sender, RoutedEventArgs e)
        {
            _bGameHasStarted = true;
            txt_gameState.Text = "Player 1 turn";
            _whosTurn = ePlayerTurn.Player1;
            ClearLabels();
            ResetColor();
            LoadBoard();
        }

        /// <summary>
        /// Updates the info in the gbx_gameStats box with updated info
        /// </summary>
        private void DisplayScores()
        {
            lbl_p1Wins.Content = "Player 1 Wins: " + _TicTacToe.Player1Wins.ToString();
            lbl_p2Wins.Content = "Player 2 Wins: " + _TicTacToe.Player2Wins.ToString();
            lbl_ties.Content = "\tTies: " + _TicTacToe.Ties.ToString();
        }

        /// <summary>
        /// Sets the game board labels to empty strings
        /// </summary>
        private void ClearLabels()
        {
            lbl_00.Content = string.Empty;
            lbl_01.Content = string.Empty;
            lbl_02.Content = string.Empty;
            lbl_10.Content = string.Empty;
            lbl_11.Content = string.Empty;
            lbl_12.Content = string.Empty;
            lbl_20.Content = string.Empty;
            lbl_21.Content = string.Empty;
            lbl_22.Content = string.Empty;
        }

        /// <summary>
        ///  Sets the game board labels to white backgrounds
        /// </summary>
        private void ResetColor()
        {
            var label_default = Brushes.White;
            lbl_00.Background = label_default;
            lbl_01.Background = label_default;
            lbl_02.Background = label_default;
            lbl_10.Background = label_default;
            lbl_11.Background = label_default;
            lbl_12.Background = label_default;
            lbl_20.Background = label_default;
            lbl_21.Background = label_default;
            lbl_22.Background = label_default;
        }

        /// <summary>
        /// Checks WinningMoveState from _TicTacToe and updates the background color
        /// of winning labels.
        /// </summary>
        private void HightlightWinningMove()
        {
         
            var WinningColor = Brushes.Lime;
            switch(_TicTacToe.WinningMoveState)
            {
                case cls_TicTacToe.WinningMove.Row1:
                    lbl_00.Background = WinningColor;
                    lbl_01.Background = WinningColor;
                    lbl_02.Background = WinningColor;
                    break;

                case cls_TicTacToe.WinningMove.Row2:
                    lbl_10.Background = WinningColor;
                    lbl_11.Background = WinningColor;
                    lbl_12.Background = WinningColor;
                    break;

                case cls_TicTacToe.WinningMove.Row3:
                    lbl_20.Background = WinningColor;
                    lbl_21.Background = WinningColor;
                    lbl_22.Background = WinningColor;
                    break;

                case cls_TicTacToe.WinningMove.Col1:
                    lbl_00.Background = WinningColor;
                    lbl_10.Background = WinningColor;
                    lbl_20.Background = WinningColor;
                    break;

                case cls_TicTacToe.WinningMove.Col2:
                    lbl_01.Background = WinningColor;
                    lbl_11.Background = WinningColor;
                    lbl_21.Background = WinningColor;
                    break;

                case cls_TicTacToe.WinningMove.Col3:
                    lbl_02.Background = WinningColor;
                    lbl_12.Background = WinningColor;
                    lbl_22.Background = WinningColor;
                    break;

                case cls_TicTacToe.WinningMove.Diag1:
                    lbl_00.Background = WinningColor;
                    lbl_11.Background = WinningColor;
                    lbl_22.Background = WinningColor;
                    break;

                case cls_TicTacToe.WinningMove.Diag2:
                    lbl_02.Background = WinningColor;
                    lbl_11.Background = WinningColor;
                    lbl_20.Background = WinningColor;
                    break;
            }
        }

        /// <summary>
        /// Updates the _TicTacToe.Board array with corresponding label contents. 
        /// </summary>
        private void LoadBoard()
        {
            _TicTacToe.Board[0,0] = lbl_00.Content.ToString();
            _TicTacToe.Board[0,1] = lbl_01.Content.ToString();
            _TicTacToe.Board[0,2] = lbl_02.Content.ToString();
            _TicTacToe.Board[1,0] = lbl_10.Content.ToString();
            _TicTacToe.Board[1,1] = lbl_11.Content.ToString();
            _TicTacToe.Board[1,2] = lbl_12.Content.ToString();
            _TicTacToe.Board[2,0] = lbl_20.Content.ToString();
            _TicTacToe.Board[2,1] = lbl_21.Content.ToString();
            _TicTacToe.Board[2,2] = lbl_22.Content.ToString();

        }
        #endregion
    }
}
