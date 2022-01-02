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
    public class Subject:IEntityBase
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Subject name")]
        [Required(ErrorMessage = "Subject Name is neaded")]
        public string SubjectName { get; set; }
        [Display(Name = "Credics number")]
        [Required(ErrorMessage = "Creadits Number is neaded")]
        public int Creditsnumber { get; set; }
        //Relationships
        public List<Student_Teacher> Student_Teachers { get; set; }
        public List<Grade> Grades { get; set; }
       



    }
}
