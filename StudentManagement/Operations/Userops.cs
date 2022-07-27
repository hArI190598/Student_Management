using StudentManagement.Models;
using StudentManagement.Operations.Interface;
using StudentManagement.Repository.Interface;

namespace StudentManagement.Operations
{
    public class Userops : IUserops
    {
        private readonly ILogger _logger;
        private readonly IUserRepo _UserRepo;
        public Userops(IUserRepo userRepo, IConfiguration configuration,
                            ILogger<Userops> logger)
        {
            this._logger = logger;
            this._UserRepo = userRepo;
        }
        public int loginOps(string uname,string pswd)
        {
            return _UserRepo.loginrepo(uname,pswd);
        }
    }
}
