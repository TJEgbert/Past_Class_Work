using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Assignment6AirlineReservation
{
    public class FlightData
    {
        #region Attributes
        /// <summary>
        /// Holds the rows in the Flight table
        /// </summary>
        private int _numOfRows;

        /// <summary>
        /// Holds the list of Flight objects created from the database
        /// </summary>
        private List<Flight> _FlightList;

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
        private DataSet _Flights;

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
        /// Nondefault constructor for the FlightData class
        /// Then calls the Database to get table containing the flights
        /// </summary>
        /// <param name="clsSQL">An object of SQL class</param>
        /// <param name="DataAccess">An Object of DataAccess class</param>
        /// <param name="handler">An object of type errorHandler</param>
        /// <exception cref="Exception">Throws the information about the method to the higher level methods</exception>
        public FlightData(SQL clsSQL, clsDataAccess DataAccess, errorHandler handler) 
        {
            try
            {
                SQLStatements = clsSQL;
                Database = DataAccess;
                errorHandler = handler;

                _Flights = new DataSet();
                _Flights = _Database.ExecuteSQLStatement(_SQLStatements.GetFlightsSQL(), ref _numOfRows);
            }
            catch (Exception ex)
            {

                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + " . " +
                MethodInfo.GetCurrentMethod().Name + "->" + ex.Message);
            }

        }


        /// <summary>
        /// Loops through the _Flights to create Flight objects and store them in _FlightLest 
        /// </summary>
        /// <returns>A list of flight objects</returns>
        /// <exception cref="Exception">Throws the information about the method to the higher level methods</exception>
        public List<Flight> GetFlights()
        {
            try
            {
                _FlightList = new List<Flight>();
                 
                if (_Flights != null)
                {
                    for (int i = 0; i < _numOfRows; i++)
                    {
                        Flight flight = new Flight();
                        flight.ID = _Flights.Tables[0].Rows[i][0].ToString();
                        flight.FlightNum = _Flights.Tables[0].Rows[i][1].ToString();
                        flight.AircraftType = _Flights.Tables[0].Rows[i][2].ToString();
                        _FlightList.Add(flight);
                    }
                }
                return _FlightList;
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
