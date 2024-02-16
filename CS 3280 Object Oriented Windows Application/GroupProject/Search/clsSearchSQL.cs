using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace GroupProject.Search
{
    /// <summary>
    /// Class that contains all the sql statements used
    /// for the search window.
    /// </summary>
    public class clsSearchSQL
    {
        /// <summary>
        /// Gets all the invoices.
        /// </summary>
        /// <returns></returns>
        public string getInvoices()
        {
            string sSql = "SELECT * FROM invoices";
            return sSql;
        }

        /// <summary>
        /// Gets the dates.
        /// </summary>
        /// <returns></returns>
        public string getDates()
        {
            string sSql = "SELECT DISTINCT(InvoiceDate) FROM Invoices order by InvoiceDate";
            return sSql;
        }

        /// <summary>
        /// Gets the total cost.
        /// </summary>
        /// <returns></returns>
        public string getCosts()
        {
            string sSql = "SELECT DISTINCT(TotalCost) FROM invoices order by TotalCost";
            return sSql;
        }

        /// <summary>
        /// Get search invoices.
        /// </summary>
        /// <param name="invoiceNum">Invoice Number</param>
        /// <param name="invoiceDate">Invoice Date</param>
        /// <param name="totalCost">Total Cost</param>
        /// <returns></returns>
        public string GetSearchInvoice(string invoiceNum = "", string invoiceDate = "", string totalCost = "")
        {
            try
            {
                invoiceNum = (invoiceNum == "All") ? "" : invoiceNum;
                invoiceDate = (invoiceDate == "All") ? "" : invoiceDate;
                totalCost = (totalCost == "All") ? "" : totalCost;

                string sql = "SELECT * FROM Invoices";

                if (invoiceNum != String.Empty || invoiceDate != String.Empty || totalCost != String.Empty)
                {
                    sql += " WHERE";
                }

                if (invoiceNum != String.Empty)
                {
                    sql += String.Format(" InvoiceNum = {0}", invoiceNum);
                }

                if (invoiceNum != String.Empty && invoiceDate != String.Empty)
                {
                    sql += " AND";
                }

                if (invoiceDate != String.Empty)
                {
                    sql += String.Format(" InvoiceDate = #{0}#", invoiceDate);
                }

                if (invoiceDate != String.Empty && totalCost != String.Empty)
                {
                    sql += " AND";
                }

                if (totalCost != String.Empty)
                {
                    sql += String.Format(" TotalCost = {0}", totalCost);
                }
                return sql;
            }
            catch (Exception ex)
            {
                throw new Exception(ExceptionChain(MethodInfo.GetCurrentMethod(), ex));
            }
        }

        /// <summary>
        /// Returns error info as a string in a consistent format to make debugging easier
        /// </summary>
        /// <param name="mb"></param>
        /// <param name="ex"></param>
        /// <returns></returns>
        private string ExceptionChain(MethodBase mb, Exception ex)
        {
            return string.Format("{0}.{1}->{2}", mb.DeclaringType.Name, mb.Name, ex.Message);
        }
    }
}

