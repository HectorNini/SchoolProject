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
                string query = "SELECT * FROM �������";
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
                string query = "SELECT * FROM ��������";
                ComboBox comboBox = new ComboBox();
                SqlDatabase database = new SqlDatabase(connectionString);
                DataTable data = database.ExecuteQuery(query);
                comboBox.BindingContext = new BindingContext();
                comboBox.DisplayMember = "��������";
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
                string query = $"SELECT u.Id, u.[���� � �����], p.�������� AS �������,  c.�������� AS ����� FROM  ����� AS u JOIN  �������� AS p ON u.������� = p.Id  JOIN   ������ AS c ON u.����� = c.Id ;";

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
                string query = $"SELECT ou.Id,  u.[���� � �����],   p.�������� AS �������, s.���,   o.������ FROM     ����� AS u JOIN   �������� AS p ON u.������� = p.Id  JOIN    ������_����� AS ou ON u.Id = ou.[Id �����] JOIN     ������ AS o ON ou.[id ������] = o.Id JOIN ������� as s ON o.������ = s.Id;";

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
                string query = $"select * from ������������ Where ����� = '{teacher._login}' AND ������ = '{teacher._password}' ";
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
                string query = $"select * from ������������ Where ����� = '{teacher._login}' AND ������ = '{teacher._password}' ";
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

