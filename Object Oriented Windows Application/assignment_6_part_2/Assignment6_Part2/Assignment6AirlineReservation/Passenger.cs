using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Assignment6AirlineReservation
{
    public class Passenger
    {
        #region Attributes
        /// <summary>
        /// Holds the PassengerId
        /// </summary>
        private string _Id;

        /// <summary>
        /// Holds the PassengerFirstName
        /// </summary>
        private string _FirstName;

        /// <summary>
        /// Holds the PassengerLastName
        /// </summary>
        private string _LastName;

        /// <summary>
        /// Holds the SeatNumber
        /// </summary>
        private string _SeatNumber;
        #endregion

        #region Methods
        /// <summary>
        /// Sets / Get _PassengerId
        /// </summary>
        public string Id
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
        /// Sets / Get _PassengerFirstName
        /// </summary>
        public string FirstName
        {
            get
            {
                try
                {
                    return _FirstName;
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
                    _FirstName = value;
                }
                catch (Exception ex)
                {

                    throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + " . " +
                    MethodInfo.GetCurrentMethod().Name + "->" + ex.Message);
                }

            }
        }

        /// <summary>
        /// Sets / Get _PassengerLastName
        /// </summary>
        public string LastName
        {
            get
            {
                try
                {
                    return _LastName;
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
                    _LastName = value;
                }
                catch (Exception ex)
                {

                    throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + " . " +
                    MethodInfo.GetCurrentMethod().Name + "->" + ex.Message);
                }

            }
        }

        /// <summary>
        /// Sets / Get _SeatNumber
        /// </summary>
        public string SeatNumber
        {
            get
            {
                try
                {
                    return _SeatNumber;
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
                    _SeatNumber = value;
                }
                catch (Exception ex)
                {

                    throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + " . " +
                    MethodInfo.GetCurrentMethod().Name + "->" + ex.Message);
                }

            }
        }

        /// <summary>
        /// Overrides the ToString to print "_FirstName _LastName"
        /// </summary>
        /// <returns>The custom string</returns>
        /// <exception cref="Exception">Throws the information about the method to the higher level methods</exception>
        public override string ToString()
        {
            try
            {
                return _FirstName + " " + _LastName; ;
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
