using StudentManagement.Models;

namespace StudentManagement.Repository.Interface
{
    public interface IUserRepo
    {
        public int loginrepo(string uname,string pswd);

        public int Registerrepo(string username,string password);
    }
}
