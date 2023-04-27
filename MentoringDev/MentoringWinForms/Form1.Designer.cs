namespace MentoringWinForms
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
            outputLabel = new Label();
            UsernameLabel = new Label();
            tbUsername = new TextBox();
            okButton = new Button();
            errorLabel = new Label();
            SuspendLayout();
            // 
            // outputLabel
            // 
            outputLabel.AutoSize = true;
            outputLabel.Location = new Point(411, 226);
            outputLabel.Name = "outputLabel";
            outputLabel.Size = new Size(50, 20);
            outputLabel.TabIndex = 0;
            outputLabel.Text = "label1";
            outputLabel.Visible = false;
            // 
            // UsernameLabel
            // 
            UsernameLabel.AutoSize = true;
            UsernameLabel.Location = new Point(125, 95);
            UsernameLabel.Name = "UsernameLabel";
            UsernameLabel.Size = new Size(75, 20);
            UsernameLabel.TabIndex = 1;
            UsernameLabel.Text = "Username";
            // 
            // tbUsername
            // 
            tbUsername.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tbUsername.Location = new Point(125, 128);
            tbUsername.Name = "tbUsername";
            tbUsername.Size = new Size(630, 27);
            tbUsername.TabIndex = 2;
            // 
            // okButton
            // 
            okButton.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            okButton.Location = new Point(378, 312);
            okButton.Name = "okButton";
            okButton.Size = new Size(127, 52);
            okButton.TabIndex = 3;
            okButton.Text = "OK";
            okButton.UseVisualStyleBackColor = true;
            okButton.Click += okButton_Click;
            // 
            // errorLabel
            // 
            errorLabel.AutoSize = true;
            errorLabel.Location = new Point(411, 47);
            errorLabel.Name = "errorLabel";
            errorLabel.Size = new Size(41, 20);
            errorLabel.TabIndex = 4;
            errorLabel.Text = "Error";
            errorLabel.Visible = false;
            errorLabel.ForeColor = System.Drawing.Color.Red;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(842, 510);
            Controls.Add(errorLabel);
            Controls.Add(okButton);
            Controls.Add(tbUsername);
            Controls.Add(UsernameLabel);
            Controls.Add(outputLabel);
            Name = "Form1";
            Text = "Hello User";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label outputLabel;
        private Label UsernameLabel;
        private TextBox tbUsername;
        private Button okButton;
        private Label errorLabel;
    }
}