using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace GroupProject.Search
{
    /// <summary>
    /// Interaction logic for wndSearch.xaml
    /// </summary>
    public partial class wndSearch : Window
    {
        /// <summary>
        /// wndMain object used as an accessor between windows.
        /// </summary>
        private wndMain mainWindow; 
        /// <summary>
        /// Constructor for the search window.
        /// </summary>
        public wndSearch(wndMain window)
        {
            InitializeComponent();
            this.mainWindow = window;
        }

        /// <summary>
        /// Selected InvoiceId is passed back to the main window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bttnSelect_Click(object sender, RoutedEventArgs e)
        {
           
        }

        /// <summary>
        /// Closes the search window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bttnCancel_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }
        /// <summary>
        /// Handles the errors.
        /// </summary>
        /// <param name="sClass"></param>
        /// <param name="sMethod"></param>
        /// <param name="sMessage"></param>
        private void HandleError(string sClass, string sMethod, string sMessage)
        {
            try
            {
                MessageBox.Show(sClass + "." + sMethod + " -> " + sMessage);
            }
            catch (System.Exception ex)
            {
                System.IO.File.AppendAllText(@"C:\Error.txt", Environment.NewLine + "HandleError Exception: " + ex.Message);
            }
        }
    }
}
