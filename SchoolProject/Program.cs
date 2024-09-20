using Microsoft.VisualBasic.ApplicationServices;
using System.Data;

namespace SchoolProject
{
    internal static class Program
    {
        private static string connectionString = "data source=NBR\\SQLEXPRESS;initial catalog=SchoolJournal;trusted_connection=true;TrustServerCertificate=true;Pooling=false";

        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            User user = new User();
            using (var authForm = new AuthorizationForm()) 
            {
                if (authForm.ShowDialog() != DialogResult.OK)
                {
                    user = authForm.user;
                }
               

            }
            if (user._id != 0)
            {
                bool isPupil = false;
                bool isTeacher = false;
                SqlDatabase database = new SqlDatabase(connectionString);
                Admin admin = new Admin();
                if (user._login == admin._login && user._password == admin._password)
                    Application.Run(new LessonsForm(admin));

                string query = $"select * from Учителя Where [Id учетной записи] = {user._id}";
                DataTable data = database.ExecuteQuery(query);
                if (data.Rows.Count > 0)
                    isTeacher = true;

                if (isTeacher)
                {
                    Teacher teacher = new Teacher();
                    teacher._id = (int)data.Rows[0]["Id"];
                    teacher._accountId = user._id;
                    teacher._password = user._password;
                    teacher._login = user._login;
                    teacher._fullName = (string)data.Rows[0]["ФИО"];
                    query = $"select * from Предметы Where Учитель = {teacher._id}";
                    data = database.ExecuteQuery(query);
                    teacher._subjectId = (int)data.Rows[0]["Id"];
                    teacher._subject = (string)data.Rows[0]["Название"];
                    Application.Run(new LessonsForm(teacher));
                }

                query = $"select * from Ученики Where [Id учетной записи] = {user._id}";
                data = database.ExecuteQuery(query);
                if (data.Rows.Count > 0)
                    isPupil = true;

                
                if (isPupil)
                {
                    Pupil pupil = new Pupil();
                    pupil._id = (int)data.Rows[0]["Id"];
                    pupil._accountId = user._id;
                    pupil._password = user._password;
                    pupil._login = user._login;
                    pupil._fullName = (string)data.Rows[0]["ФИО"];
                    
                    pupil._classId = (int)data.Rows[0]["Класс"];
                    query = $"select * from Классы Where Id = {pupil._classId}";
                    data = database.ExecuteQuery(query);
                    pupil._class = (string)data.Rows[0]["Название"];
                    Application.Run(new LessonsForm(pupil));
                }
                
            }
        }

    }

}