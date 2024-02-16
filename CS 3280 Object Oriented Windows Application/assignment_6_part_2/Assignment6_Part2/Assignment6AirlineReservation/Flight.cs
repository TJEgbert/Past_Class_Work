using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Assignment6AirlineReservation
{
    public class Flight
    {
        #region Attributes
        /// <summary>
        /// Holds the FlightId 
        /// </summary>
        private string _Id;

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
        public string ID
        { 
            get 
            {
                try
                {
                    return _Id;
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
                    _Id = value;
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
        #endregion
    }
}
