namespace part1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            cmd_OKClick = new Button();
            cmd_Retry_Cancel = new Button();
            cmd_YesNo = new Button();
            txt_OKField = new TextBox();
            txt_RetryCancelField = new TextBox();
            txt_YesNoField = new TextBox();
            lbl_Ok = new Label();
            lbl_RetryCancel = new Label();
            lbl_YesNo = new Label();
            SuspendLayout();
            // 
            // cmd_OKClick
            // 
            cmd_OKClick.Location = new Point(181, 67);
            cmd_OKClick.Name = "cmd_OKClick";
            cmd_OKClick.Size = new Size(75, 23);
            cmd_OKClick.TabIndex = 0;
            cmd_OKClick.Text = "OK";
            cmd_OKClick.UseVisualStyleBackColor = true;
            cmd_OKClick.Click += Button1_Click;
            // 
            // cmd_Retry_Cancel
            // 
            cmd_Retry_Cancel.Location = new Point(181, 170);
            cmd_Retry_Cancel.Name = "cmd_Retry_Cancel";
            cmd_Retry_Cancel.Size = new Size(99, 23);
            cmd_Retry_Cancel.TabIndex = 1;
            cmd_Retry_Cancel.Text = "Retry Cancel";
            cmd_Retry_Cancel.UseVisualStyleBackColor = true;
            cmd_Retry_Cancel.Click += Button2_Click;
            // 
            // cmd_YesNo
            // 
            cmd_YesNo.Location = new Point(181, 257);
            cmd_YesNo.Name = "cmd_YesNo";
            cmd_YesNo.Size = new Size(75, 23);
            cmd_YesNo.TabIndex = 2;
            cmd_YesNo.Text = "Yes No";
            cmd_YesNo.UseVisualStyleBackColor = true;
            cmd_YesNo.Click += Cmd_YesNo_Click;
            // 
            // txt_OKField
            // 
            txt_OKField.Location = new Point(22, 68);
            txt_OKField.Name = "txt_OKField";
            txt_OKField.Size = new Size(124, 23);
            txt_OKField.TabIndex = 3;
            // 
            // txt_RetryCancelField
            // 
            txt_RetryCancelField.Location = new Point(22, 170);
            txt_RetryCancelField.Name = "txt_RetryCancelField";
            txt_RetryCancelField.Size = new Size(124, 23);
            txt_RetryCancelField.TabIndex = 4;
            // 
            // txt_YesNoField
            // 
            txt_YesNoField.Location = new Point(22, 257);
            txt_YesNoField.Name = "txt_YesNoField";
            txt_YesNoField.Size = new Size(124, 23);
            txt_YesNoField.TabIndex = 5;
            // 
            // lbl_Ok
            // 
            lbl_Ok.AutoSize = true;
            lbl_Ok.Location = new Point(22, 23);
            lbl_Ok.Name = "lbl_Ok";
            lbl_Ok.Size = new Size(412, 30);
            lbl_Ok.TabIndex = 6;
            lbl_Ok.Text = "Click this button and the message in corresponding textbox will be displayed\nin a window" +
                          " with an OK button and an information icon.";
            // 
            // lbl_RetryCancel
            // 
            lbl_RetryCancel.AutoSize = true;
            lbl_RetryCancel.Location = new Point(22, 119);
            lbl_RetryCancel.Name = "lbl_RetryCancel";
            lbl_RetryCancel.Size = new Size(412, 30);
            lbl_RetryCancel.TabIndex = 7;
            lbl_RetryCancel.Text = "Click this button and the message in corresponding textbox will be displayed\nin" +
                                   " a window with a Retry and Cancel buttons and a wanring icon.";
            // 
            // lbl_YesNo
            // 
            lbl_YesNo.AutoSize = true;
            lbl_YesNo.Location = new Point(22, 215);
            lbl_YesNo.Name = "lbl_YesNo";
            lbl_YesNo.Size = new Size(412, 30);
            lbl_YesNo.TabIndex = 8;
            lbl_YesNo.Text = "Click this button and the message in corresponding textbox will be displayed\nin an " +
                             "window whith an Yes and No buttons and a question mark.";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(448, 313);
            Controls.Add(lbl_YesNo);
            Controls.Add(lbl_RetryCancel);
            Controls.Add(lbl_Ok);
            Controls.Add(txt_YesNoField);
            Controls.Add(txt_RetryCancelField);
            Controls.Add(txt_OKField);
            Controls.Add(cmd_YesNo);
            Controls.Add(cmd_Retry_Cancel);
            Controls.Add(cmd_OKClick);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button cmd_OKClick;
        private Button cmd_Retry_Cancel;
        private Button cmd_YesNo;
        private TextBox txt_OKField;
        private TextBox txt_RetryCancelField;
        private TextBox txt_YesNoField;
        private Label lbl_Ok;
        private Label lbl_RetryCancel;
        private Label lbl_YesNo;
    }
}