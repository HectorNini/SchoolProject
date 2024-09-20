namespace SchoolProject
{
    partial class LessonsForm
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
            dataGridView = new DataGridView();
            userLabel = new Label();
            searchTextBox = new TextBox();
            marksButton = new Button();
            lessonsButton = new Button();
            addButton = new Button();
            rowCountLabel = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            SuspendLayout();
            // 
            // dataGridView
            // 
            dataGridView.BackgroundColor = Color.FromArgb(241, 227, 243);
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Location = new Point(12, 124);
            dataGridView.Name = "dataGridView";
            dataGridView.RowHeadersWidth = 51;
            dataGridView.Size = new Size(776, 314);
            dataGridView.TabIndex = 0;
            dataGridView.KeyDown += dataGridView_KeyDown;
            // 
            // userLabel
            // 
            userLabel.AutoSize = true;
            userLabel.ForeColor = Color.FromArgb(241, 227, 243);
            userLabel.Location = new Point(12, 44);
            userLabel.Name = "userLabel";
            userLabel.Size = new Size(56, 20);
            userLabel.TabIndex = 1;
            userLabel.Text = "ИНФО:";
            // 
            // searchTextBox
            // 
            searchTextBox.Location = new Point(610, 14);
            searchTextBox.Name = "searchTextBox";
            searchTextBox.Size = new Size(178, 27);
            searchTextBox.TabIndex = 2;
            searchTextBox.TextChanged += searchTextBox_TextChanged;
            // 
            // marksButton
            // 
            marksButton.BackColor = Color.FromArgb(250, 199, 72);
            marksButton.FlatStyle = FlatStyle.Popup;
            marksButton.Location = new Point(105, 12);
            marksButton.Name = "marksButton";
            marksButton.Size = new Size(94, 29);
            marksButton.TabIndex = 9;
            marksButton.Text = "Оценки";
            marksButton.UseVisualStyleBackColor = false;
            marksButton.Click += marksButton_Click;
            // 
            // lessonsButton
            // 
            lessonsButton.BackColor = Color.FromArgb(250, 199, 72);
            lessonsButton.FlatStyle = FlatStyle.Popup;
            lessonsButton.Location = new Point(12, 12);
            lessonsButton.Name = "lessonsButton";
            lessonsButton.Size = new Size(94, 29);
            lessonsButton.TabIndex = 8;
            lessonsButton.Text = "Уроки";
            lessonsButton.UseVisualStyleBackColor = false;
            // 
            // addButton
            // 
            addButton.BackColor = Color.FromArgb(250, 199, 72);
            addButton.FlatStyle = FlatStyle.Popup;
            addButton.Location = new Point(610, 47);
            addButton.Name = "addButton";
            addButton.Size = new Size(178, 29);
            addButton.TabIndex = 10;
            addButton.Text = "Добавить";
            addButton.UseVisualStyleBackColor = false;
            addButton.Click += addButton_Click;
            // 
            // rowCountLabel
            // 
            rowCountLabel.AutoSize = true;
            rowCountLabel.ForeColor = Color.FromArgb(241, 227, 243);
            rowCountLabel.Location = new Point(610, 90);
            rowCountLabel.Name = "rowCountLabel";
            rowCountLabel.Size = new Size(135, 20);
            rowCountLabel.TabIndex = 11;
            rowCountLabel.Text = "Количество строк:";
            // 
            // LessonsForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(29, 47, 111);
            ClientSize = new Size(800, 450);
            Controls.Add(rowCountLabel);
            Controls.Add(addButton);
            Controls.Add(marksButton);
            Controls.Add(lessonsButton);
            Controls.Add(searchTextBox);
            Controls.Add(userLabel);
            Controls.Add(dataGridView);
            Name = "LessonsForm";
            Text = "LessonsForm";
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView;
        private Label userLabel;
        private TextBox searchTextBox;
        private Button marksButton;
        private Button lessonsButton;
        private Button addButton;
        private Label rowCountLabel;
    }
}