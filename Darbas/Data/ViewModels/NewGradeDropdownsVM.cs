using Darbas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Darbas.Data.ViewModels
{
    public class NewGradeDropdownsVM
    {
        public NewGradeDropdownsVM()
        {
            Subjects = new List<Subject>();
        }
        public List<Subject> Subjects { get; set; }
    }
}
