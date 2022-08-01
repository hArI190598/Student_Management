using System.ComponentModel.DataAnnotations;
namespace StudentManagement.Models
{
    public class User
    {
        public string? UserName { get; set; }

        [Required]
       
        [RegularExpression("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$")]
        public string? Password { get; set; }
    }
}
