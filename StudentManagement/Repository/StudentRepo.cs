using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using StudentManagement.Models;
using StudentManagement.Repository.Interface;
using System.Data;

namespace StudentManagement.Repository
{
    public class StudentRepo : IStudentRepo
    {
        private readonly ILogger<StudentRepo> logger;
        private IConfiguration _Configuration;
        public StudentRepo(IConfiguration configuration, ILogger<StudentRepo> logger)
        {
            this.logger = logger;
            _Configuration = configuration;
        }
        public Student GetStudentByIdrepo(int studid)
        {
            try
            {

                var conStr = this._Configuration.GetConnectionString("Default");
                var con = new MySqlConnection(conStr);
                var cmd = new MySqlCommand("StudentGetById_SP", con);
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("_stuId", studid);
                var reader = cmd.ExecuteReader();
                Student s = new Student();

                if (reader.Read())
                {
                    s.Id = Convert.ToInt32(reader["Student_Id"]);
                    s.Name = reader["Student_Name"].ToString();
                }
                con.Close();
                return s;
            }
            catch (Exception e)
            {
                logger.LogError(e.Message);
                return null;
            }

        }

        public Student GetStudentByNamerepo(string studname)
        {
            try
            {

                var conStr = this._Configuration.GetConnectionString("Default");
                var con = new MySqlConnection(conStr);
                var cmd = new MySqlCommand("StudentGetByName_SP", con);
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("_stuName", studname);
                var reader = cmd.ExecuteReader();
                Student s1 = new Student();
                if (reader.Read())
                {
                    s1.Id = Convert.ToInt32(reader["Student_Id"]);
                    s1.Name = reader["Student_Name"].ToString();
                }
                con.Close();
                return s1;
            }
            catch (Exception e)
            {
                logger.LogError(e.Message);
                return null;
            }
        }

        public List<Student> GetStudentsrepo()
        {
            try
            {
                var studentList = new List<Student>();

                var conStr = this._Configuration.GetConnectionString("Default");
                var con = new MySqlConnection(conStr);
                var cmd = new MySqlCommand("StudentGet_SP", con);
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    var student = new Student();
                    student.Id = Convert.ToInt32(reader["Student_Id"]);
                    student.Name = reader["Student_Name"].ToString();
                    studentList.Add(student);
                }
                con.Close();
                return studentList;
            }
            catch (Exception e)
            {
                logger.LogError(e.Message);
                return null;
            }


        }

        public int RemoveStudentrepo(int studid)
        {
            try
            {
                var conStr = this._Configuration.GetConnectionString("Default");
                var con = new MySqlConnection(conStr);
                var cmd = new MySqlCommand("StudentDelete_SP", con);
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("_stuId", studid);
                var res = Convert.ToInt32(cmd.ExecuteScalar());

                con.Close();
                return res;
            }
            catch (Exception e)
            {
                logger.LogError(e.Message);
                return -1;
            }

        }

        public int SaveStudentrepo(Student student)
        {
            try
            {
                var conStr = this._Configuration.GetConnectionString("Default");
                var con = new MySqlConnection(conStr);
                var cmd = new MySqlCommand("StudentInsert_SP", con);
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("_stuName", student.Name);
                cmd.Parameters.AddWithValue("_stuId", student.Id);
                var applicationId = Convert.ToInt32(cmd.ExecuteScalar());

                con.Close();

                return applicationId;
            }
            catch (Exception e)
            {
                logger.LogError(e.Message);
                return -1;
            }

        }
    }
}