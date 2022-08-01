using MySql.Data.MySqlClient;
using StudentManagement.Models;
using StudentManagement.Repository.Interface;
using System.Data;

namespace StudentManagement.Repository
{
    public class userRepo : IUserRepo
    {
        private readonly ILogger<userRepo> logger;
        private IConfiguration _Configuration;
        public userRepo(IConfiguration configuration, ILogger<userRepo> logger)
        {
            this.logger = logger;
            _Configuration = configuration;
        }

        public int loginrepo(string username,string password)
        {
            try
            {
               //var UserList = new List<User>();

                var conStr = this._Configuration.GetConnectionString("Default");
                var con = new MySqlConnection(conStr);
                var cmd = new MySqlCommand("Login_SP", con);
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("_uname",username);
                cmd.Parameters.AddWithValue("_pswd",password);
                int result = Convert.ToInt32(cmd.ExecuteScalar());
               // var reader = cmd.ExecuteReader();
                con.Close();
                return result;
            }
            catch (Exception e)
            {
                logger.LogError(e.Message);
                return -1;
            }
        }

        public int Registerrepo(string username, string password)
        { 
        try
            {
              // var UserList = new List<User>();
                var conStr = this._Configuration.GetConnectionString("Default");    
                var con = new MySqlConnection(conStr);
                var cmd = new MySqlCommand("Register_SP", con);
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("_uname",username);
                cmd.Parameters.AddWithValue("_pswd",password);
                int result = Convert.ToInt32(cmd.ExecuteScalar());
               con.Close();
                return result  ;
            }
            catch (Exception e)
            {
                logger.LogError(e.Message);
                return -1;
            }
        }
    }
}
