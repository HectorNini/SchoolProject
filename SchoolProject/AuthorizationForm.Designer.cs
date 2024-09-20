namespace SchoolProject
{
    partial class AuthorizationForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            passwordTextBox = new TextBox();
            loginTextBox = new TextBox();
            enterButton = new Button();
            nameLabel = new Label();
            SuspendLayout();
            // 
            // passwordTextBox
            // 
            passwordTextBox.BackColor = Color.FromArgb(241, 227, 243);
            passwordTextBox.Location = new Point(296, 240);
            passwordTextBox.Name = "passwordTextBox";
            passwordTextBox.Size = new Size(181, 27);
            passwordTextBox.TabIndex = 0;
            // 
            // loginTextBox
            // 
            loginTextBox.BackColor = Color.FromArgb(241, 227, 243);
            loginTextBox.Location = new Point(296, 207);
            loginTextBox.Name = "loginTextBox";
            loginTextBox.Size = new Size(181, 27);
            loginTextBox.TabIndex = 1;
            // 
            // enterButton
            // 
            enterButton.BackColor = Color.FromArgb(250, 199, 72);
            enterButton.Location = new Point(296, 325);
            enterButton.Name = "enterButton";
            enterButton.Size = new Size(181, 29);
            enterButton.TabIndex = 2;
            enterButton.Text = "Вход";
            enterButton.UseVisualStyleBackColor = false;
            enterButton.Click += enterButton_Click;
            // 
            // nameLabel
            // 
            nameLabel.AutoSize = true;
            nameLabel.Location = new Point(330, 135);
            nameLabel.Name = "nameLabel";
            nameLabel.RightToLeft = RightToLeft.No;
            nameLabel.Size = new Size(105, 20);
            nameLabel.TabIndex = 3;
            nameLabel.Text = "МБОУ «СОШ»";
            // 
            // AuthorizationForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(131, 144, 250);
            ClientSize = new Size(800, 450);
            Controls.Add(nameLabel);
            Controls.Add(enterButton);
            Controls.Add(loginTextBox);
            Controls.Add(passwordTextBox);
            Name = "AuthorizationForm";
            Text = "AuthorizationForm";
            Load += AuthorizationForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox passwordTextBox;
        private TextBox loginTextBox;
        private Button enterButton;
        private Label nameLabel;
    }
}