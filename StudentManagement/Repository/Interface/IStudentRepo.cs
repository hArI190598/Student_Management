using StudentManagement.Models;

namespace StudentManagement.Repository.Interface
{
    public interface IStudentRepo
    {
        public Student GetStudentByIdrepo(int studid);
        public Student GetStudentByNamerepo(string studname);
        public List<Student> GetStudentsrepo();
        public int SaveStudentrepo(Student student);
        public int RemoveStudentrepo(int studid);

    }
}
