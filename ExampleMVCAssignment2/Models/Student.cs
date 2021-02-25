using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ExampleMVCAssignment2.Models
{
    public class Student
    {
        public Student Students { get; set; }
        [Key]
        public int StudentId { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "Name Cannot exceed 50 Characters")]
        public string Name { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$", ErrorMessage ="Invalid Email Formate")]
        public string Email { get; set; }
        [Required]
        public Branch? Branch { get; set; }//Nullable (if Branch is not selected then it will pass as it is )
        [Required]
        public Gender Gender {get;set;}
        [Required]
        public string Address { get; set; }
        public IEnumerable<Gender> AllGenders { set; get; }
    }
}
