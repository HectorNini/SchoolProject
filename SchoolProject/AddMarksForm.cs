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

namespace SchoolProject
{
    public partial class AddMarksForm : Form
    {
        private static string connectionString = "data source=NBR\\SQLEXPRESS;initial catalog=SchoolJournal;trusted_connection=true;TrustServerCertificate=true;Pooling=false";
        User user;
        int editId;
        public AddMarksForm(User user, int editId = 0)
        {
            InitializeComponent();
            this.user = user;
            this.editId = editId;
            InitForm();
        }

        private void InitForm()
        {
            string pupilQuery, lessonsQuery;
            if (user is Teacher teacher)
            {
                pupilQuery = $"SELECT * FROM Ученики WHERE Класс IN (SELECT Класс FROM Уроки WHERE Предмет = {teacher._subjectId})";
                lessonsQuery = $"SELECT * FROM Уроки WHERE Предмет = {teacher._subjectId}";
            } 
            else 
            {
                pupilQuery = $"SELECT * FROM Ученики ";
                lessonsQuery = $"SELECT * FROM Уроки";
            }

            FillComboBox(pupilComboBox, pupilQuery, "ФИО");
            FillComboBox(lessonComboBox, lessonsQuery, "Дата и время");

        }

        private void FillComboBox(ComboBox comboBox, string query, string dm)
        {
            SqlDatabase database = new SqlDatabase(connectionString);
            DataTable data = database.ExecuteQuery(query);
            comboBox.BindingContext = new BindingContext();
            comboBox.DisplayMember = dm;
            comboBox.ValueMember = "Id";
            comboBox.DataSource = data;
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            try
            {
                string query;
                SqlDatabase database = new SqlDatabase(connectionString);
                if (editId <= 0) 
                {
                    query = $"INSERT INTO Оценки ([Оценка], [Ученик])     VALUES ({markComboBox.SelectedItem}, {pupilComboBox.SelectedValue}) SELECT SCOPE_IDENTITY()";

                    var markId = database.ExecuteQuery(query).Select()[0][0];

                    query = $"INSERT INTO Оценки_Уроки ([Id урока], [Id оценки])     VALUES ({lessonComboBox.SelectedValue}, {markId})";
                    database.ExecuteQuery(query);
                    MessageBox.Show("Оценка успешно добавлена");
                }
                else 
                {
                    query = $"UPDATE Оценки SET Оценка = {markComboBox.SelectedItem}, " +
                        $"Ученик = {pupilComboBox.SelectedValue} WHERE Id IN (SELECT [Id оценки] FROM Оценки_Уроки Where Id = {editId}) ";
                    database.ExecuteQuery(query);
                    MessageBox.Show("Оценка успешно редактирована");
                }
                
            }
            catch
            {
                MessageBox.Show("Ошибка");
            }
            finally 
            {
                this.Close();
            }
           
            
        }
    }
}
