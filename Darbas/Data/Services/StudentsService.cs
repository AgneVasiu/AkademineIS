using Darbas.Data.Base;
using Darbas.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Darbas.Data.Services
{
    public class StudentsService : EntityBaseRepository<Student>, IStudentsService
    {
        public StudentsService(AppDbContext context) : base(context) { }
      
    }
}
