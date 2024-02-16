using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Data;
using System.Windows.Controls.Primitives;

namespace AirlineReservation
{
    public class AirlineReservationLogic
    {
        #region Attributes
        /// <summary>
        /// Holds a copy of the database Reservation system
        /// </summary>
        private clsDataAccess _Database;

        #endregion

        #region Methods
        /// <summary>
        /// A Custom Constructor for the AirlineReservationLogic class
        /// </summary>
        public AirlineReservationLogic()
        {
            try
            {
                _Database = new clsDataAccess();
            }
            catch (Exception ex)
            {

                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + " . " +
                MethodInfo.GetCurrentMethod().Name + "->" + ex.Message);
            }
        }


        /// <summary>
        /// Calls the clsDataAccess to get the table containing the Flight information from the database
        /// Then creates an object for each Flight and returns a list containing those Flights objects
        /// </summary>
        /// <returns>A list of of Flight objects</returns>
        /// <exception cref="Exception">Throws the information about the method to the higher level methods</exception>
        public List<Flight> GetFlights()
        {

            {
                try
                {
                    List<Flight> FlightList = new List<Flight>();
                    DataSet Flights = new DataSet();
                    int numOfRows = 0;
                    Flights = _Database.ExecuteSQLStatement("SELECT Flight_ID, Flight_Number, Aircraft_Type FROM FLIGHT", ref numOfRows);

                    if (Flights != null)
                    {
                        for (int i = 0; i < numOfRows; i++)
                        {
                            Flight flight = new Flight();
                            flight.FlightID = Flights.Tables[0].Rows[i][0].ToString();
                            flight.FlightNum = Flights.Tables[0].Rows[i][1].ToString();
                            flight.AircraftType = Flights.Tables[0].Rows[i][2].ToString();
                            FlightList.Add(flight);
                        }
                    }
                    return FlightList;
                }
                catch (Exception ex)
                {

                    throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + " . " +
                    MethodInfo.GetCurrentMethod().Name + "->" + ex.Message);
                }

            }
        }

        /// <summary>
        /// Calls the clsDataAccess to get the table containing the Passengers with a Flight_ID of 1 information from the database
        /// Then creates an object for each Passenger and returns a list containing those Passengers objects
        /// </summary>
        /// <returns>The list of Passenger objects</returns>
        /// <exception cref="Exception">Throws the information about the method to the higher level methods</exception>
        public List<Passenger> GetPassengerF1()
        {

            try
            {
                List<Passenger> _PassengerList = new List<Passenger>();
                DataSet Passengers = new DataSet();
                int numOfRows = 0;
                Passengers = _Database.ExecuteSQLStatement("SELECT PASSENGER.Passenger_ID, First_Name, Last_Name, Seat_Number " +
                                                          "FROM FLIGHT_PASSENGER_LINK, FLIGHT, PASSENGER " +
                                                          "WHERE FLIGHT.FLIGHT_ID = FLIGHT_PASSENGER_LINK.FLIGHT_ID AND " +
                                                          "FLIGHT_PASSENGER_LINK.PASSENGER_ID = PASSENGER.PASSENGER_ID AND " +
                                                          "FLIGHT.FLIGHT_ID = 1", ref numOfRows);
                
                if(Passengers != null)
                {
                    for (int i = 0; i < numOfRows; i++)
                    {
                        Passenger NewPassenger = new Passenger();
                        NewPassenger.PassengerId = Passengers.Tables[0].Rows[i][0].ToString();
                        NewPassenger.PassengerFirstName = Passengers.Tables[0].Rows[i][1].ToString();
                        NewPassenger.PassengerLastName = Passengers.Tables[0].Rows[i][2].ToString();
                        NewPassenger.SeatNumber = Passengers.Tables[0].Rows[i][3].ToString();
                        _PassengerList.Add(NewPassenger);
                    }

                }

                return _PassengerList;

            }
            catch (Exception ex)
            {

                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + " . " +
                MethodInfo.GetCurrentMethod().Name + "->" + ex.Message);
            }
          
        }

        /// <summary>
        /// Calls the clsDataAccess to get the table containing the Passengers with a Flight_ID of 2 information from the database
        /// Then creates an object for each Passenger and returns a list containing those Passengers objects
        /// </summary>
        /// <returns>The list of Passenger objects</returns>
        /// <exception cref="Exception">Throws the information about the method to the higher level methods</exception>
        public List<Passenger> GetPassengerF2()
        {


            try
            {

                List<Passenger> _PassengerList = new List<Passenger>();
                DataSet Passengers = new DataSet();
                int numOfRows = 0;
                Passengers = _Database.ExecuteSQLStatement("SELECT PASSENGER.Passenger_ID, First_Name, Last_Name, Seat_Number " +
                                                          "FROM FLIGHT_PASSENGER_LINK, FLIGHT, PASSENGER " +
                                                          "WHERE FLIGHT.FLIGHT_ID = FLIGHT_PASSENGER_LINK.FLIGHT_ID AND " +
                                                          "FLIGHT_PASSENGER_LINK.PASSENGER_ID = PASSENGER.PASSENGER_ID AND " +
                                                          "FLIGHT.FLIGHT_ID = 2", ref numOfRows);

                if(Passengers != null)
                {
                    for (int i = 0; i < numOfRows; i++)
                    {
                        Passenger NewPassenger = new Passenger();
                        NewPassenger.PassengerId = Passengers.Tables[0].Rows[i][0].ToString();
                        NewPassenger.PassengerFirstName = Passengers.Tables[0].Rows[i][1].ToString();
                        NewPassenger.PassengerLastName = Passengers.Tables[0].Rows[i][2].ToString();
                        NewPassenger.SeatNumber = Passengers.Tables[0].Rows[i][3].ToString();
                        _PassengerList.Add(NewPassenger);
                    }
                }

                return _PassengerList;
            }
            catch (Exception ex)
            {

                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + " . " +
                MethodInfo.GetCurrentMethod().Name + "->" + ex.Message);
            }
          
        }

    }
    #endregion
}
