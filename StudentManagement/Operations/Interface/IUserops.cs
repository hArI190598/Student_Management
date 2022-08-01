using StudentManagement.Models;

namespace StudentManagement.Operations.Interface
{
    public interface IUserops
    {
        public int loginOps(string uname,string pswd);

        public int RegisterOps(string uname,string pswd);
    }
}
