using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;
using GroupProject.Common;

namespace GroupProject
{
    public class clsMainLogic
    {

        #region Attributes

        /// <summary>
        /// Holds an object of errorHandler to handle any errors
        /// </summary>
        private errorHandler ErrorHandler;

        /// <summary>
        /// Holds an object of clsDataAccess to access the database
        /// </summary>
        private clsDataAccess DataBase;

        /// <summary>
        /// Holds a dataset of the items from the database
        /// </summary>
        private DataSet ItemData;

        /// <summary>
        /// Holds an object of clsMainSQL to handle all SQL statements
        /// </summary>
        private clsMainSQL SQLStatement;

        #endregion

        #region Methods

        /// <summary>
        /// Adds an invoice to the database
        /// </summary>
        /// <param name="totalCost">The total cost of the invoice</param>
        /// <param name="InvoiceDate">The date of the invoice</param>
        /// <exception cref="Exception">Throws the information about the method to the higher level methods</exception>
        private void CreateInvoice(string totalCost, string InvoiceDate)
        {
            try
            {
                DataBase.ExecuteNonQuery(SQLStatement.AddInvoice(InvoiceDate, totalCost));
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + " . " +
                MethodInfo.GetCurrentMethod().Name + "->" + ex.Message);
            }
        }

        /// <summary>
        /// Add an item to an invoice in the database
        /// </summary>
        /// <param name="InvoiceNum">The invoice number to add the items to</param>
        /// <param name="LineItemNum">The line number of the item</param>
        /// <param name="ItemCode">The Item code of the item</param>
        /// <exception cref="Exception">Throws the information about the method to the higher level methods</exception>
        private void AddItem(string InvoiceNum, string LineItemNum, string ItemCode)
        {
            try
            {
                DataBase.ExecuteNonQuery(SQLStatement.AddInvoiceItem(InvoiceNum, LineItemNum, ItemCode));
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + " . " +
                MethodInfo.GetCurrentMethod().Name + "->" + ex.Message);
            }
          
        }

        /// <summary>
        /// Create an object of clsItem from the database
        /// </summary>
        /// <param name="ItemData">The dataset containing the item data</param>
        /// <param name="RowNumber">The row that item is on</param>
        /// <returns>clsItem object created from database</returns>
        /// <exception cref="Exception">Throws the information about the method to the higher level methods</exception>
        private clsItem CreateItem(DataSet ItemData, int RowNumber)
        {
            try
            {
                clsItem Item = new clsItem();
                Item.Code = ItemData.Tables[0].Rows[RowNumber][0].ToString();
                Item.Description = ItemData.Tables[0].Rows[RowNumber][1].ToString();
                Item.Cost = int.Parse(ItemData.Tables[0].Rows[RowNumber][2].ToString());

                return Item;

            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + " . " +
                MethodInfo.GetCurrentMethod().Name + "->" + ex.Message);
            }

        }

        /// <summary>
        /// Deletes all the items related to an invoice
        /// </summary>
        /// <param name="InvoiceNum">The invoice that the items need to be deleted from</param>
        /// <exception cref="Exception">Throws the information about the method to the higher level methods</exception>
        private void DeleteItemsFromInvoice(string InvoiceNum)
        {
            try
            {
                DataBase.ExecuteNonQuery(SQLStatement.DeleteAllInvoiceItems(InvoiceNum));
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + " . " +
                MethodInfo.GetCurrentMethod().Name + "->" + ex.Message);
            }
            
        }
        /// <summary>
        /// Updates the total cost of in an invoice
        /// </summary>
        /// <param name="Invoice">The invoice number that needs the total cost updated</param>
        /// <exception cref="Exception">Throws the information about the method to the higher level methods</exception>
        private void UpdateTotalCost(clsInvoice Invoice)
        {
            try
            {
                DataBase.ExecuteNonQuery(SQLStatement.UpdateTotalCost(Invoice.TotalCost.ToString(), Invoice.Num));
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + " . " +
                MethodInfo.GetCurrentMethod().Name + "->" + ex.Message);
            }
        }

        /// <summary>
        /// Non default constructor for the clsMainLogic object
        /// </summary>
        /// <param name="errorHandler">Holds an object of errorHandler to handle any errors</param>
        /// <param name="Database">Holds an object clsDataAccess to access the database</param>
        /// <exception cref="Exception">Throws the information about the method to the higher level methods</exception>        
        public clsMainLogic(errorHandler errorHandler, clsDataAccess Database)
        {
            try
            {
                ErrorHandler = errorHandler;
                DataBase = Database;
                SQLStatement = new clsMainSQL();
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + " . " +
                MethodInfo.GetCurrentMethod().Name + "->" + ex.Message);
            }

        }

        /// <summary>
        /// Creates a list of clsItems for the wndMain to user
        /// </summary>
        /// <returns>A list of clsItems</returns>
        /// <exception cref="Exception">Throws the information about the method to the higher level methods</exception>
        public List<clsItem> GetItems() 
        {
            try
            {
                List<clsItem> ItemList = new List<clsItem>();
                int numOfRows = 0;

                ItemData = new DataSet();

                ItemData = DataBase.ExecuteSQLStatement(SQLStatement.GetItems(), ref numOfRows);

                if(ItemData != null)
                {
                    for (int i = 0; i < numOfRows; i++)
                    {
                        ItemList.Add(CreateItem(ItemData, i));

                    }
                }
                return ItemList;

            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + " . " +
                MethodInfo.GetCurrentMethod().Name + "->" + ex.Message);
            }
        }


        /// <summary>
        /// Saves an invoice to the database
        /// </summary>
        /// <param name="LineItems">ObservableCollection of clsItem objects that need to be added to the database</param>
        /// <param name="Invoice">clsInvoice object containing the information about the invoice</param>
        /// <returns>A string of the invoice number form the database</returns>
        /// <exception cref="Exception">Throws the information about the method to the higher level methods</exception>
        public string SaveInvoice(ObservableCollection<clsItem> LineItems, clsInvoice Invoice)
        {
            try
            {
                string InvoiceNumber;
                CreateInvoice(Invoice.TotalCost.ToString(), Invoice.Date);
                Invoice.Num = DataBase.ExecuteScalarSQL(SQLStatement.GetInvoiceNum());

                int LineItemCount = 1;

                foreach (clsItem LineItem in LineItems)
                {
                    AddItem(Invoice.Num, LineItemCount.ToString(), LineItem.Code);
                    LineItemCount++;
                }


                return Invoice.Num;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + " . " +
                MethodInfo.GetCurrentMethod().Name + "->" + ex.Message);
            }
        }

        /// <summary>
        /// Get a specific invoice from the database
        /// </summary>
        /// <param name="InvoiceNumber">The number of invoice that the data is needed for</param>
        /// <returns>clsInvoice object</returns>
        /// <exception cref="Exception">Throws the information about the method to the higher level methods</exception>
        public clsInvoice GetInvoice(string InvoiceNumber) 
        {
            try
            {
                clsInvoice Invoice = new clsInvoice();
                int RowCount = 0;

                DataSet InvoiceInfo = DataBase.ExecuteSQLStatement(SQLStatement.GetInvoice(InvoiceNumber), ref RowCount);

                if (InvoiceInfo != null)
                {
                    Invoice.Num = InvoiceInfo.Tables[0].Rows[0][0].ToString();
                    Invoice.Date = InvoiceInfo.Tables[0].Rows[0][1].ToString();
                    Invoice.TotalCost = int.Parse(InvoiceInfo.Tables[0].Rows[0][2].ToString());
                }

                return Invoice;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + " . " +
                MethodInfo.GetCurrentMethod().Name + "->" + ex.Message);
            }
        }

        /// <summary>
        /// Get all line items associated with an invoice
        /// </summary>
        /// <param name="InvoiceNumber">The invoice number of the invoice that that the items are needed for</param>
        /// <returns>ObservableCollection of clsItems</returns>
        /// <exception cref="Exception">Throws the information about the method to the higher level methods</exception>
        public ObservableCollection<clsItem> GetInvoiceLineItems(string InvoiceNumber)
        {
            try
            {
                int RowCount = 0;
                ObservableCollection<clsItem> LineItems = new ObservableCollection<clsItem>();
                DataSet LineItemsData = DataBase.ExecuteSQLStatement(SQLStatement.GetInvoiceItems(InvoiceNumber), ref RowCount);

                if (LineItemsData != null)
                {
                    for (int i = 0; i < RowCount; i++)
                    {
                        LineItems.Add(CreateItem(LineItemsData, i));
                    }

                    return LineItems;
                }

                return LineItems;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + " . " +
                MethodInfo.GetCurrentMethod().Name + "->" + ex.Message);
            }
  
            
        }

        /// <summary>
        /// Updates the total cost and line items for an invoice
        /// </summary>
        /// <param name="LineItems">ObservableCollection of clsItems that needed to be added to the database</param>
        /// <param name="Invoice">The invoice number of the invoice that needs to be updated</param>
        /// <exception cref="Exception">Throws the information about the method to the higher level methods</exception>
        public void UpdateInvoice(ObservableCollection<clsItem> LineItems, clsInvoice Invoice)
        {
            try
            {
                UpdateTotalCost(Invoice);

                DeleteItemsFromInvoice(Invoice.Num);
                int LineItemCount = 1;

                foreach (clsItem LineItem in LineItems)
                {
                    AddItem(Invoice.Num, LineItemCount.ToString(), LineItem.Code);
                    LineItemCount++;
                }

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
