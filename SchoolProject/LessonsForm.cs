
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SchoolProject
{
    public partial class LessonsForm : Form
    {
        User user;
        MarksForm marksForm;
        string dataQuery;

        private string connectionString = "data source=NBR\\SQLEXPRESS;initial catalog=SchoolJournal;trusted_connection=true;TrustServerCertificate=true;Pooling=false";
        public LessonsForm(User _user)
        {
            InitializeComponent();
            addButton.Visible = false;
            searchTextBox.PlaceholderText = "Поиск:";
            user = _user;
            marksForm = new MarksForm(user);
            InitTable();
        }

        private void InitTable()
        {


            if (user is Pupil pupil)
            {
                userLabel.Text = "Ученик: " + pupil._fullName + "\nКласс: " + pupil._class;
                dataQuery = $"SELECT u.Id, u.[Дата и время], p.Название AS Предмет,  c.Название AS Класс FROM  Уроки AS u JOIN  Предметы AS p ON u.Предмет = p.Id  JOIN   Классы AS c ON u.Класс = c.Id AND u.Класс = {pupil._classId};";
            }
            else if (user is Teacher teacher)
            {
                userLabel.Text = "Учитель: " + teacher._fullName + "\nПредмет: " + teacher._subject;
                dataQuery = $"SELECT u.Id, u.[Дата и время], p.Название AS Предмет,  c.Название AS Класс FROM  Уроки AS u JOIN  Предметы AS p ON u.Предмет = p.Id AND u.Предмет = {teacher._subjectId}  JOIN   Классы AS c ON u.Класс = c.Id ;";

            }
            else if (user is Admin admin)
            {
                addButton.Visible = true;
                userLabel.Text = admin._fullName;
                dataQuery = $"SELECT u.Id, u.[Дата и время], p.Название AS Предмет,  c.Название AS Класс FROM  Уроки AS u JOIN  Предметы AS p ON u.Предмет = p.Id  JOIN   Классы AS c ON u.Класс = c.Id ;";
            }
            else
            {
                throw new Exception("Error");
            }

            UpdateTable();
        }

        private void UpdateTable()
        {
            SqlDatabase database = new SqlDatabase(connectionString);
            DataTable dataTable = database.ExecuteQuery(dataQuery);
            dataGridView.DataSource = dataTable;
            this.dataGridView.Columns["Id"].Visible = false;
            dataGridView.Update();
            rowCountLabel.Text = "Количество строк: " + dataGridView.RowCount ;
        }

        private void searchTextBox_TextChanged(object sender, EventArgs e)
        {
            dataGridView.ClearSelection();

            if (string.IsNullOrWhiteSpace(searchTextBox.Text))
                return;

            var values = searchTextBox.Text.Split(new char[] { ' ' },
                StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < dataGridView.RowCount - 1; i++)
            {
                foreach (string value in values)
                {
                    var row = dataGridView.Rows[i];

                    if (row.Cells["Предмет"].Value.ToString().Contains(value) ||
                        row.Cells["Класс"].Value.ToString().Contains(value))
                    {
                        row.Selected = true;
                    }
                }
            }
        }

        private void marksButton_Click(object sender, EventArgs e)
        {
            marksForm.Location = this.Location;
            marksForm.StartPosition = FormStartPosition.Manual;
            this.Hide();
            marksForm.ShowDialog();
            this.Show();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            AddLessonsForm add = new AddLessonsForm(user);
            add.ShowDialog();
            UpdateTable();
        }

        private void dataGridView_KeyDown(object sender, KeyEventArgs e)
        {
            if (user is Pupil pupil)
                return;

            if (e.Control && e.KeyCode == Keys.Delete)
            {
                // Check if a row is selected
                if (dataGridView.SelectedRows.Count > 0)
                {
                    // Get the ID of the selected row
                    int selectedRowId = (int)dataGridView.SelectedRows[0].Cells["Id"].Value;

                    // Confirm deletion with a message box
                    if (MessageBox.Show("Вы уверены, что хотите удалить эту запись?", "Подтверждение удаления", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        try
                        {
                            SqlDatabase database = new SqlDatabase(connectionString);
                            string query = $"DELETE FROM Уроки WHERE Id = {selectedRowId}";
                            database.ExecuteNonQuery(query);
                            // Delete the row from the DataGridView
                            dataGridView.Rows.RemoveAt(dataGridView.SelectedRows[0].Index);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Ошибка удаления: {ex.Message}");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Пожалуйста, выберите запись для удаления.");
                }
            }
        
        }
    }
}
