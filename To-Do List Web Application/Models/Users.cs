using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace To_Do_List_Web_Application.Models
{
    public class Users
    {

      
        [Key]
        [MaxLength(50)]
        [MinLength(5, ErrorMessage = "UserName must be more than 5 char")]
        
        public string User_Name { get; set; }
        [MaxLength(50)]
        [MinLength(8, ErrorMessage = "FullName must be more than 8 char")]
        public string Full_Name { get; set; }
        [MaxLength(50)]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"^([0-9a-zA-Z]([\+\-_\.][0-9a-zA-Z]+)*)+@(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]*\.)+[a-zA-Z0-9]{2,3})$", ErrorMessage = "Your email address is not in a valid format. Example of correct format: joe.example@example.org")]
        public string Email { get; set; }
        [MaxLength(50)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [NotMapped]
        [DataType(DataType.Password)]
        public string ConfirmPasword { get; set; }

        [MaxLength(50)]
        [RegularExpression(@"^01[0125][0-9]{8}$", ErrorMessage = "The PhoneNumber field is not a valid phone number")]
        public string PhoneNumber { get; set; }
        
        public virtual List<Tasks> Tasks { get; set; } = new List<Tasks>();

    }
}
