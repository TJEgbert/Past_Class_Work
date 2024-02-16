using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace AirlineReservation
{
    public class Passenger
    {
        #region Attributes
        /// <summary>
        /// Holds the PassengerId
        /// </summary>
        private string _PassengerId;

        /// <summary>
        /// Holds the PassengerFirstName
        /// </summary>
        private string _PassengerFirstName;

        /// <summary>
        /// Holds the PassengerLastName
        /// </summary>
        private string _PassengerLastName;

        /// <summary>
        /// Holds the SeatNumber
        /// </summary>
        private string _SeatNumber;
        #endregion

        #region Methods
        /// <summary>
        /// Sets / Get _PassengerId
        /// </summary>
        public string PassengerId
        {
            get
            {
                try
                {
                    return _PassengerId;
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
                    _PassengerId = value;
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
        public string PassengerFirstName
        {
            get
            {
                try
                {
                    return _PassengerFirstName;
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
                    _PassengerFirstName = value;
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
        public string PassengerLastName
        {
            get
            {
                try
                {
                    return _PassengerLastName;
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
                    _PassengerLastName = value;
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
        /// Overrides the ToString to print "_PassengerFirstName _PassengerLastName"
        /// </summary>
        /// <returns>The custom string</returns>
        /// <exception cref="Exception"></exception>
        public override string ToString()
        {
            try
            {
                return _PassengerFirstName + " " + _PassengerLastName; ;
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
