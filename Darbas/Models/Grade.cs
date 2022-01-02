using Darbas.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Darbas.Models
{
    public class Grade:IEntityBase
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Grade I")]
        [Required(ErrorMessage ="Grade I is neaded")]
        public int Grade1 { get; set; }
        [Display(Name = " Grade II")]
        [Required(ErrorMessage = "Grade II is neaded")]
        public int Grade2 { get; set; }
        [Display(Name = "Grade III")]
        public int Grade3 { get; set; }
        [Display(Name = "Grade IV")]
        public int Grade4 { get; set; }
        [Display(Name = "Grade V")]
        public int Grade5 { get; set; }
       //Relations
        //Subject
        public int SubjectId { get; set; }
        public Subject Subject { get; set; }
       



    }
}
