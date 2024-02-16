using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Assignment6AirlineReservation
{
    public class SQL
    {
        #region Methods
        /// <summary>
        /// The SQL statement to get the flight tables
        /// </summary>
        /// <returns>String of the SQL statement</returns>
        /// <exception cref="Exception">Throws the information about the method to the higher level methods</exception>
        public string GetFlightsSQL()
        {
            try
            {
                return "SELECT Flight_ID, Flight_Number, Aircraft_Type FROM FLIGHT"; ;

            }
            catch (Exception ex)
            {

                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + " . " +
                MethodInfo.GetCurrentMethod().Name + "->" + ex.Message);
            }
        }

        /// <summary>
        /// The SQL statement for table of passenger to a related flight
        /// </summary>
        /// <param name="FlightID">The Flight the user want to get the passengers from</param>
        /// <returns>String of the SQL statement</returns>
        /// <exception cref="Exception">Throws the information about the method to the higher level methods</exception>
        public string GetPassengersSQL(string FlightID)
        {
            try
            {
                return "SELECT PASSENGER.Passenger_ID, First_Name, Last_Name, Seat_Number " +
                        "FROM FLIGHT_PASSENGER_LINK, FLIGHT, PASSENGER " +
                        "WHERE FLIGHT.FLIGHT_ID = FLIGHT_PASSENGER_LINK.FLIGHT_ID AND " +
                        "FLIGHT_PASSENGER_LINK.PASSENGER_ID = PASSENGER.PASSENGER_ID AND " +
                        "FLIGHT.FLIGHT_ID = " + FlightID;

            }
            catch (Exception ex)
            {

                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + " . " +
                MethodInfo.GetCurrentMethod().Name + "->" + ex.Message);
            }
        }

        /// <summary>
        /// The SQL statement for adding a passenger to the passenger table
        /// </summary>
        /// <param name="FirstName">The first name of the passenger</param>
        /// <param name="LastName">The last name of the passenger</param>
        /// <returns>String of the SQL statement</returns>
        /// <exception cref="Exception">Throws the information about the method to the higher level methods</exception>
        public string AddPassengerSQL(string FirstName, string LastName)
        {
            try
            {
                return "INSERT INTO PASSENGER(First_Name, Last_Name) " +
                        "VALUES('" + FirstName + "', '" + LastName + "')";

            }
            catch (Exception ex)
            {

                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + " . " +
                MethodInfo.GetCurrentMethod().Name + "->" + ex.Message);
            }

        }

        /// <summary>
        /// The SQL statement for getting a passengers ID number
        /// </summary>
        /// <param name="FirstName">The first name of the passenger</param>
        /// <param name="LastName">The last name of the passenger</param>
        /// <returns>String of the SQL statement</returns>
        /// <exception cref="Exception">Throws the information about the method to the higher level methods</exception>
        public string GetPassengerIDSQL(string FirstName, string LastName) 
        {
            try
            {
                return "SELECT Passenger_ID from Passenger where First_Name = '" + FirstName + "' AND Last_Name = '" + LastName + "'";

            }
            catch (Exception ex)
            {

                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + " . " +
                MethodInfo.GetCurrentMethod().Name + "->" + ex.Message);
            }
            
        }

        /// <summary>
        /// The SQL statement for updating the link between the passenger and the flight
        /// </summary>
        /// <param name="FlightId">The ID number of the flight the passenger is on</param>
        /// <param name="PassengerID">The ID number of the passenger</param>
        /// <param name="SeatNumber">The seat number the passenger is in</param>
        /// <returns>String of the SQL statement</returns>
        /// <exception cref="Exception">Throws the information about the method to the higher level methods</exception>
        public string AddPassengerToFlightSQL(string FlightId, string PassengerID, string SeatNumber)
        {
            try
            {
                return "INSERT INTO Flight_Passenger_Link(Flight_ID, Passenger_ID, Seat_Number) " +
                        "VALUES(" + FlightId + " , " + PassengerID + " , '" + SeatNumber + "')";

            }
            catch (Exception ex)
            {

                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + " . " +
                MethodInfo.GetCurrentMethod().Name + "->" + ex.Message);
            }

        }

        /// <summary>
        /// The SQL statement for deleting the link between the passenger and flight
        /// </summary>
        /// <param name="FlightId">The ID number of the flight the passenger is on</param>
        /// <param name="PassengerID">The ID number of the passenger</param>
        /// <returns>String of the SQL statement</returns>
        /// <exception cref="Exception">Throws the information about the method to the higher level methods</exception>
        public string DeleteLinkSQL(string FlightId, string PassengerID)
        {
            try
            {
                return "Delete FROM FLIGHT_PASSENGER_LINK " +
                        "WHERE FLIGHT_ID = " + FlightId + " AND " + "PASSENGER_ID =" + PassengerID;

            }
            catch (Exception ex)
            {

                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + " . " +
                MethodInfo.GetCurrentMethod().Name + "->" + ex.Message);
            }

        }

        /// <summary>
        /// The SQL statement for deleting a passenger from the passenger table
        /// </summary>
        /// <param name="PassengerID">The ID number of the passenger</param>
        /// <returns>String of the SQL statement</returns>
        /// <exception cref="Exception">Throws the information about the method to the higher level methods</exception>
        public string DeletePassengerSQL(string PassengerID)
        {
            try
            {
                return "Delete FROM PASSENGER WHERE PASSENGER_ID = " + PassengerID; ;

            }
            catch (Exception ex)
            {

                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + " . " +
                MethodInfo.GetCurrentMethod().Name + "->" + ex.Message);
            }
        }

        /// <summary>
        /// The SQL statement for updating a passengers seat on a flight
        /// </summary>
        /// <param name="SeatNumber">The number of the new seat</param>
        /// <param name="FlightId">The ID number of the flight the passenger is on</param>
        /// <param name="PassengerID">The ID number of the passenger</param>
        /// <returns>String of the SQL statement</returns>
        /// <exception cref="Exception">Throws the information about the method to the higher level methods</exception>
        public string SeatUpdate(string SeatNumber, string FlightID, string PassengerID)
        {
            try
            {
                return "UPDATE FLIGHT_PASSENGER_LINK " +
                        "SET Seat_Number = '" + SeatNumber + "' " +
                        "WHERE FLIGHT_ID = " + FlightID + "AND PASSENGER_ID = " + PassengerID + "";

            }
            catch (Exception ex)
            {

                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + " . " +
                MethodInfo.GetCurrentMethod().Name + "->" + ex.Message);
            }

        }
        #endregion
    }

}
