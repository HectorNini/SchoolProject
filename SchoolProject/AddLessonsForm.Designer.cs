namespace SchoolProject
{
    partial class AddLessonsForm
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
            addButton = new Button();
            classComboBox = new ComboBox();
            subjectComboBox = new ComboBox();
            datePicker = new DateTimePicker();
            timePicker = new DateTimePicker();
            SuspendLayout();
            // 
            // addButton
            // 
            addButton.BackColor = Color.FromArgb(250, 199, 72);
            addButton.Location = new Point(12, 111);
            addButton.Name = "addButton";
            addButton.Size = new Size(279, 29);
            addButton.TabIndex = 3;
            addButton.Text = "Добавить";
            addButton.UseVisualStyleBackColor = false;
            addButton.Click += addButton_Click;
            // 
            // classComboBox
            // 
            classComboBox.FormattingEnabled = true;
            classComboBox.Location = new Point(12, 79);
            classComboBox.Name = "classComboBox";
            classComboBox.Size = new Size(279, 28);
            classComboBox.TabIndex = 4;
            // 
            // subjectComboBox
            // 
            subjectComboBox.FormattingEnabled = true;
            subjectComboBox.Location = new Point(12, 45);
            subjectComboBox.Name = "subjectComboBox";
            subjectComboBox.Size = new Size(279, 28);
            subjectComboBox.TabIndex = 5;
            // 
            // datePicker
            // 
            datePicker.Location = new Point(12, 12);
            datePicker.Name = "datePicker";
            datePicker.Size = new Size(182, 27);
            datePicker.TabIndex = 6;
            // 
            // timePicker
            // 
            timePicker.Location = new Point(200, 12);
            timePicker.Name = "timePicker";
            timePicker.Size = new Size(91, 27);
            timePicker.TabIndex = 7;
            // 
            // AddLessonsForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(131, 144, 250);
            ClientSize = new Size(303, 162);
            Controls.Add(timePicker);
            Controls.Add(datePicker);
            Controls.Add(subjectComboBox);
            Controls.Add(classComboBox);
            Controls.Add(addButton);
            Name = "AddLessonsForm";
            ResumeLayout(false);
        }

        #endregion
        private Button addButton;
        private ComboBox classComboBox;
        private ComboBox subjectComboBox;
        private DateTimePicker datePicker;
        private DateTimePicker timePicker;
    }
}