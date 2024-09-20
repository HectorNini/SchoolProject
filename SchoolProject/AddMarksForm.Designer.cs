namespace SchoolProject
{
    partial class AddMarksForm
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
            pupilComboBox = new ComboBox();
            lessonComboBox = new ComboBox();
            addButton = new Button();
            markComboBox = new ComboBox();
            SuspendLayout();
            // 
            // pupilComboBox
            // 
            pupilComboBox.FormattingEnabled = true;
            pupilComboBox.Location = new Point(12, 45);
            pupilComboBox.Name = "pupilComboBox";
            pupilComboBox.Size = new Size(279, 28);
            pupilComboBox.TabIndex = 10;
            // 
            // lessonComboBox
            // 
            lessonComboBox.FormattingEnabled = true;
            lessonComboBox.Location = new Point(12, 79);
            lessonComboBox.Name = "lessonComboBox";
            lessonComboBox.Size = new Size(279, 28);
            lessonComboBox.TabIndex = 9;
            // 
            // addButton
            // 
            addButton.BackColor = Color.FromArgb(250, 199, 72);
            addButton.Location = new Point(12, 111);
            addButton.Name = "addButton";
            addButton.Size = new Size(279, 29);
            addButton.TabIndex = 8;
            addButton.Text = "Добавить";
            addButton.UseVisualStyleBackColor = false;
            addButton.Click += addButton_Click;
            // 
            // markComboBox
            // 
            markComboBox.FormattingEnabled = true;
            markComboBox.Items.AddRange(new object[] { "2", "3", "4", "5" });
            markComboBox.Location = new Point(12, 11);
            markComboBox.Name = "markComboBox";
            markComboBox.Size = new Size(279, 28);
            markComboBox.TabIndex = 11;
            // 
            // AddMarksForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(131, 144, 250);
            ClientSize = new Size(301, 155);
            Controls.Add(markComboBox);
            Controls.Add(pupilComboBox);
            Controls.Add(lessonComboBox);
            Controls.Add(addButton);
            Name = "AddMarksForm";
            Text = "AddMarksForm";
            ResumeLayout(false);
        }

        #endregion
        private ComboBox pupilComboBox;
        private ComboBox lessonComboBox;
        private Button addButton;
        private ComboBox markComboBox;
    }
}