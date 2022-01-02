using Darbas.Data.Base;
using Darbas.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Darbas.Data.Services
{
    public class SubjectsService:EntityBaseRepository<Subject>, ISubjectService
    {
        public SubjectsService(AppDbContext context) : base(context)
        {
        }
    }
}
