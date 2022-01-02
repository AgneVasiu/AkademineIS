using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Darbas.Models
{
    public class Student_Teacher
    {
        public int TeacherId { get; set;}
        public Teacher Teacher { get; set;}

        public int StudentId { get; set;}
        public Student Student { get; set;}
       
    }
}
