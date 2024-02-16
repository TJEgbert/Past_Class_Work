using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GroupProject
{
    class clsMainSQL
    {

        /// <summary>
        /// This SQL statement get all items in ItemDesc table
        /// </summary>
        /// <returns>A string of the SQl statement</returns>
        /// <exception cref="Exception">Throws the information about the method to the higher level methods</exception>
        public string GetItems()
        {
            try
            {
                string SQLString;
                SQLString = "SELECT ItemCode, ItemDesc, Cost FROM ItemDesc";

                return SQLString;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + " . " +
                MethodInfo.GetCurrentMethod().Name + "->" + ex.Message);
            }

        }

        /// <summary>
        /// This SQL statement deletes all the items associated with an invoice 
        /// </summary>
        /// <param name="InvoiceNum">The number of the invoice to update</param>
        /// <returns>A string of the SQl statement</returns>
        /// <exception cref="Exception">Throws the information about the method to the higher level methods</exception>
        public string DeleteAllInvoiceItems(string InvoiceNum)
        {
            try
            {
                string SQLString;
                SQLString = "DELETE From LineItems WHERE InvoiceNum =" + InvoiceNum;

                return SQLString;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + " . " +
                MethodInfo.GetCurrentMethod().Name + "->" + ex.Message);
            }

        }

        /// <summary>
        /// This SQL statement updates the total cost to an invoice
        /// </summary>
        /// <param name="TotalCost">The new total</param>
        /// <param name="InvoiceNum">The number of the invoice to update</param>
        /// <returns>A string of the SQl statement</returns>
        /// <exception cref="Exception">Throws the information about the method to the higher level methods</exception>
        public string UpdateTotalCost(string TotalCost, string InvoiceNum)
        {
            try
            {
                string SQLString;
                SQLString = "UPDATE Invoices SET TotalCost = " + TotalCost + " WHERE InvoiceNum = " + InvoiceNum;

                return SQLString;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + " . " +
                MethodInfo.GetCurrentMethod().Name + "->" + ex.Message);
            }

        }


        /// <summary>
        /// This SQL statement adds an item to an invoice
        /// </summary>
        /// <param name="InvoiceNum">The number of the invoice to add the item to</param>
        /// <param name="LineItemNum">The line number of the item</param>
        /// <param name="ItemCode">The item code of the item to be added</param>
        /// <returns>A string of the SQl statement</returns>
        /// <exception cref="Exception">Throws the information about the method to the higher level methods</exception>
        public string AddInvoiceItem(string InvoiceNum, string LineItemNum, string ItemCode) 
        {
            try
            {

                string SQLString;
                SQLString = "INSERT INTO LineItems (InvoiceNum, LineItemNum, ItemCode) Values(" + InvoiceNum + ", " + LineItemNum + ", " + "'" + ItemCode + "'" + ")";

                return SQLString;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + " . " +
                MethodInfo.GetCurrentMethod().Name + "->" + ex.Message);
            }

        }

        /// <summary>
        /// This SQL statement creates the invoice and adds it to the database
        /// </summary>
        /// <param name="InvoiceDate">The date of the invoice</param>
        /// <param name="TotalCost">The total cost of the items</param>
        /// <returns>A string of the SQl statement</returns>
        /// <exception cref="Exception">Throws the information about the method to the higher level methods</exception>
        public string AddInvoice(string InvoiceDate, string TotalCost)
        {
            try
            {
                string SQLString;
                SQLString = "INSERT INTO Invoices (InvoiceDate, TotalCost) Values(#" + InvoiceDate + "#," + TotalCost + ")";

                return SQLString;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + " . " +
                MethodInfo.GetCurrentMethod().Name + "->" + ex.Message);
            }

        }

        /// <summary>
        /// This SQL statement gets an invoice with its related information
        /// </summary>
        /// <param name="InvoiceNum">The number of the invoice</param>
        /// <returns>A string of the SQl statement</returns>
        /// <exception cref="Exception">Throws the information about the method to the higher level methods</exception>
        public string GetInvoice(string InvoiceNum) 
        {
            try
            {
                string SQLString;
                SQLString = "SELECT InvoiceNum, InvoiceDate, TotalCost FROM Invoices WHERE InvoiceNum = " + InvoiceNum;

                return SQLString;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + " . " +
                MethodInfo.GetCurrentMethod().Name + "->" + ex.Message);
            }
        }

        /// <summary>
        /// This SQL statements gets all the items associated with an invoice
        /// </summary>
        /// <param name="InvoiceNum">The number of the invoice</param>
        /// <returns>A string of the SQl statement</returns>
        ///<exception cref = "Exception" > Throws the information about the method to the higher level methods</exception>
        public string GetInvoiceItems(string InvoiceNum)
        {
            try
            {
                string SQLString;
                SQLString = "SELECT LineItems.ItemCode, ItemDesc.ItemDesc, ItemDesc.Cost FROM LineItems, ItemDesc Where LineItems.ItemCode = ItemDesc.ItemCode And LineItems.InvoiceNum = " + InvoiceNum;

                return SQLString;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + " . " +
                MethodInfo.GetCurrentMethod().Name + "->" + ex.Message);
            }

        }

        /// <summary>
        /// This SQL statement returns the Max number of invoice
        /// Note: Use after the new invoice has been created
        /// </summary>
        /// <returns>A string of the SQl statement</returns>
        /// <exception cref="Exception">Throws the information about the method to the higher level methods</exception>
        public string GetInvoiceNum()
        {
            try
            {
                string SQLString;
                SQLString = "SELECT MAX(InvoiceNum) FROM Invoices";

                return SQLString;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + " . " +
                MethodInfo.GetCurrentMethod().Name + "->" + ex.Message);
            }
        }
    }
}
