using GroupProject.Common;
using GroupProject.Search;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace GroupProject
{
    /// <summary>
    /// Interaction logic for wndMain.xaml
    /// </summary>
    public partial class wndMain : Window
    {

        #region Attributes

        /// <summary>
        /// Holds an object of wndSearch to open 
        /// </summary>
        private wndSearch SearchWindow;

        /// <summary>
        /// Holds an object of DataBase to pass into other class
        /// </summary>
        private clsDataAccess DataBase;

        /// <summary>
        /// Holds an object of MainLogic that performs the logic for wndMain
        /// </summary>
        private clsMainLogic MainLogic;

        /// <summary>
        /// List of clsItem used for the cbx_ItemList
        /// </summary>
        private List<clsItem> ItemList;

        /// <summary>
        /// ObservableCollection of clsItem used for dt_LineItems
        /// </summary>
        private ObservableCollection<clsItem> LineItems;

        /// <summary>
        /// Holds an object of errorHandler handles any exceptions
        /// </summary>
        public errorHandler errorHandler;

        /// <summary>
        /// The the invoice number of the passed in invoice from wndSearch
        /// </summary>
        public string InvoiceID;

        /// <summary>
        /// Informs that wndMain that a invoice was selected from wndSearch
        /// </summary>
        public bool InvoiceSelected;

        #endregion

        #region Methods

        /// <summary>
        /// Gets the list of clsItems from MainLogic and becomes the item source for cbx_ItemList
        /// </summary>
        /// <exception cref="Exception">Throws the information about the method to the higher level methods</exception>
        void GetItemList()
        {
            try
            {
                ItemList = new List<clsItem>();
                ItemList = MainLogic.GetItems();
                cbx_ItemList.ItemsSource = ItemList;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + " . " +
                MethodInfo.GetCurrentMethod().Name + "->" + ex.Message);
            }

        }

        /// <summary>
        /// Gets the current item selected in cbx_ItemList
        /// </summary>
        /// <returns>Returns the current clsItem object</returns>
        /// <exception cref="Exception">Throws the information about the method to the higher level methods</exception>
        private clsItem SelectedItem()
        {
            try
            {
                return (clsItem)cbx_ItemList.SelectedItem;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + " . " +
                MethodInfo.GetCurrentMethod().Name + "->" + ex.Message);
            }
            
        }

        /// <summary>
        /// Updates total cost text box with the current total cost of what is in LineItems
        /// </summary>
        /// <exception cref="Exception">Throws the information about the method to the higher level methods</exception>
        private void UpdateTotalCost()
        {
            try
            {
                int TotalCost = 0;

                foreach (clsItem Items in LineItems)
                {
                    TotalCost += Items.Cost;
                }

                txt_TotalCost.Text = TotalCost.ToString() + ".00";

            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + " . " +
                MethodInfo.GetCurrentMethod().Name + "->" + ex.Message);
            }

        }

        /// <summary>
        /// Turns on the needed UI elements and turns off ones that are not needed
        /// </summary>
        /// <exception cref="Exception">Throws the information about the method to the higher level methods</exception>
        private void ReadOnlyMode()
        {
            try
            {
                cmd_EditInvoice.IsEnabled = true;
                cmd_NewInvoice.IsEnabled = true;

                dp_InvoiceDate.IsEnabled = false;
                cmd_AddItem.IsEnabled = false;
                cmd_SaveInvoice.IsEnabled = false;
                cmd_deleteItem.IsEnabled = false;
                cbx_ItemList.IsEnabled = false;
                dt_LineItems.IsEnabled = false;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + " . " +
                MethodInfo.GetCurrentMethod().Name + "->" + ex.Message);
            }

        }

        /// <summary>
        /// Turns on the needed UI elements and turns off ones that are not needed
        /// </summary>
        /// <exception cref="Exception">Throws the information about the method to the higher level methods</exception>
        private void EditMode()
        {
            try
            {
                cmd_EditInvoice.IsEnabled = false;
                cmd_NewInvoice.IsEnabled = false;
                dp_InvoiceDate.IsEnabled = false;

                cmd_SaveInvoice.IsEnabled = true;
                cbx_ItemList.IsEnabled = true;
                dt_LineItems.IsEnabled = true;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + " . " +
                MethodInfo.GetCurrentMethod().Name + "->" + ex.Message);
            }


        }

        /// <summary>
        /// Gets the date in form of Month/Date/Year
        /// </summary>
        /// <returns>A formatted string of the date</returns>
        /// <exception cref="Exception">Throws the information about the method to the higher level methods</exception>
        private string GetDate()
        {
            try
            {
                return dp_InvoiceDate.SelectedDate.Value.Date.ToString("MM/dd/yyyy"); ;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + " . " +
                MethodInfo.GetCurrentMethod().Name + "->" + ex.Message);
            }

        }

        /// <summary>
        /// Gets the total cost and makes it into an int
        /// </summary>
        /// <returns>An int version of TotalCost</returns>
        /// <exception cref="Exception">Throws the information about the method to the higher level methods</exception>
        private int GetTotalCost()
        {
            try
            {
                return int.Parse(txt_TotalCost.Text.Substring(0, txt_TotalCost.Text.LastIndexOf(".")));
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + " . " +
                MethodInfo.GetCurrentMethod().Name + "->" + ex.Message);
            }

            
        }

        /// <summary>
        /// Checks to see if all the fields have been entered
        /// Displays error labels if the field are empty
        /// </summary>
        /// <returns>True if they are field out false if not</returns>
        /// <exception cref="Exception"></exception>
        private bool AllFields()
        {
            try
            {
                bool DateEntered = false;
                bool ItemsEntered = false;

                if (dp_InvoiceDate.Text == string.Empty)
                {
                    lbl_Nodate.Visibility = Visibility.Visible;
                }
                else
                {
                    lbl_Nodate.Visibility = Visibility.Hidden;
                    DateEntered = true;
                }

                if (LineItems.Count == 0)
                {
                    lbl_NoItems.Visibility = Visibility.Visible;
                }
                else
                {
                    lbl_NoItems.Visibility = Visibility.Hidden;
                    ItemsEntered = true;
                }

                if (ItemsEntered && DateEntered)
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

        #endregion

        /*
         * Once the user clicks Search menu from the Invoice menu what well happen is...
         * 1) Create an object of wndSearch 
         * 2) Pass in the wndMain object to its wndMain attribute
         * 3) Than calls wndSearch.ShowDialog to open the window.
         *  Before the searchWnd closes it will update the two attributes
         *  InvoiceID and InvoiceSelected in wndMain
         *  4) If invoiceSelected is true we can pull the info for the passed in InvoiceID and pass that to clsMainLogic 
         *      to get the info needed to update wndMain.
         *  5) if InvoiceSelected is false than the wndMain wont update.
         */

        /// <summary>
        /// The constructor for the wndMain class
        /// Sets up objects needed for wndMain
        /// </summary>
        public wndMain()
        {
            try
            {
                InitializeComponent();

                Application.Current.ShutdownMode = ShutdownMode.OnMainWindowClose;

                errorHandler = new errorHandler();
                DataBase = new clsDataAccess();
                MainLogic = new clsMainLogic(errorHandler, DataBase);
                InvoiceSelected = false;

                GetItemList();
            }
            catch (Exception ex)
            {
                errorHandler.logError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);
            }

        }

        /// <summary>
        /// Create and opens wndSearch and sets up the main window accordingly if an invoice was selected
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpenSearch(object sender, RoutedEventArgs e)
        {
            try
            {
                SearchWindow = new wndSearch(this);
                SearchWindow.ShowDialog();

                ReadOnlyMode();
                InvoiceSelected = true;
                InvoiceID = "5000";

                if (InvoiceSelected)
                {

                    clsInvoice EditedInvoice = MainLogic.GetInvoice(InvoiceID);
                    LineItems = MainLogic.GetInvoiceLineItems(InvoiceID);
                    dt_LineItems.ItemsSource = LineItems;
                    cbx_ItemList.SelectedIndex = -1;
                    txt_CostOfItem.Text = string.Empty;
                    txt_TotalCost.Text = EditedInvoice.TotalCost.ToString() + ".00";
                    dp_InvoiceDate.Text = EditedInvoice.Date;
                    txt_InvoiceNum.Text = InvoiceID;


                }
            }
            catch (Exception ex)
            {
                errorHandler.logError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// Gets the current clsItem and updates the txt_CostOfItem
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ItemChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                cmd_AddItem.IsEnabled = true;
                clsItem Item = SelectedItem();
                cmd_deleteItem.IsEnabled = false;

                if (cbx_ItemList.SelectedIndex >= 0)
                {
                    txt_CostOfItem.Text = Item.Cost.ToString() + ".00";
                }
            }
            catch (Exception ex)
            {
                errorHandler.logError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// Adds the current clsItem object from cb_ItemList and stores in into LineItems
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmd_AddItem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (cbx_ItemList.SelectedItem != null)
                {
                    lbl_NoItems.Visibility = Visibility.Hidden;
                    cmd_deleteItem.IsEnabled = false;
                    clsItem Item = SelectedItem();
                    LineItems.Add(Item);
                    UpdateTotalCost();
                }
            }
            catch (Exception ex)
            {
                errorHandler.logError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// Verifies with the user and then it removes the item from LineItems
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmd_deleteItem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (dt_LineItems.SelectedItem != null)
                {
                    MessageBoxResult answer = MessageBox.Show("Are you sure you want to delete the passenger?", "Confirmation",
                                                                  MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (answer == MessageBoxResult.Yes)
                    {
                        clsItem DeletedItem = dt_LineItems.SelectedItem as clsItem;
                        LineItems.Remove(DeletedItem);
                        UpdateTotalCost();

                        cmd_deleteItem.IsEnabled = false;
                    }
                }
            }
            catch (Exception ex)
            {
                errorHandler.logError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// Enables the delete item button when dt_LineItem gets focus
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dt_LineItems_GotFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                cmd_deleteItem.IsEnabled = true;
            }
            catch (Exception ex)
            {
                errorHandler.logError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
 
        }

        /// <summary>
        /// Saves the invoice to the database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmd_SaveInvoice_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (AllFields())
                {
                    if (!InvoiceSelected)
                    {
                        clsInvoice NewInvoice = new clsInvoice(GetDate(), GetTotalCost());

                        txt_InvoiceNum.Text = MainLogic.SaveInvoice(LineItems, NewInvoice);
                        ReadOnlyMode();
                    }
                    else
                    {
                        clsInvoice NewInvoice = new clsInvoice(txt_InvoiceNum.Text, GetDate(), GetTotalCost());

                        MainLogic.UpdateInvoice(LineItems, NewInvoice);

                        ReadOnlyMode();
                    }
                }
            }
            catch (Exception ex)
            {
                errorHandler.logError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// Gets the wndMain ready for the user to edit an invoice
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmd_EditInvoice_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                EditMode();
                cbx_ItemList.SelectedIndex = -1;
                txt_CostOfItem.Text = string.Empty;
                dp_InvoiceDate.IsEnabled = false;
            }
            catch (Exception ex)
            {
                errorHandler.logError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// Gets the wndMain ready for the user to enter in a new invoice
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmd_NewInvoice_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                EditMode();
                LineItems = new ObservableCollection<clsItem>();
                dt_LineItems.ItemsSource = LineItems;
                InvoiceSelected = false;


                dp_InvoiceDate.IsEnabled = true;
                dp_InvoiceDate.Text = string.Empty;
                txt_CostOfItem.Text = string.Empty;
                txt_TotalCost.Text = string.Empty;
                txt_InvoiceNum.Text = "TBD";
                cbx_ItemList.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                errorHandler.logError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
            
        }

        /// <summary>
        /// Disables delete item button and hides the error date label
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dp_InvoiceDate_GotFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                cmd_deleteItem.IsEnabled = false;
                lbl_Nodate.Visibility = Visibility.Hidden;
            }
            catch (Exception ex)
            {
                errorHandler.logError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

    }
}
