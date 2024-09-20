using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SchoolProject
{
    public partial class AddLessonsForm : Form
    {
        private static string connectionString = "data source=NBR\\SQLEXPRESS;initial catalog=SchoolJournal;trusted_connection=true;TrustServerCertificate=true;Pooling=false";
        User user;
        public AddLessonsForm(User user)
        {
            InitializeComponent();
            this.user = user;
            InitForm();

        }

        private void InitForm() 
        {
            string query;
            datePicker.Format = DateTimePickerFormat.Long;
            timePicker.Format = DateTimePickerFormat.Custom;
            timePicker.CustomFormat = "hh:mm";
            timePicker.ShowUpDown = true;

            query = $"SELECT * FROM Предметы";
            FillComboBox(subjectComboBox, query);
            

            query = $"SELECT * FROM Классы";
            FillComboBox(classComboBox, query);

            if (user is Teacher teacher) 
            {
                subjectComboBox.SelectedIndex = subjectComboBox.FindStringExact(teacher._subject);
                subjectComboBox.Enabled = false;
            }

        }

        private void FillComboBox(ComboBox comboBox, string query) 
        {
            SqlDatabase database = new SqlDatabase(connectionString);
            DataTable data = database.ExecuteQuery(query);
            comboBox.BindingContext = new BindingContext();
            comboBox.DisplayMember = "Название";
            comboBox.ValueMember = "Id";
            comboBox.DataSource = data;
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            string query;
            SqlDatabase database = new SqlDatabase(connectionString);
            DateTime dateTime = datePicker.Value.Date + timePicker.Value.TimeOfDay;
            query = $"INSERT INTO Уроки ([Дата и время], [Предмет], [Класс])     VALUES ('{dateTime}', {subjectComboBox.SelectedValue}, {classComboBox.SelectedValue}) ";
            database.ExecuteQuery(query);
            MessageBox.Show("Урок успешно добавлен");
            this.Close();
        }
    }
}
