using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GroupProject.Common
{
    public class clsInvoice
    {
        /// <summary>
        /// The Invoices number
        /// </summary>
        private string _Num;

        /// <summary>
        /// The date of the invoice
        /// </summary>
        private string _Date;

        /// <summary>
        /// The total cost of the invoice
        /// </summary>
        private int _TotalCost;

        /// <summary>
        /// Get / Set for the invoice number
        /// </summary>
        public string Num
        {
            get
            {
                try
                {
                    return _Num;
                }
                catch (Exception ex)
                {
                    throw new Exception(MethodBase.GetCurrentMethod().DeclaringType.Name + " . " +
                    MethodBase.GetCurrentMethod().Name + "->" + ex.Message);
                }

            }
            set
            {
                try
                {
                    _Num = value;
                }
                catch (Exception ex)
                {
                    throw new Exception(MethodBase.GetCurrentMethod().DeclaringType.Name + " . " +
                    MethodBase.GetCurrentMethod().Name + "->" + ex.Message);
                }
            }

        }

        /// <summary>
        /// Get / Set for the invoice date
        /// </summary>
        public string Date
        {
            get
            {
                try
                {
                    return _Date;
                }
                catch (Exception ex)
                {
                    throw new Exception(MethodBase.GetCurrentMethod().DeclaringType.Name + " . " +
                    MethodBase.GetCurrentMethod().Name + "->" + ex.Message);
                }

            }
            set
            {
                try
                {
                    _Date = value;
                }
                catch (Exception ex)
                {
                    throw new Exception(MethodBase.GetCurrentMethod().DeclaringType.Name + " . " +
                    MethodBase.GetCurrentMethod().Name + "->" + ex.Message);
                }
            }
        }

        /// <summary>
        /// Get / Set for the total cost of the invoice
        /// </summary>
        public int TotalCost
        {
            get
            {
                try
                {
                    return _TotalCost;
                }
                catch (Exception ex)
                {
                    throw new Exception(MethodBase.GetCurrentMethod().DeclaringType.Name + " . " +
                    MethodBase.GetCurrentMethod().Name + "->" + ex.Message);
                }

            }
            set
            {
                try
                {
                    _TotalCost = value;
                }
                catch (Exception ex)
                {
                    throw new Exception(MethodBase.GetCurrentMethod().DeclaringType.Name + " . " +
                    MethodBase.GetCurrentMethod().Name + "->" + ex.Message);
                }
            }

        }

        /// <summary>
        /// Creates an object of where all values and settable
        /// </summary>
        /// <param name="num"> String: The invoice number</param>
        /// <param name="date"> String: The date of the invoice</param>
        /// <param name="totalCost"> Int: TotalCost</param>
        /// <exception cref="Exception">Throws the information about the method to the higher level methods</exception>
        public clsInvoice(string num, string date, int totalCost)
        {
            try
            {
                Num = num;
                Date = date;
                TotalCost = totalCost;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodBase.GetCurrentMethod().DeclaringType.Name + " . " +
                MethodBase.GetCurrentMethod().Name + "->" + ex.Message);
            }

        }

        /// <summary>
        /// Creates an invoice with Date and TotalCost settable
        /// </summary>
        /// <param name="date"> String: The date of the invoice</param>
        /// <param name="totalCost"> Int: TotalCost</param>
        /// <exception cref="Exception">Throws the information about the method to the higher level methods</exception>
        public clsInvoice(string date, int totalCost)
        {
            try
            {
                Num = string.Empty;
                Date = date;
                TotalCost = totalCost;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodBase.GetCurrentMethod().DeclaringType.Name + " . " +
                MethodBase.GetCurrentMethod().Name + "->" + ex.Message);
            }
        }

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <exception cref="Exception">Throws the information about the method to the higher level methods</exception>
        public clsInvoice()
        {
            try
            {

            }
            catch (Exception ex)
            {
                throw new Exception(MethodBase.GetCurrentMethod().DeclaringType.Name + " . " +
                MethodBase.GetCurrentMethod().Name + "->" + ex.Message);
            }
        }
    }
}
