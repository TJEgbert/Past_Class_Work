using System;
using System.Collections.Generic;
using System.Data;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Assignment6AirlineReservation
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Attributes
        /// <summary>
        /// An object of FlightData class handles flight related logic
        /// </summary>
        private FlightData FlightData;

        /// <summary>
        /// An object of th PassengerData class handles passenger related logic 
        /// </summary>
        private PassengerData PassengerData;

        /// <summary>
        /// An object of SQL class used to pass into FlightData and PassengerData objects
        /// </summary>
        private SQL SQL;

        /// <summary>
        /// An object of clsDataAccess used to access the database
        /// Passed to the FlightData and PassengerData objects
        /// </summary>
        private clsDataAccess clsDataAccess;

        /// <summary>
        /// Used to check during a seat click if the user is switching seats
        /// </summary>
        private bool SwitchingSeat;

        /// <summary>
        /// An object of wndAddPassenger 
        /// </summary>
        private wndAddPassenger wndAddPass;

        /// <summary>
        /// An object of errorHandler class used to handle exceptions
        /// Gets passed to all other objects
        /// </summary>
        public errorHandler errorHandler;

        /// <summary>
        /// An object of Passenger class used to store information about a passenger being added to database
        /// </summary>
        public Passenger NewPassenger;

        /// <summary>
        /// Used to check during a seat click if the user is selecting a seat for a new passenger
        /// </summary>
        public bool PassengerAdd;

        /// <summary>
        /// Holds a list of Flight objects
        /// </summary>
        public List<Flight> FlightList;

        /// <summary>
        /// Holds a list of Passengers objects related to which flight was chosen
        /// </summary>
        public List<Passenger> PassengerList;

        #endregion

        #region Methods
        /// <summary>
        /// Disable all the related to passengers and flights UI expect for the seating
        /// </summary>
        /// <exception cref="Exception">Throws the information about the method to the higher level methods</exception>
        private void DisableAllUI()
        {
            try
            {
                cbChooseFlight.IsEnabled = false;
                cbChoosePassenger.IsEnabled = false;
                cmdAddPassenger.IsEnabled = false;
                cmdChangeSeat.IsEnabled = false;
                cmdDeletePassenger.IsEnabled = false;
            }
            catch (Exception ex)
            {

                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + " . " +
                 MethodInfo.GetCurrentMethod().Name + "->" + ex.Message);
            }
        }

        /// <summary>
        /// Enable all the UI related to passengers and flights
        /// </summary>
        /// <exception cref="Exception">Throws the information about the method to the higher level methods</exception>
        private void EnableAllUI()
        {

            try
            {
                cbChooseFlight.IsEnabled = true;
                cbChoosePassenger.IsEnabled = true;
                cmdAddPassenger.IsEnabled = true;
                cmdChangeSeat.IsEnabled = true;
                cmdDeletePassenger.IsEnabled = true;
            }
            catch (Exception ex)
            {

                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + " . " +
                 MethodInfo.GetCurrentMethod().Name + "->" + ex.Message);
            }
        }

        /// <summary>
        /// Gets the ID of the current flight
        /// </summary>
        /// <returns>A string of the FlightID</returns>
        /// <exception cref="Exception">Throws the information about the method to the higher level methods</exception>
        private string GetFlightID()
        {

            try
            {
                Flight selection = (Flight)cbChooseFlight.SelectedItem;
                return selection.ID;
            }
            catch (Exception ex)
            {

                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + " . " +
                 MethodInfo.GetCurrentMethod().Name + "->" + ex.Message);
            }
        }

        /// <summary>
        /// Checks to what the current flight is and loops through the passengers changing there seat color to red
        /// </summary>
        /// <exception cref="Exception">Throws the information about the method to the higher level methods</exception>
        private void SeatsTaken()
        {

            try
            {
                // Checks to see if the current flight is A380
                if(GetFlightID() == "1")
                {
                    foreach (var Pass in cbChoosePassenger.Items)
                    {
                        Passenger person = (Passenger)Pass;
                        string seatNum = person.SeatNumber;

                        foreach (var Seat in cA380_Seats.Children.OfType<System.Windows.Controls.Label>())
                        {
                            if (Seat.Content.ToString() == seatNum)
                            {
                                Seat.Background = Brushes.Red;
                                break;
                            }
                        }

                    }
                }
                // or it is 767
                else
                {

                    foreach (var Pass in cbChoosePassenger.Items)
                    {
                        Passenger person = (Passenger)Pass;
                        string seatNum = person.SeatNumber;

                        foreach (var Seat in c767_Seats.Children.OfType<System.Windows.Controls.Label>())
                        {
                            if (Seat.Content.ToString() == seatNum)
                            {
                                Seat.Background = Brushes.Red;
                                break;
                            }
                        }

                    }
                }
               
            }
            catch (Exception ex)
            {

               throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + " . " +
                MethodInfo.GetCurrentMethod().Name + "->" + ex.Message);
            }
        }

        /// <summary>
        /// Updates the combo box containing the PassengerList
        /// </summary>
        /// <exception cref="Exception">Throws the information about the method to the higher level methods</exception>
        private void UpdatePassengers()
        {
            try
            {
                PassengerList = new List<Passenger>();

                PassengerList = PassengerData.GetPassengers(GetFlightID());
                cbChoosePassenger.ItemsSource = PassengerList;


            }
            catch (Exception ex)
            {

                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + " . " +
                 MethodInfo.GetCurrentMethod().Name + "->" + ex.Message);
            }
        }

        /// <summary>
        /// Sets up the objects used in the main window 
        /// and passes objects needed for the FlightData and PassengerData objects
        /// </summary>
        /// <exception cref="Exception">Throws the information about the method to the higher level methods</exception>
        private void InitializeClasses()
        {
            try
            {
                errorHandler = new errorHandler();
                SQL = new SQL();
                clsDataAccess = new clsDataAccess();


                FlightData = new FlightData(SQL, clsDataAccess, errorHandler);
                PassengerData = new PassengerData(SQL, clsDataAccess, errorHandler);

            }
            catch (Exception ex)
            {

                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + " . " +
                 MethodInfo.GetCurrentMethod().Name + "->" + ex.Message);
            }

        }

        #endregion

        /// <summary>
        /// Gets the main window setup for use 
        /// </summary>
        public MainWindow()
        {
            try
            {
                InitializeComponent();
                Application.Current.ShutdownMode = ShutdownMode.OnMainWindowClose;
                InitializeClasses();
                DisableAllUI();

                // Creates gets the list of flights and binds them to a combo box and enable that combo box
                FlightList = new List<Flight>();
                FlightList = FlightData.GetFlights();
                cbChooseFlight.ItemsSource = FlightList;
                cbChooseFlight.IsEnabled = true;

            }
            catch (Exception ex)
            {
                errorHandler.logError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// When the combo box selection is change it shows the corresponding seating for the flight
        /// Also enable AddPassenger button and the passenger combo box then updates the combo box
        /// Calls updatePassengers and SeatsTaken
        /// </summary>
        /// <param name="sender">The combo box</param>
        /// <param name="e">Selection Changed Event Arguments</param>
        private void cbChooseFlight_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                cbChoosePassenger.IsEnabled = true;
                cmdAddPassenger.IsEnabled = true;
               

                if (GetFlightID() == "1")
                {
                    Canvas767.Visibility = Visibility.Hidden;
                    CanvasA380.Visibility = Visibility.Visible;  
                }
                else
                {
                    CanvasA380.Visibility = Visibility.Hidden;
                    Canvas767.Visibility = Visibility.Visible;

                }

                UpdatePassengers();
                SeatsTaken();

                cmdChangeSeat.IsEnabled = false;
                cmdDeletePassenger.IsEnabled = false;

            }
            catch (Exception ex)
            {
                errorHandler.logError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// Creates an object and wndAddPassenger and passes in needed object and then displays the window
        /// If after the window closes and PassengerAdd is true it will also call DisableAllUI
        /// </summary>
        /// <param name="sender">The button that was clicked</param>
        /// <param name="e">Routed event Arguments</param>
        private void cmdAddPassenger_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                wndAddPass = new wndAddPassenger();
                wndAddPass.errorHandler = errorHandler;
                wndAddPass.main = this;
                PassengerAdd = false;

                wndAddPass.ShowDialog();


                if (PassengerAdd)
                {
                    DisableAllUI();
                }
            }
            catch (Exception ex)
            {
                errorHandler.logError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// Updates the seat that is clicked according to what bool is true
        /// </summary>
        /// <param name="sender">The label that was clicked</param>
        /// <param name="e">Mouse button event arguments</param>
        private void SeatClicked(object sender, MouseButtonEventArgs e)
        {

            try
            {
                // The label that clicked
                Label LabelClicked = (Label)sender;

                if (LabelClicked != null)
                {
                    // If the background of the label is blue
                    if (LabelClicked.Background == Brushes.Blue)
                    {
                        // If PassengerAdd is true
                        if (PassengerAdd)
                        {
                            // Gets the seatNumber for the new passenger and uses PassengerData to add the passenger to the database
                            NewPassenger.SeatNumber = LabelClicked.Content.ToString();
                            PassengerData.AddPassenger(NewPassenger, GetFlightID());
                            UpdatePassengers();

                            // Updates related UI elements
                            EnableAllUI();
                            lblPassengersSeatNumber.Content = LabelClicked.Content.ToString();
                            LabelClicked.Background = Brushes.Green;

                            foreach (var Pass in cbChoosePassenger.Items)
                            {
                                Passenger person = (Passenger)Pass;

                                if (person.SeatNumber == LabelClicked.Content.ToString())
                                {
                                    cbChoosePassenger.SelectedItem = person;
                                    break;
                                }
                            }

                            // Ends adding the passenger
                            PassengerAdd = false;
                            EnableAllUI();
                        }
                        // If SwitchingSeat is true
                        if (SwitchingSeat)
                        {
                            if (LabelClicked.Background == Brushes.Blue)
                            {
                                // The passenger the user wants to update the seating for
                                Passenger CurrentPassenger = (Passenger)cbChoosePassenger.SelectedItem;

                                // Loops through the flight the user is on so it can updates there old seat background to blue
                                if (GetFlightID() == "1")
                                {
                                    foreach (var Seat in cA380_Seats.Children.OfType<System.Windows.Controls.Label>())
                                    {
                                        if (Seat.Content.ToString() == CurrentPassenger.SeatNumber)
                                        {
                                            Seat.Background = Brushes.Blue;
                                            break;
                                        }
                                    }
                                }
                                else
                                {
                                    foreach (var Seat in c767_Seats.Children.OfType<System.Windows.Controls.Label>())
                                    {
                                        if (Seat.Content.ToString() == CurrentPassenger.SeatNumber)
                                        {
                                            Seat.Background = Brushes.Blue;
                                            break;
                                        }
                                    }
                                }

                                // Updates the CurrentPassenger seat and use PassengerData to update the database
                                CurrentPassenger.SeatNumber = LabelClicked.Content.ToString();
                                PassengerData.SeatUpdate(LabelClicked.Content.ToString(), GetFlightID(), CurrentPassenger.Id);

                                // Update related UI elements
                                LabelClicked.Background = Brushes.Green;
                                lblPassengersSeatNumber.Content = CurrentPassenger.SeatNumber;
                                EnableAllUI();

                                // Ends switching seats
                                SwitchingSeat = false;

                            }
                            
                        }
                    }
                    // If a red background label is clicked and PassengerAdd is false
                    else if (LabelClicked.Background == Brushes.Red && !PassengerAdd && !SwitchingSeat)
                    {
                        // Updates the passenger combo box to the passenger that was clicked
                        foreach (var Pass in cbChoosePassenger.Items)
                        {
                            Passenger person = (Passenger)Pass;

                            if (person.SeatNumber == LabelClicked.Content.ToString())
                            {
                                cbChoosePassenger.SelectedItem = person;
                                break;
                            }
                        }
                    }

                }

            }
            catch (Exception ex)
            {
                errorHandler.logError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);
            }

        }

        /// <summary>
        /// Enable the UI to edit passenger information
        /// Gets the current Passenger and updates the seat background to green
        /// </summary>
        /// <param name="sender"> The passenger combo box</param>
        /// <param name="e"> Selection change event arguments</param>
        private void PassengerChange(object sender, SelectionChangedEventArgs e)
        {

            try
            {
 
                SeatsTaken();
                cmdDeletePassenger.IsEnabled = true;
                cmdChangeSeat.IsEnabled = true;

                Passenger CurrentPassenger = (Passenger)cbChoosePassenger.SelectedItem;

                if (CurrentPassenger != null)
                {
                    lblPassengersSeatNumber.Content = CurrentPassenger.SeatNumber;
                    if (GetFlightID() == "1")
                    {
                        foreach (var Seat in cA380_Seats.Children.OfType<System.Windows.Controls.Label>())
                        {
                            if (Seat.Content.ToString() == CurrentPassenger.SeatNumber)
                            {
                                Seat.Background = Brushes.Green;
                                break;
                            }
                        }
                    }
                    else
                    {
                        foreach (var Seat in c767_Seats.Children.OfType<System.Windows.Controls.Label>())
                        {
                            if (Seat.Content.ToString() == CurrentPassenger.SeatNumber)
                            {
                                Seat.Background = Brushes.Green;
                                break;
                            }
                        }
                    }
                }

                if (PassengerAdd)
                {
                    DisableAllUI();
                }
                
 
            }
            catch (Exception ex)
            {
                errorHandler.logError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
            
        }

        /// <summary>
        /// Gets the current passenger and sets there seat background to blue
        /// Then it calls PassengerData to delete the passenger from the flight
        /// </summary>
        /// <param name="sender">The delete passenger button</param>
        /// <param name="e">Routed event arguments</param>
        private void cmdDeletePassenger_Click(object sender, RoutedEventArgs e)
        {

            try
            {

                Passenger CurrentPassenger = (Passenger)cbChoosePassenger.SelectedItem;

                if (CurrentPassenger != null)
                {
                    MessageBoxResult answer = MessageBox.Show("Are you sure you want to delete the passenger?", "Confirmation",
                                                              MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (answer == MessageBoxResult.Yes) 
                    {
                        lblPassengersSeatNumber.Content = CurrentPassenger.SeatNumber;
                        if (GetFlightID() == "1")
                        {
                            foreach (var Seat in cA380_Seats.Children.OfType<System.Windows.Controls.Label>())
                            {
                                if (Seat.Content.ToString() == CurrentPassenger.SeatNumber)
                                {
                                    Seat.Background = Brushes.Blue;
                                    break;
                                }
                            }
                        }
                        else
                        {
                            foreach (var Seat in c767_Seats.Children.OfType<System.Windows.Controls.Label>())
                            {
                                if (Seat.Content.ToString() == CurrentPassenger.SeatNumber)
                                {

                                    Seat.Background = Brushes.Blue;
                                    break;
                                }
                            }
                        }

                        PassengerData.DeletePassenger(GetFlightID(), CurrentPassenger.Id);
                        lblPassengersSeatNumber.Content = string.Empty;
                        UpdatePassengers();
                        cmdChangeSeat.IsEnabled = false;
                        cmdDeletePassenger.IsEnabled = false;
                    }
                }
            }
            catch (Exception ex)
            {
                errorHandler.logError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);
            }

        }

        /// <summary>
        /// Disable all UI and set SwitchingSeat to true
        /// </summary>
        /// <param name="sender">The change seat button</param>
        /// <param name="e">Routed even arguments</param>
        private void cmdChangeSeat_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                DisableAllUI();
                SwitchingSeat = true;
            }
            catch (Exception ex)
            {
                errorHandler.logError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);
            }

        }
    }
}

