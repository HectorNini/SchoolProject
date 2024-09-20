using NuGet.Frameworks;
using SchoolProject;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace TestProject
{
    public class Tests
    {

        [Test]
        public void DatabaseConnection_ValidValue_NotNull()
        {
            try
            {
                string connectionString = "data source=NBR\\SQLEXPRESS;initial catalog=SchoolJournal;trusted_connection=true;TrustServerCertificate=true;Pooling=false";
                SqlDatabase sqlDatabase = new SqlDatabase(connectionString);
                Assert.That(sqlDatabase.GetConnection(), Is.Not.Null);
            }
            catch (Exception ex) 
            {
                Assert.Fail(ex.Message);
            }

        }

        [Test]
        public void DatabaseConnection_InvalidValue_Exeption() 
        {
            try
            {
                string connectionString = "data source=error\\SQLEXPRESS;initial catalog=SchoolJournal;trusted_connection=true;TrustServerCertificate=true;Pooling=false";
                SqlDatabase sqlDatabase = new SqlDatabase(connectionString);
                Assert.That(sqlDatabase.GetConnection(), Is.Not.Null);
            }
            catch (Exception ex)
            {
                Assert.Pass(ex.Message);
            }
        }

        [Test]
        public void DatabaseConnectionString_ValidValue_EqualsToConnection()
        {
            try
            {
                string connectionString = "data source=error\\SQLEXPRESS;initial catalog=SchoolJournal;trusted_connection=true;TrustServerCertificate=true;Pooling=false";
                SqlDatabase sqlDatabase = new SqlDatabase(connectionString);
                SqlConnection connection = new SqlConnection(connectionString);
                Assert.That(sqlDatabase.GetConnection().ToString(), Is.EqualTo(connection.ToString()));
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [Test]
        public void DatabaseExecQuery_ValidValue_NotNull() 
        {
            try
            {
                string connectionString = "data source=NBR\\SQLEXPRESS;initial catalog=SchoolJournal;trusted_connection=true;TrustServerCertificate=true;Pooling=false";
                SqlDatabase sqlDatabase = new SqlDatabase(connectionString);
                string query = "SELECT * FROM Ученики";
                DataTable data = sqlDatabase.ExecuteQuery(query);

                Assert.That(data, Is.Not.Null);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }

        }

        [Test]
        public void DatabaseExecQuery_InvalidValue_Exeption()
        {
            try
            {
                string connectionString = "data source=NBR\\SQLEXPRESS;initial catalog=SchoolJournal;trusted_connection=true;TrustServerCertificate=true;Pooling=false";
                SqlDatabase sqlDatabase = new SqlDatabase(connectionString);
                string query = "SELECT * FROM Error";
                DataTable data = sqlDatabase.ExecuteQuery(query);

                Assert.That(data, Is.Not.Null);
            }
            catch (Exception ex)
            {
                Assert.Pass(ex.Message);
            }

        }

        [Test]
        public void FillComboBox_ValidValue_NotNull()
        {
            try
            {
                string connectionString = "data source=NBR\\SQLEXPRESS;initial catalog=SchoolJournal;trusted_connection=true;TrustServerCertificate=true;Pooling=false";
                string query = "SELECT * FROM Предметы";
                ComboBox comboBox = new ComboBox();
                SqlDatabase database = new SqlDatabase(connectionString);
                DataTable data = database.ExecuteQuery(query);
                comboBox.BindingContext = new BindingContext();
                comboBox.DisplayMember = "Название";
                comboBox.ValueMember = "Id";
                comboBox.DataSource = data;

                Assert.That(comboBox.Items.Count, Is.AtLeast(1));
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }

        }


        [Test]
        public void FillLessonsForm_ValidValue_NotNull()
        {
            try
            {
                string connectionString = "data source=NBR\\SQLEXPRESS;initial catalog=SchoolJournal;trusted_connection=true;TrustServerCertificate=true;Pooling=false";
                string query = $"SELECT u.Id, u.[Дата и время], p.Название AS Предмет,  c.Название AS Класс FROM  Уроки AS u JOIN  Предметы AS p ON u.Предмет = p.Id  JOIN   Классы AS c ON u.Класс = c.Id ;";

                SqlDatabase database = new SqlDatabase(connectionString);
                DataTable data = database.ExecuteQuery(query);
                

                Assert.That(data.Rows.Count, Is.AtLeast(1));
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }

        }
        [Test]
        public void FillMarksForm_ValidValue_NotNull()
        {
            try
            {
                string connectionString = "data source=NBR\\SQLEXPRESS;initial catalog=SchoolJournal;trusted_connection=true;TrustServerCertificate=true;Pooling=false";
                string query = $"SELECT ou.Id,  u.[Дата и время],   p.Название AS Предмет, s.ФИО,   o.Оценка FROM     Уроки AS u JOIN   Предметы AS p ON u.Предмет = p.Id  JOIN    Оценки_Уроки AS ou ON u.Id = ou.[Id урока] JOIN     Оценки AS o ON ou.[id оценки] = o.Id JOIN Ученики as s ON o.Ученик = s.Id;";

                SqlDatabase database = new SqlDatabase(connectionString);
                DataTable data = database.ExecuteQuery(query);

                Assert.That(data.Rows.Count, Is.AtLeast(1));
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }

        }


        [Test]
        public void Authorization_ValidValue_NotNull()
        {
            try
            {
                string connectionString = "data source=NBR\\SQLEXPRESS;initial catalog=SchoolJournal;trusted_connection=true;TrustServerCertificate=true;Pooling=false";
                Teacher teacher = new Teacher();
                teacher._login = "ninibayr";
                teacher._password = "1234";
                string query = $"select * from Пользователи Where Логин = '{teacher._login}' AND Пароль = '{teacher._password}' ";
                SqlDatabase database = new SqlDatabase(connectionString);
                DataTable data = database.ExecuteQuery(query);

                Assert.That(data.Rows.Count, Is.AtLeast(1));
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }

        }


        [Test]
        public void Authorization_InvalidValue_IsZero()
        {
            try
            {
                string connectionString = "data source=NBR\\SQLEXPRESS;initial catalog=SchoolJournal;trusted_connection=true;TrustServerCertificate=true;Pooling=false";
                Teacher teacher = new Teacher();
                teacher._login = "ninibayr";
                teacher._password = "9999";
                string query = $"select * from Пользователи Where Логин = '{teacher._login}' AND Пароль = '{teacher._password}' ";
                SqlDatabase database = new SqlDatabase(connectionString);
                DataTable data = database.ExecuteQuery(query);

                Assert.That(data.Rows.Count, Is.Not.AtLeast(1));
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }

        }


     
    }
}

