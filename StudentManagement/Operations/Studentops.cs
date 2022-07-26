using StudentManagement.Models;
using StudentManagement.Operations.Interface;
using StudentManagement.Repository.Interface;

namespace StudentManagement.Operations
{
    public class Studentops : IStudentops
    {
        private readonly ILogger _logger;
        private readonly IStudentRepo _StudentRepo;
        public Studentops(IStudentRepo studentRepo, IConfiguration configuration,
                            ILogger<Studentops> logger)
        {
            this._logger = logger;  
            this._StudentRepo = studentRepo;
        }
        public List<Student> GetStudentops()
        {
            return _StudentRepo.GetStudentsrepo();
        }

        public Student GetStudentByIdops(int id)
        {
            return _StudentRepo.GetStudentByIdrepo(id);
        }

        public Student GetStudentByNameops(string name)
        {
            return _StudentRepo.GetStudentByNamerepo(name);
        }

        public int RemoveStudentops(int sid)
        {
            return _StudentRepo.RemoveStudentrepo(sid);
        }

        public int SaveStudentops(Student savestudent)
        {
            return _StudentRepo.SaveStudentrepo(savestudent);
        }
    }
}
