using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Assignment6AirlineReservation
{
    public class PassengerData
    {
        #region Attributes
        /// <summary>
        /// An object of class SQL
        /// </summary>
        private SQL _SQLStatements;

        /// <summary>
        /// An object of class clsDataAccess
        /// </summary>
        private clsDataAccess _Database;

        /// <summary>
        /// Holds the tables from the database query
        /// </summary>
        private DataSet _Passengers;

        /// <summary>
        /// A list to hold objects of type Passengers
        /// </summary>
        private List<Passenger> _PassengersOnFlight;

        /// <summary>
        /// An object pf class errorHandler
        /// </summary>
        public errorHandler errorHandler;
        #endregion

        #region Methods
        /// <summary>
        /// Set / Get functions for SQL class
        /// </summary>
        public SQL SQLStatements
        {  
            get 
            {
                try
                {
                    return _SQLStatements;

                }
                catch (Exception ex)
                {

                    throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + " . " +
                    MethodInfo.GetCurrentMethod().Name + "->" + ex.Message);
                }
                
            }
            set 
            {
                try
                {
                    _SQLStatements = value;

                }
                catch (Exception ex)
                {

                    throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + " . " +
                    MethodInfo.GetCurrentMethod().Name + "->" + ex.Message);
                }
            }
        }

        /// <summary>
        /// Set / Get functions for clsDataAccess class
        /// </summary>
        public clsDataAccess Database
        {
            get
            {
                try
                {
                    return _Database;

                }
                catch (Exception ex)
                {

                    throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + " . " +
                    MethodInfo.GetCurrentMethod().Name + "->" + ex.Message);
                }

            }
            set
            {
                try
                {
                    _Database = value;

                }
                catch (Exception ex)
                {

                    throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + " . " +
                    MethodInfo.GetCurrentMethod().Name + "->" + ex.Message);
                }
            }
        }

        /// <summary>
        /// Nondefault constructor for the PassengerData class
        /// </summary>
        /// <param name="clsSQL">An object of SQL class</param>
        /// <param name="DataAccess">An Object of DataAccess class</param>
        /// <param name="handler">An object of type errorHandler</param>
        /// <exception cref="Exception">Throws the information about the method to the higher level methods</exception>
        public PassengerData(SQL clsSQL, clsDataAccess DataAccess, errorHandler handler) 
        {
            try
            {
                SQLStatements = clsSQL;
                Database = DataAccess;
                errorHandler = handler;

                _Passengers = new DataSet();
                
            }
            catch (Exception ex)
            {

                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + " . " +
                MethodInfo.GetCurrentMethod().Name + "->" + ex.Message);
            }
        }

        /// <summary>
        /// Queries _Database and gets the passengers related to the passed in FlightID
        /// Then it loops through creating Passenger objects and stores then in _PassengersOnFlight
        /// </summary>
        /// <param name="FlightID">The the ID of the flight that user wants the passengers from</param>
        /// <returns>A list of Passenger objects</returns>
        /// <exception cref="Exception">Throws the information about the method to the higher level methods</exception>
        public List<Passenger> GetPassengers(string FlightID)
        {
            try
            {
                _PassengersOnFlight = new List<Passenger>();
                DataSet _Passengers = new DataSet();
                int numOfRows = 0;
                _Passengers = _Database.ExecuteSQLStatement(_SQLStatements.GetPassengersSQL(FlightID), ref numOfRows);

                if (_Passengers != null)
                {
                    for (int i = 0; i < numOfRows; i++)
                    {
                        Passenger NewPassenger = new Passenger();
                        NewPassenger.Id = _Passengers.Tables[0].Rows[i][0].ToString();
                        NewPassenger.FirstName = _Passengers.Tables[0].Rows[i][1].ToString();
                        NewPassenger.LastName = _Passengers.Tables[0].Rows[i][2].ToString();
                        NewPassenger.SeatNumber = _Passengers.Tables[0].Rows[i][3].ToString();
                        _PassengersOnFlight.Add(NewPassenger);
                    }

                }

                return _PassengersOnFlight;

            }
            catch (Exception ex)
            {

                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + " . " +
                MethodInfo.GetCurrentMethod().Name + "->" + ex.Message);
            }
        }

        /// <summary>
        /// Queries _Database to insert the new passenger in _Database and connects it it the Flight
        /// </summary>
        /// <param name="NewPassenger">The new passenger to added into the _DataBase</param>
        /// <param name="FlightID">The Flight that the new passenger is on</param>
        /// <exception cref="Exception">Throws the information about the method to the higher level methods</exception>
        public void AddPassenger(Passenger NewPassenger, string FlightID)
        {
            try
            {
                string ID;
                // Adds the new passenger into the Passenger table
                _Database.ExecuteNonQuery(_SQLStatements.AddPassengerSQL(NewPassenger.FirstName, NewPassenger.LastName));
                // Gets the ID of the new passenger
                ID = _Database.ExecuteScalarSQL(_SQLStatements.GetPassengerIDSQL(NewPassenger.FirstName, NewPassenger.LastName));
                // Links the new passenger to the the flight
                _Database.ExecuteNonQuery(_SQLStatements.AddPassengerToFlightSQL(FlightID, ID, NewPassenger.SeatNumber));
            }
            catch (Exception ex)
            {

                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + " . " +
                MethodInfo.GetCurrentMethod().Name + "->" + ex.Message);
            }
        }
        /// <summary>
        /// Queries the _Database to delete the passenger and the link between the passenger and flight table 
        /// </summary>
        /// <param name="FlightId">The ID of the flight the Passenger was on</param>
        /// <param name="PassengerID">The ID of the passenger</param>
        /// <exception cref="Exception">Throws the information about the method to the higher level methods</exception>
        public void DeletePassenger(string FlightId, string PassengerID)
        {
            try
            {
                _Database.ExecuteNonQuery(_SQLStatements.DeleteLinkSQL(FlightId, PassengerID));
                _Database.ExecuteNonQuery(_SQLStatements.DeletePassengerSQL(PassengerID));

            }
            catch (Exception ex)
            {

                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + " . " +
                MethodInfo.GetCurrentMethod().Name + "->" + ex.Message);
            }
        }

        /// <summary>
        /// Quires the _Database to update the seat of the passenger
        /// </summary>
        /// <param name="SeatNumber">The new seat number</param>
        /// <param name="FlightID">The ID of the passengers flight</param>
        /// <param name="PassengerID">The ID of the passenger</param>
        /// <exception cref="Exception">Throws the information about the method to the higher level methods</exception>
        public void SeatUpdate(string SeatNumber, string FlightID, string PassengerID)
        {
            try
            {
                _Database.ExecuteNonQuery(_SQLStatements.SeatUpdate(SeatNumber, FlightID, PassengerID)); ;

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
