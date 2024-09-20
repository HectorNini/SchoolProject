
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

    public partial class AuthorizationForm : Form
    {
        public User user;
        private string connectionString = "data source=NBR\\SQLEXPRESS;initial catalog=SchoolJournal;trusted_connection=true;TrustServerCertificate=true;Pooling=false";


        public AuthorizationForm()
        {
            InitializeComponent();
            user = new User();

            passwordTextBox.PlaceholderText = "Пароль:";
            loginTextBox.PlaceholderText = "Логин:";
            this.ActiveControl = nameLabel;

        }

        private void enterButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(loginTextBox.Text) || string.IsNullOrEmpty(passwordTextBox.Text))
            {
                MessageBox.Show("Заполните все поля");
            }
            else
            {
                SqlDatabase database = new SqlDatabase(connectionString);
                string query = $"select * from Пользователи Where Логин = '{loginTextBox.Text}' AND Пароль = '{passwordTextBox.Text}' ";
                DataTable data = database.ExecuteQuery(query);
                Admin admin = new Admin();
                bool isAdmin = loginTextBox.Text == admin._login && passwordTextBox.Text == admin._password;
                if (data.Rows.Count == 0 && !isAdmin)
                {
                    MessageBox.Show("Неправильный логин или пароль");
                }
                else if (isAdmin)
                {
                    user._id = admin._id;
                    user._login = admin._login;
                    user._password = admin._password;
                    this.Close();
                }
                else
                {
                    user._id = (int)data.Rows[0]["Id"];
                    user._login = (string)data.Rows[0]["Логин"];
                    user._password = (string)data.Rows[0]["Пароль"];

                    this.Close();
                }
            }


        }

        private void AuthorizationForm_Load(object sender, EventArgs e)
        {

        }
    }

}
