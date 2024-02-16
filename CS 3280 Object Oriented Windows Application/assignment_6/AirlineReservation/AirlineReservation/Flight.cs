using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace AirlineReservation
{
    public class Flight
    {
        #region Attributes
        /// <summary>
        /// Holds the FlightId 
        /// </summary>
        private string _FlightId;

        /// <summary>
        /// Holds the FlightNum
        /// </summary>
        private string _FlightNum;

        /// <summary>
        /// Holds the AircraftType
        /// </summary>
        private string _AircraftType;

        #endregion

        #region Methods
        /// <summary>
        /// Set / Get for FlightId 
        /// </summary>
        public string FlightID
        { 
            get 
            {
                try
                {
                    return _FlightId;
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
                    _FlightId = value;
                }
                catch (Exception ex)
                {

                    throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + " . " +
                    MethodInfo.GetCurrentMethod().Name + "->" + ex.Message);
                }
                
            }
        }

        /// <summary>
        /// Set/ Get for FlightNum
        /// </summary>
        public string FlightNum
        {
            get
            {
                try
                {
                    return _FlightNum;
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
                    _FlightNum = value;
                }
                catch (Exception ex)
                {

                    throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + " . " +
                    MethodInfo.GetCurrentMethod().Name + "->" + ex.Message);
                }

            }
        }

        /// <summary>
        /// Set / Get AircraftType
        /// </summary>
        public string AircraftType
        {
            get
            {
                try
                {
                    return _AircraftType;
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
                    _AircraftType = value;
                }
                catch (Exception ex)
                {

                    throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + " . " +
                    MethodInfo.GetCurrentMethod().Name + "->" + ex.Message);
                }

            }
        }

        /// <summary>
        /// Overrides the ToString to print "_FlightNum AircraftType"
        /// </summary>
        /// <returns>The custom string</returns>
        /// <exception cref="Exception">Throws the information about the method to the higher level methods</exception>
        public override string ToString()
        {
            try
            {
                return _FlightNum + " " + _AircraftType;
            }
            catch (Exception ex)
            {

                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + " . " +
                MethodInfo.GetCurrentMethod().Name + "->" + ex.Message);
            }
            
        }

        /// <summary>
        /// Custom == that compares the FlightId of two Flight objects
        /// </summary>
        /// <param name="f1">One of the Flight object you want to compare</param>
        /// <param name="f2">The other Flight object you want to compare</param>
        /// <returns>Returns true if flightId the same, false if not</returns>
        /// <exception cref="Exception">Throws the information about the method to the higher level methods</exception>
        public static bool operator ==(Flight f1, Flight f2)
        {
            try
            {
                if (f1._FlightId == f2._FlightId)
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {

                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + " . " +
                MethodInfo.GetCurrentMethod().Name + "->" + ex.Message);
            }
    
        }

        /// <summary>
        /// Custom != that compares FlightId of two Flight objects
        /// </summary>
        /// <param name="f1">One of the Flight object you want to compare</param>
        /// <param name="f2">The other Flight object you want to compare</param>
        /// <returns>Returns true if the flight id are not same, returns false if they are the same</returns>
        /// <exception cref="Exception">Throws the information about the method to the higher level methods</exception>
        public static bool operator !=(Flight f1, Flight f2)
        {
            try
            {
                if (f1._FlightId != f2._FlightId)
                {
                    return false;
                }
                return true;
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
