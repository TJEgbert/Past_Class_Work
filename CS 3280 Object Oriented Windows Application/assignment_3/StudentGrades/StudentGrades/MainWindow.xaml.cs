using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading;
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

namespace StudentGrades
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Variables

        /// <summary>
        /// This number of students the the user wants to enter grades in for
        /// </summary>
        private int _numStudents;

        /// <summary>
        /// The number of assignments the user wants to enter for the students
        /// </summary>
        private int _numAssignments;

        /// <summary>
        /// The index to keep track where the nameArray is at
        /// </summary>
        private int _nameArrayIndex = 0;


        /// <summary>
        /// A string array to hold the students names 
        /// </summary>
        private string[] _studentNameArray;

        /// <summary>
        /// A 2D int array to associates the students and the grades 
        /// </summary>
        private int[,] _gradesArray;


        /// <summary>
        /// A boolean to check if whether or not the students counts have been entered
        /// </summary>
        private bool _studentEntered = false;


        /// <summary>
        /// A boolean to check if whether or not the assignment counts have been entered
        /// </summary>
        private bool _assignmentsEntered = false;

        #endregion

        #region MyMethods

        /// <summary>
        /// Checks to see what was passed in was a number and if is between 1 and 10
        /// </summary>
        /// <param name="str"></param>
        private void numOfStudentsCheck(string str)
        {
            if (int.TryParse(str, out var num))
            {
                if (num <= 10 && num > 0)
                {
                    _numStudents = num;
                    _studentEntered = true;
                    lbl_numStudentError.Content = "";
                }
                else
                {
                    lbl_numStudentError.Content = "Enter a number from 1-10";
                }
            }
            else
            {
                lbl_numStudentError.Content = "Enter a number from 1-10";
            }
        }

        /// <summary>
        /// Checks to see what was passed in was a number and if its between 1 and 99
        /// </summary>
        /// <param name="str">The string the user wants to check</param>
        private void numOfAssignmentsCheck(string str)
        {
            if (int.TryParse(str, out var num))
            {
                if (num <= 99 && num > 0)
                {
                    _numAssignments = num;
                    _assignmentsEntered = true;
                    lbl_assignmentError.Content = "";
                    lbl_assignNum.Content = "Enter Assignment Number(1-" + _numAssignments + "):";
                }
                else
                {
                    lbl_assignmentError.Content = "Enter a number from 1-99";
                }
            }
            else
            {
                lbl_assignmentError.Content = "Enter a number from 1-99";
            }
        }

        /// <summary>
        /// Checks to see if the counts information as been entered into the program and show error if not.
        /// </summary>
        /// <returns>True: if counts have been entered False: if counts have not been entered</returns>
        private bool countsDone()
        {
            if (_assignmentsEntered && _studentEntered)
            {
                lbl_numStudentError.Content = "";
                return true;
            }
            lbl_numStudentError.Foreground = Brushes.Red;
            lbl_numStudentError.Content = "Please enter in counts";
            return false;
        }

        /// <summary>
        /// Checks to see if the what the user entered is a number and if it falls with in the ranges.  If not shows error labels accordingly.
        /// </summary>
        /// <param name="assignStr">The string to check if it in the range for the assignments</param>
        /// <param name="scoreStr">The string to check if its in the range for scores</param>
        private void saveScoreChecks(string assignStr, string scoreStr)
        {
            bool anPassed = false;
            bool snPassed = false;

            // Checking to see if assignStr is a number and if its within the range 1 and _numAssignments 
            if (int.TryParse(assignStr, out var assignNum))
            {
                if (assignNum <= _numAssignments && assignNum > 0)
                {
                    anPassed = true;
                    lbl_assigmentNumError.Content = "";
                }
                else
                {
                    lbl_assigmentNumError.Content = "Enter a number from (1-" + _numAssignments + ")";
                }

            }
            else
            {
                lbl_assigmentNumError.Content = "Enter a number from (1-" + _numAssignments + ")";
            }

            // Checking to see if scoreStr is a number and if its within the range 0 and 100 
            if (int.TryParse(scoreStr, out var scoreNum))
            {
                if (scoreNum <= 100 && scoreNum >= 0)
                {
                    snPassed = true;
                    lbl_assignmentScoreError.Content = "";
                }
                else
                {
                    lbl_assignmentScoreError.Content = "Enter a score between 0-100";
                }
            }
            else
            {
                lbl_assignmentScoreError.Content = "Enter a score between 0-100";
            }

            if (anPassed && snPassed)
            {
                _gradesArray[_nameArrayIndex, (assignNum - 1)] = scoreNum;
                txt_assignNum.Text = "";
                txt_assignScore.Text = "";
            }

        }



        #endregion

        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Calls the methods needed to check counts are checked.  Then it sets up the _studentNameArray and _gradesArray and feels them with dummy data.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmd_submitCounts_Click(object sender, RoutedEventArgs e)
        {
            // Checks what the user entered is correct
            numOfStudentsCheck(txt_numStudents.Text);
            numOfAssignmentsCheck(txt_numAssignments.Text);

            if (countsDone())
            {
                // Creates the arrays that is going to be used
                _studentNameArray = new string[_numStudents];
                _gradesArray = new int[_numStudents, _numAssignments];
                lbl_numStudentError.Foreground = Brushes.Green;
                lbl_numStudentError.Content = "Counts Received";

                for (int i = 0; i < _studentNameArray.Length; i++)
                {
                    _studentNameArray[i] = "Student #"+(1+i);
                }

                for (int row = 0; row < _gradesArray.GetLength(0); row++)
                {
                    for (int column = 0; column < _gradesArray.GetLength(1); column++)
                    {
                        _gradesArray[row, column] = 0;
                    }
                }
            }

        }

        /// <summary>
        /// Save the name the user entered in the corresponding index in _studentNameArray
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmd_saveName_Click(object sender, RoutedEventArgs e)
        {
            if (countsDone())
            {
                _studentNameArray[_nameArrayIndex] = txt_studentName.Text;
            }
        }

        /// <summary>
        /// Sets the _nameArrayIndex = 0 and displays corresponding name in _studentName Array
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmd_firstStd_Click(object sender, RoutedEventArgs e)
        {
            if (countsDone())
            {
                _nameArrayIndex = 0;
                txt_studentName.Text = _studentNameArray[_nameArrayIndex];
                lbl_studentName.Content = "Student #1:";
            }
        }


        /// <summary>
        ///  Minus _nameArrayIndex by one and displays corresponding name in _studentName Array
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmd_prevStd_Click(object sender, RoutedEventArgs e)
        {
            if (countsDone())
            {
                if (_nameArrayIndex > 0)
                {
                    _nameArrayIndex--;
                    txt_studentName.Text = _studentNameArray[_nameArrayIndex];
                    lbl_studentName.Content = "Student #" + (_nameArrayIndex + 1) + ":";
                }
            }
        }

        /// <summary>
        ///  Plus _nameArrayIndex by one and displays corresponding name in _studentName Array
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmd_nextStd_Click(object sender, RoutedEventArgs e)
        {
            if (countsDone())
            {
                if (_nameArrayIndex < (_studentNameArray.Length - 1))
                {
                    _nameArrayIndex++;
                    txt_studentName.Text = _studentNameArray[_nameArrayIndex];
                    lbl_studentName.Content = "Student #" + (_nameArrayIndex + 1) + ":";
                }
            }
  
        }
        /// <summary>
        /// Sets the _nameArrayIndex = _studentNameArray.Length -1 and displays corresponding name in _studentName Array
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmd_lastStd_Click(object sender, RoutedEventArgs e)
        {
            if (countsDone())
            {
                _nameArrayIndex = (_studentNameArray.Length - 1);
                txt_studentName.Text = _studentNameArray[_nameArrayIndex];
                lbl_studentName.Content = "Student #" + (_studentNameArray.Length) + ":";
            }
        }

        /// <summary>
        /// Calls saveScoreChecks to verify and update corresponding information from txt_assignNum.Text and txt_assignScore.Text
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmd_saveScore_Click(object sender, RoutedEventArgs e)
        {
            if (countsDone())
            {
                saveScoreChecks(txt_assignNum.Text, txt_assignScore.Text);
            }
        }

        /// <summary>
        /// Updates the txt_Student.Text with the data from _studentNameArray and _gradesArray
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmd_displayScore_Click(object sender, RoutedEventArgs e)
        {
            if (countsDone())
            {
                string assignmentNumstr = "";
                
                // Stores the number of assignment in assignmentNumstr in for mat #n tab and it repeats for the whole array
                for (int i = 0; i < _numAssignments; i++)
                {
                    assignmentNumstr += "#" + (i + 1) + "\t";
                }

                // Setting up the header for txt_Student
                txt_studentInfo.Text = "Student\t \t" + assignmentNumstr + "AVG\t" + "Grade \n";

                // Loops through the _studentNameArray to to and storing it into studentInfo
                for (int row = 0; row < _numStudents; row++)
                {
                    int sum = 0;
                    float avg = 0;
                    string studentInfo = "";

                    studentInfo = _studentNameArray[row].ToString() + "\t \t";

                    // Loops through _gradesArray getting the score for the assignments and saving them into
                    // StudentInfo
                    for (int column = 0; column < _gradesArray.GetLength(1); column++)
                    {
                        sum += _gradesArray[row, column];
                        studentInfo += _gradesArray[row, column].ToString() + "\t";
                    }

                    // Calculting the average and formatting it to one decimal place
                    avg = (float)sum / (float)_numAssignments;
                    string avgstr = String.Format("{0:.0}", avg);

                    // Adds the average to StudentInfo
                    studentInfo += avgstr + "\t";

                    // Checks to see what letter the grade the average would receive and add its to studentInfo and starts a new line 
                    if (avg >= 93)
                    {
                        studentInfo += "A\n";
                    }
                    else if (avg < 93 && avg >= 90)
                    {
                        studentInfo += "A-\n";
                    }
                    else if (avg < 90 && avg >= 87)
                    {
                        studentInfo += "B+\n";
                    }
                    else if (avg < 87 && avg >= 83)
                    {
                        studentInfo += "B\n";
                    }
                    else if (avg < 83 && avg >= 80)
                    {
                        studentInfo += "B-\n";
                    }
                    else if (avg < 80 && avg >= 77)
                    {
                        studentInfo += "C+\n";
                    }
                    else if (avg < 77 && avg >= 73)
                    {
                        studentInfo += "C\n";
                    }
                    else if (avg < 73 && avg >= 70)
                    {
                        studentInfo += "C-\n";
                    }
                    else if (avg < 70 && avg >= 67)
                    {
                        studentInfo += "D+\n";
                    }
                    else if (avg < 67 && avg >= 63)
                    {
                        studentInfo += "D\n";
                    }
                    else if (avg < 63 && avg >= 60)
                    {
                        studentInfo += "D-\n";
                    }
                    else if (avg < 60)
                    {
                        studentInfo += "E\n";
                    }
                    // Adds the new line to txt_studentInfo
                    txt_studentInfo.Text += studentInfo;
                }
            }
        }

        /// <summary>
        /// Sets everything back to its default state to start the program over
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmd_reset_Click(object sender, RoutedEventArgs e)
        {

            if (countsDone())
            {
                for (int i = 0; i < _studentNameArray.Length; i++)
                {
                    _studentNameArray[i] = "Student #" + (1 + i);
                }

                for (int row = 0; row < _gradesArray.GetLength(0); row++)
                {
                    for (int column = 0; column < _gradesArray.GetLength(1); column++)
                    {
                        _gradesArray[row, column] = 0;
                    }
                }

                txt_studentInfo.Text = "Student\t \t" + "#1\t" + "AVG\t" + "Grade \n";
                _numAssignments = 0;
                _numStudents = 0;
                _nameArrayIndex = 0;
                _studentEntered = false;
                _assignmentsEntered = false;
                lbl_numStudentError.Content = "";
                lbl_studentName.Content = "Student #1";
                lbl_assignNum.Content = "Enter Assignment Number:";
                lbl_assigmentNumError.Content = "";
                lbl_assigmentNumError.Content = "";
                lbl_numStudentError.Content = "";
                lbl_assignmentScoreError.Content = "";
                txt_studentName.Text = "Student #1";
                txt_assignNum.Text = "";
                txt_assignScore.Text = "";
                txt_numStudents.Text = "";
                txt_numAssignments.Text = "";
            }



        }
    }
}
