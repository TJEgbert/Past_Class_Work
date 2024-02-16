using System;
using System.Collections.Generic;
using System.Linq;
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
using System.Reflection;

namespace AirlineReservation
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        #region Attributes

        /// <summary>
        /// Used to check if a flight has been selected
        /// </summary>
        private bool _FlightSelected;

        /// <summary>
        /// Holds an object AirlineReservationLogic to handle the business logic
        /// </summary>
        private AirlineReservationLogic _AirlineReservationLogic;

        /// <summary>
        /// Handles errors if exception is thrown
        /// </summary>
        public errorHandler errorHandler;

        #endregion

        #region Methods
        /// <summary>
        /// Sets the Starting State of the window with initializing attributes needed at start up
        /// </summary>
        /// <exception cref="Exception">Throws the information about the method to the higher level methods</exception>
        private void StartState()
        {
            try
            {
                errorHandler = new errorHandler();
                _AirlineReservationLogic = new AirlineReservationLogic();

                cbx_Flight.ItemsSource = _AirlineReservationLogic.GetFlights(); ;
                _FlightSelected = false;
            }
            catch (Exception ex)
            {
               throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + " . " +
               MethodInfo.GetCurrentMethod().Name + "->" + ex.Message);
            }
        }
        #endregion

        /// <summary>
        /// Initialize the window and call StartState set up attributes needed for the window
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();   
            StartState();
        }

        /// <summary>
        /// Checks what flight has been chosen in the cbx_Flight
        /// Uses _AirlineReservationLogic class to get the passenger related to the Flight chosen
        /// Displays the canvas with its related Flight
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpdateFlight(object sender, SelectionChangedEventArgs e)
        {
            lbl_test.Content = e.AddedItems;
            try
            {
                Flight f1 = new Flight();
                f1.FlightID = "1";

                Flight f2 = new Flight();
                f2.FlightID = "2";


                if (cbx_Flight.SelectedItem != null) 
                {
                    if (!_FlightSelected)
                    {
                        // Enable disabled UI elements
                        _FlightSelected = true;

                        cbx_PassengerList.IsEnabled = true;
                        txt_SeatNumber.IsEnabled = true;
                        cmd_AddPassenger.IsEnabled = true;
                        cmd_ChangeSeat.IsEnabled = true;
                        cmd_DeletePassenger.IsEnabled = true;

                    }

                    if ((Flight)cbx_Flight.SelectedItem == f1)
                    {
                        cbx_PassengerList.ItemsSource = null;
                        cnv_Flight2.Visibility = Visibility.Collapsed;
                        cnv_Flight1.Visibility = Visibility.Visible;

                        cbx_PassengerList.ItemsSource = _AirlineReservationLogic.GetPassengerF1();

                    }
                    else if ((Flight)cbx_Flight.SelectedItem == f2)
                    {
                        cbx_PassengerList.ItemsSource = null;
                        cnv_Flight1.Visibility = Visibility.Collapsed;
                        cnv_Flight2.Visibility = Visibility.Visible;

                        cbx_PassengerList.ItemsSource = _AirlineReservationLogic.GetPassengerF2();
                    }

                }
               
            }
            catch (Exception ex)
            {
                errorHandler.logError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// An event for when a user clicks one of the seat labels
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SeatClicked(object sender, MouseButtonEventArgs e)
        {
            try
            {
                
            }
            catch (Exception ex)
            {
               errorHandler.logError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// Creates an instance of AddPassengerForm and opens the window
        /// Passes along errorHandler object to the new window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmd_AddPassenger_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                AddPassenger AddPassengerForm = new AddPassenger();
                AddPassengerForm.errorHandler = errorHandler;
                AddPassengerForm.ShowDialog();
            }
            catch (Exception ex)
            {
                errorHandler.logError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);
            }

        }
    }
}
