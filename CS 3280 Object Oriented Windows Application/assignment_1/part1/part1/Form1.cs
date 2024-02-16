namespace part1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Once Ok button is clicked it takes the string the user typed in OK textbox and displays it in an window
        /// with an question mark icon, yes and no buttons.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button1_Click(object sender, EventArgs e)
        {

            MessageBox.Show("You typed: " + txt_OKField.Text, "You clicked the OK button",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Once RetryCancel button is clicked it takes the string the user typed in RetryCancel textbox and displays
        /// it in an window with an warning icon, retry and cancel buttons.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("You typed: " + txt_RetryCancelField.Text, "" +
                "You clicked the Rety/Cancel button", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
        }

        /// <summary>
        /// Once YesNo button is clicked it takes the string the user typed in YesNo textbox and displays it in an window with
        /// an question mark icon, yes and no buttons. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Cmd_YesNo_Click(object sender, EventArgs e)
        {

            MessageBox.Show("You typed: " + txt_YesNoField.Text, "You clickd the Yes/No button",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }

    }
}
