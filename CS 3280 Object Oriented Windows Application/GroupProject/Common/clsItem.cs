using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GroupProject.Common
{
    public class clsItem
    {
        private string _Code;
        private string _Description;
        private int _Cost;

        /// <summary>
        /// Get / Set item code
        /// </summary>
        public string Code
        {
            get
            {
                try
                {
                    return _Code;
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
                    _Code = value;
                }
                catch (Exception ex)
                {
                    throw new Exception(MethodBase.GetCurrentMethod().DeclaringType.Name + " . " +
                    MethodBase.GetCurrentMethod().Name + "->" + ex.Message);
                }
            }

        }


        /// <summary>
        /// Get / Set the description of the item
        /// </summary>
        public string Description
        {
            get
            {
                try
                {
                    return _Description;
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
                    _Description = value;
                }
                catch (Exception ex)
                {
                    throw new Exception(MethodBase.GetCurrentMethod().DeclaringType.Name + " . " +
                    MethodBase.GetCurrentMethod().Name + "->" + ex.Message);
                }
            }

        }

        /// <summary>
        /// Get / Set the cost of the item
        /// </summary>
        public int Cost
        {
            get
            {
                try
                {
                    return _Cost;
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
                    _Cost = value;
                }
                catch (Exception ex)
                {
                    throw new Exception(MethodBase.GetCurrentMethod().DeclaringType.Name + " . " +
                    MethodBase.GetCurrentMethod().Name + "->" + ex.Message);
                }
            }

        }

        /// <summary>
        /// Overrides the ToString to print "Description  Cost" 
        /// </summary>
        /// <returns>The custom string</returns>
        /// <exception cref="Exception">Throws the information about the method to the higher level methods</exception>
        public override string ToString()
        {
            try
            {
                return _Description;
            }
            catch (Exception ex)
            {

                throw new Exception(MethodBase.GetCurrentMethod().DeclaringType.Name + " . " +
                MethodBase.GetCurrentMethod().Name + "->" + ex.Message);
            }
        }

    }
}
