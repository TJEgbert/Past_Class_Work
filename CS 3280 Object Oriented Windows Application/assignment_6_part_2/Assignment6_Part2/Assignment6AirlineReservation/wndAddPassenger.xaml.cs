using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Assignment6AirlineReservation
{
    /// <summary>
    /// Interaction logic for wndAddPassenger.xaml
    /// </summary>
    public partial class wndAddPassenger : Window
    {

        #region Attributes
        /// <summary>
        /// Holds the errorHandler to handle exceptions
        /// </summary>
        public errorHandler errorHandler;

        /// <summary>
        /// Holds the main window so the New Passenger can move into the main window
        /// </summary>
        public MainWindow main;
        #endregion

  
        /// <summary>
        /// constructor for the add passenger window
        /// </summary>
        public wndAddPassenger()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            {
                errorHandler.logError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// only allows letters to be input
        /// </summary>
        /// <param name="sender">sent object</param>
        /// <param name="e">key argument</param>
        private void txtLetterInput_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                //Only allow letters to be entered
                if (!(e.Key >= Key.A && e.Key <= Key.Z))
                {
                    //Allow the user to use the backspace, delete, tab and enter
                    if (!(e.Key == Key.Back || e.Key == Key.Delete || e.Key == Key.Tab || e.Key == Key.Enter))
                    {
                        //No other keys allowed besides numbers, backspace, delete, tab, and enter
                        e.Handled = true;
                    }
                }
            }
            catch (System.Exception ex)
            {
                errorHandler.logError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// Checks to see if things have been entered into the two fields.
        /// If so creates new Passenger and stores the first name and last name
        /// </summary>
        /// <param name="sender">sent object</param>
        /// <param name="e">Routed Event argument</param>
        private void cmdSave_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                if (txtFirstName.Text != String.Empty && txtLastName.Text != String.Empty)
                {
                    Passenger NewPassenger = new Passenger();
                    NewPassenger.FirstName = txtFirstName.Text;
                    NewPassenger.LastName = txtLastName.Text;

                    main.NewPassenger = NewPassenger;
                    main.PassengerAdd = true;

                    this.Close();
                }
            }
            catch (System.Exception ex)
            {
                errorHandler.logError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }
    }
}
