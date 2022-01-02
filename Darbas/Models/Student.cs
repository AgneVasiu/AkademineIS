using Darbas.Data;
using Darbas.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Darbas.Models
{
    public class Student:IEntityBase
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Full Name")]
        [Required(ErrorMessage = "Full Name is neaded")]
        public string FullName { get; set; }
        [Display(Name = "Groupe")]
        [Required(ErrorMessage = "Groupe is neaded")]
        public string Class { get; set; }
        [Display(Name = "Gender")]
        public Sex Sex { get; set; }
        [Display(Name = "Date of birth")]
        [Required(ErrorMessage = "Date of birth is neaded")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="{0:yyyy/MM/dd}")]
        public DateTime DateOfBirth { get; set; }
        [Display(Name = "Email adress")]
        [Required(ErrorMessage = "Email adress is neaded")]
        public string Email { get; set; }
        [Display(Name = "Phone Number")]
        [Required(ErrorMessage = "Phone Number is neaded")]
        public int PhoneNumber { get; set; }
        [Display(Name = "Profile Picture")]
        public string ProfilePicture { get; set; }

        //Relationships
        public List<Student_Teacher> Student_Teachers { get; set;}
        



    }

}
