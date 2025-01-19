using CollageApp.Validator;
using System.ComponentModel.DataAnnotations;

namespace CollageApp.Models
{
    public class StudentDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Student name is required")]
        [StringLength(30)]
        public string StudentName { get; set; }
        [EmailAddress(ErrorMessage = "Please enter valid email address")]
        public string Email { get; set; }
        //[Range(10,20)]
        //public int age { get; set; }
        [Required]
        public string Address { get; set; }

        //public string Passwrod { get; set; }
        //[Compare("Passwrod")]
        //public string ConfirmPassword { get; set; }
        [DateCheck]
        public DateTime AdmissionDate { get; set; }
    }
}
