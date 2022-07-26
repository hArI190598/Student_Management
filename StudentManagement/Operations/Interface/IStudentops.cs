using StudentManagement.Models;

namespace StudentManagement.Operations.Interface
{
    public interface IStudentops
    {
        public List<Student> GetStudentops();
        public Student GetStudentByIdops(int id);
        public Student GetStudentByNameops(string name);
        public int SaveStudentops(Student savestudent);
        public int RemoveStudentops(int sid);


    }
}
