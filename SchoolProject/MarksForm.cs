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
    public partial class MarksForm : Form
    {
        private string connectionString = "data source=NBR\\SQLEXPRESS;initial catalog=SchoolJournal;trusted_connection=true;TrustServerCertificate=true;Pooling=false";
        private User user;
        private string dataQuery;
        public MarksForm(User user)
        {
            InitializeComponent();
            this.user = user;
            searchTextBox.PlaceholderText = "Поиск:";
            InitTable();
        }
        private void InitTable()
        {
            dataGridView.ReadOnly = true;
            SqlDatabase database = new SqlDatabase(connectionString);

            if (user is Pupil pupil)
            {
                userLabel.Text = "Ученик: " + pupil._fullName + "\nКласс: " + pupil._class;
                dataQuery = $"SELECT   ou.Id, u.[Дата и время],   p.Название AS Предмет, s.ФИО,   o.Оценка FROM     Уроки AS u JOIN   Предметы AS p ON u.Предмет = p.Id  JOIN    Оценки_Уроки AS ou ON u.Id = ou.[Id урока] JOIN     Оценки AS o ON ou.[id оценки] = o.Id JOIN Ученики as s ON o.Ученик = s.Id AND o.Ученик = {pupil._id};";
            }
            else if (user is Teacher teacher)
            {
                userLabel.Text = "Учитель: " + teacher._fullName + "\nПредмет: " + teacher._subject;
                dataQuery = $"SELECT ou.Id,  u.[Дата и время],   p.Название AS Предмет, s.ФИО,   o.Оценка FROM     Уроки AS u JOIN   Предметы AS p ON u.Предмет = p.Id AND p.Учитель = {teacher._id} JOIN    Оценки_Уроки AS ou ON u.Id = ou.[Id урока] JOIN     Оценки AS o ON ou.[id оценки] = o.Id JOIN Ученики as s ON o.Ученик = s.Id;";
            }
            else if (user is Admin admin)
            {
                userLabel.Text = "Админ";
                dataQuery = $"SELECT ou.Id,  u.[Дата и время],   p.Название AS Предмет, s.ФИО,   o.Оценка FROM     Уроки AS u JOIN   Предметы AS p ON u.Предмет = p.Id  JOIN    Оценки_Уроки AS ou ON u.Id = ou.[Id урока] JOIN     Оценки AS o ON ou.[id оценки] = o.Id JOIN Ученики as s ON o.Ученик = s.Id;";
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
            rowCountLabel.Text = "Количество строк: " + dataGridView.Rows.Count;
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
                        row.Cells["ФИО"].Value.ToString().Contains(value) ||
                        row.Cells["Оценка"].Value.ToString().Contains(value))
                    {
                        row.Selected = true;
                    }
                }
            }
        }

        private void lessonsButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            AddMarksForm add = new AddMarksForm(user);
            add.ShowDialog();
            UpdateTable();
        }

        private void dataGridView_KeyDown(object sender, KeyEventArgs e)
        {
            if (user is Pupil pupil)
                return;


            if (e.Control && e.KeyCode == Keys.D)
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
                            string query = $"DELETE FROM Оценки_Уроки WHERE [Id оценки] = {selectedRowId}";
                            database.ExecuteNonQuery(query);
                            query = $"DELETE FROM Оценки WHERE Id = {selectedRowId}";
                            database.ExecuteNonQuery(query);
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
                    MessageBox.Show("Пожалуйста, выберите запись.");
                }

            }
            else if (e.Control && e.KeyCode == Keys.R)
            {
                if (dataGridView.SelectedRows.Count > 0)
                {
                    // Get the ID of the selected row
                    if (MessageBox.Show("Вы уверены, что хотите редактировать эту запись?", "Подтверждение редактирования", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        int selectedRowId = (int)dataGridView.SelectedRows[0].Cells["Id"].Value;
                        AddMarksForm addMarksForm = new AddMarksForm(user, selectedRowId);
                        addMarksForm.ShowDialog();
                        UpdateTable();
                    }

                }
                else
                {
                    MessageBox.Show("Пожалуйста, выберите запись.");
                }

            }
           
        }
    }
}
