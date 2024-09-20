

namespace SchoolProject
{
    public class User
    {
        public int _id;
        public int _accountId;
        public string _login;
        public string _password;
        public string _fullName;
        public User()
        {

            _id = 0;
            _login = "";
            _accountId = 0;
            _password = "";
            _fullName = "";
        }
        public User(int id, int accountId, string login, string password, string fullName) 
        {
            _id = id;
            _accountId = accountId;
            _login = login;
            _password = password;
            _fullName = fullName;
        }
    }

    public class Admin : User
    {
        public Admin()
        {
            _id = -1;
            _login = "admin";
            _accountId = 0;
            _password = "admin";
            _fullName = "Админ";
        }
    }
    public class Pupil : User 
    {
        public int _classId;
        public string _class;
        public Pupil() : base()
        {
            _classId = 0;
            _class = "";
        }
        public Pupil(int id, int accountId, string login, string password, string fullName, int classId, string _class) : base(id, accountId, login, password,  fullName) 
        {
            _classId = classId;
            this._class = _class;
        }
    }

    public class Teacher : User
    {
        public int _subjectId;
        public string _subject;
        public Teacher() : base()
        {
            _subjectId = 0;
            _subject = "";
        }
        public Teacher(int id, int accountId, string login, string password, string fullName, int subjectId, string subject) : base(id, accountId, login, password, fullName)
        {
            _subjectId = subjectId;
            _subject = subject;
        }
    }
}
