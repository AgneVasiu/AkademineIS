using Darbas.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Darbas.Models
{
    public class NewGradeVM
    {
        public int Id { get; set; }

        [Display(Name = "Enter first grade")]
        [Required(ErrorMessage ="Grade I is neaded")]
        public int Grade1 { get; set; }

        [Display(Name = "Enter second grade")]
        [Required(ErrorMessage = "Grade II is neaded")]
        public int Grade2 { get; set; }

        [Display(Name = "Enter third grade")]
        [Required(ErrorMessage = "Grade III is neaded")]
        public int Grade3 { get; set; }

        [Display(Name = "Enter forth grade")]
        [Required(ErrorMessage = "Grade IV is neaded")]
        public int Grade4 { get; set; }

        [Display(Name = "Enter fift grade")]
        [Required(ErrorMessage = "Grade V is neaded")]
        public int Grade5 { get; set; }

        //Relations
        //Subject
        [Display(Name = "Select Subject(s)")]
        [Required(ErrorMessage = "Subject(s) is neaded")]
        public int SubjectId { get; set; }
        
    }
}
