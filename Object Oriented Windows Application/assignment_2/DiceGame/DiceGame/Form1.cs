using System.Reflection.Metadata.Ecma335;
using System.Security.AccessControl;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace DiceGame
{
    public partial class Form1 : Form
    {

        #region Private Variables

        /// <summary>
        /// The number of times 1 has been rolled
        /// </summary>
        private int _one = 0;
        /// <summary>
        /// The number of times 2 has been rolled
        /// </summary>
        private int _two = 0;
        /// <summary>
        /// The number of times 3 has been rolled
        /// </summary>
        private int _three = 0;
        /// <summary>
        /// The number of times 4 has been rolled
        /// </summary>
        private int _four = 0;
        /// <summary>
        /// The number of times 5 has been rolled
        /// </summary>
        private int _five = 0;
        /// <summary>
        /// The number of times 6 has been rolled
        /// </summary>
        private int _six = 0;


        /// <summary>
        /// The number of times the user has chose the number 1
        /// </summary>
        private int _oneGussed = 0;
        /// <summary>
        /// The number of times the user has chose the number 2
        /// </summary>
        private int _twoGussed = 0;
        /// <summary>
        /// The number of times the user has chose the number 3
        /// </summary>
        private int _threeGussed = 0;
        /// <summary>
        /// The number of times the user has chose the number 4
        /// </summary>
        private int _fourGussed = 0;
        /// <summary>
        /// The number of times the user has chose the number 5
        /// </summary>
        private int _fiveGussed = 0;
        /// <summary>
        /// The number of times the user has chose the number 6
        /// </summary>
        private int _sixGussed = 0;

        /// <summary>
        /// The number times the user has played
        /// </summary>
        private int _numOfPlayed = 0;
        /// <summary>
        ///The number of times the user has won
        /// </summary>
        private int _numOfWins = 0;
        /// <summary>
        /// The number of times the user had lost
        /// </summary>
        private int _numOfLost = 0;
        #endregion


        public Form1()
        {
            InitializeComponent();
            gameState(states.restart);
            pb_dieImage.Image = Image.FromFile("die1.gif");
        }

        /// <summary>
        /// The different states the game can be
        /// </summary>
        private enum states
        {
            /// <summary>
            /// Lets the gameState method now to reset the game state starting state
            /// </summary>
            restart,
            /// <summary>
            /// Lets the gameState method know to update all the information for the game
            /// </summary>
            update
        }

        #region methods

        /// <summary>
        /// Takes in a enum state and formats and updates the text information in the form.  If the states is restart
        /// it sets all private variables to zero.
        /// </summary>
        /// <param name="current">restart = all variables back to zero or updates = updates variables and updates
        /// the text </param>
        private void gameState(states current)
        {
            if (current == states.restart)
            {
                // Sets all private variables to zero
                _one = 0;
                _two = 0;
                _three = 0;
                _four = 0;
                _five = 0;
                _six = 0;
                _oneGussed = 0;
                _twoGussed = 0;
                _threeGussed = 0;
                _fourGussed = 0;
                _fiveGussed = 0;
                _sixGussed = 0;
                _numOfPlayed = 0;
                _numOfWins = 0;
                _numOfLost = 0;

                // Updates and formats the rtb_gameStats text
                rtb_gameStats.Text = "Face".PadRight(25) + "Frequency".PadRight(25) + "Percent".PadRight(25)
                                     + "Time Guessed\n" +
                                     "1".PadRight(35) + _one + "".PadRight(26) + "0.00%".PadRight(35)
                                     + _oneGussed + "\n" +
                                     "2".PadRight(35) + _two + "".PadRight(26) + "0.00%".PadRight(35)
                                     + _twoGussed + "\n" +
                                     "3".PadRight(35) + _three + "".PadRight(26) + "0.00%".PadRight(35)
                                     + _threeGussed + "\n" +
                                     "4".PadRight(35) + _four + "".PadRight(26) + "0.00%".PadRight(35)
                                     + _fourGussed + "\n" +
                                     "5".PadRight(35) + _five + "".PadRight(26) + "0.00%".PadRight(35)
                                     + _fiveGussed + "\n" +
                                     "6".PadRight(35) + _six + "".PadRight(26) + "0.00%".PadRight(35) + _sixGussed;

                // Updates the labels counts
                lbl_numPlayed.Text = _numOfPlayed.ToString();
                lbl_numLost.Text = _numOfLost.ToString();
                lbl_numWon.Text = _numOfWins.ToString();


            }
            else if (current == states.update)
            {
                // Gets the frequency for the private die variables and format in n.nn%
                string onePercent = String.Format("{0:P2}", ((float)_one / (float)_numOfPlayed));
                string twoPercent = String.Format("{0:P2}", ((float)_two / (float)_numOfPlayed));
                string threePercent = String.Format("{0:P2}", ((float)_three / (float)_numOfPlayed));
                string fourPercent = String.Format("{0:P2}", ((float)_four / (float)_numOfPlayed));
                string fivePercent = String.Format("{0:P2}", ((float)_five / (float)_numOfPlayed));
                string sixPercent = String.Format("{0:P2}", ((float)_six / (float)_numOfPlayed));

                // Updates and formats the rtb_gameStats text
                rtb_gameStats.Text = "Face".PadRight(25) + "Frequency".PadRight(25) + "Percent".PadRight(25)
                                     + "Time Guessed\n" +
                                     "1".PadRight(35) + _one + "".PadRight(26) + onePercent.PadRight(35)
                                     + _oneGussed + "\n" +
                                     "2".PadRight(35) + _two + "".PadRight(26) + twoPercent.PadRight(35)
                                     + _twoGussed + "\n" +
                                     "3".PadRight(35) + _three + "".PadRight(26) + threePercent.PadRight(35)
                                     + _threeGussed + "\n" +
                                     "4".PadRight(35) + _four + "".PadRight(26) + fourPercent.PadRight(35)
                                     + _fourGussed + "\n" +
                                     "5".PadRight(35) + _five + "".PadRight(26) + fivePercent.PadRight(35)
                                     + _fiveGussed + "\n" +
                                     "6".PadRight(35) + _six + "".PadRight(26) + sixPercent.PadRight(35) + _sixGussed;

                // Updates the labels counts
                lbl_numPlayed.Text = _numOfPlayed.ToString();
                lbl_numLost.Text = _numOfLost.ToString();
                lbl_numWon.Text = _numOfWins.ToString();
            }
        }

        /// <summary>
        /// Checks to see if the string passed in is a number then it checks if its between 1-6
        /// </summary>
        /// <param name="guess">A string of the number the user wants guess</param>
        /// <returns>True if the guess is a number between 1-6 and false if its anything else</returns>
        private bool guessCheck(string guess)
        {
            if (int.TryParse(guess, out int result)) // Checks to see string is a number
            {
                // checks to see if the number between 1-6
                if (result > 0 && result < 7)
                {
                    return true;
                }
                return false;
            }
            return false;
        }

        /// <summary>
        /// Rolls a six sided die and updates the die image accordingly.  It also returns the last random number.
        /// </summary>
        /// <returns>int: The last random number</returns>
        private int rollDice()
        {
            int dieNum = 0;
            // Rolls the die 10 time
            for (int i = 0; i < 10; i++)
            {
                // Creates a Random object for number 1-6
                Random die = new Random();
                dieNum = die.Next(1, 7);

                // Updates the die image with random number from die and then buts thread 100 millisecond
                string img = "die" + dieNum.ToString() + ".gif";
                pb_dieImage.Image = Image.FromFile(img);
                pb_dieImage.Refresh();
                Thread.Sleep(100);
            }

            return dieNum;
        }

        /// <summary>
        /// Updates lbl_invalidGuess to an empty string when the user enter something
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txt_guess_TextChanged(object sender, EventArgs e)
        {
            lbl_invalidGuess.Text = "";
        }

        /// <summary>
        /// Converts the user guess into an int checks to see if they got answer right or wrong and update private
        /// variables accordingly.  If the guess is not valid it updates lbl_invalidGuess and let them know
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmd_Roll_Click(object sender, EventArgs e)
        {
            // saves the user guess into the guess string
            string guess = txt_guess.Text;

            // int to store the user guess if its valid
            int validGuess;

            if (guessCheck(guess)) // Calls guess Check on the user guess to make sure its a valid number
            {
                // Parses user guess and stores in validGuess
                validGuess = int.Parse(guess);

                // Gets the number that the die landed on
                int dieNum = rollDice();

                // Updates private variables depending number the user  guessed and die landed on.
                _numOfPlayed++;
                switch (dieNum)
                {
                    case 1:
                        _one++;
                        break;
                    case 2:
                        _two++;
                        break;
                    case 3:
                        _three++;
                        break;
                    case 4:
                        _four++;
                        break;
                    case 5:
                        _five++;
                        break;
                    case 6:
                        _six++;
                        break;
                }

                switch (validGuess)
                {
                    case 1:
                        _oneGussed++;
                        break;
                    case 2:
                        _twoGussed++;
                        break;
                    case 3:
                        _threeGussed++;
                        break;
                    case 4:
                        _fourGussed++;
                        break;
                    case 5:
                        _fiveGussed++;
                        break;
                    case 6:
                        _sixGussed++;
                        break;
                }

                // If the user was right or not updates corresponding private variable
                if (validGuess == dieNum)
                {
                    _numOfWins++;
                }
                else
                {
                    _numOfLost++;
                }

                // Calls gameState to updates game stats
                gameState(states.update);
            }
            else // if guess is not valid
            {
                // updates lbl_invalidGuess to let the user know the thing they enter is not valid
                lbl_invalidGuess.Text = "Invalid guess, please enter\na number between 1 and 6";
            }

        }

        /// <summary>
        /// Reset the game to the starting state.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmd_reset_Click(object sender, EventArgs e)
        {
            gameState(states.restart);
        }
    }
    #endregion
}