using Darbas.Data.Base;
using Darbas.Data.ViewModels;
using Darbas.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Darbas.Data.Services
{
    public class GradesService:EntityBaseRepository<Grade>, IGradesService
    {
        private readonly AppDbContext _context;
        public GradesService(AppDbContext context): base(context)
        {
            _context = context;
        }

        public async Task AddNewGradeAsync(NewGradeVM data)
        {
            var newGrade = new Grade()
            {
                Grade1 = data.Grade1,
                Grade2 = data.Grade2,
                Grade3 = data.Grade3,
                Grade4 = data.Grade4,
                Grade5 = data.Grade5,
                SubjectId = data.SubjectId

            };
            await _context.Grades.AddAsync(newGrade);
            await _context.SaveChangesAsync();
        }

        public async Task<Grade> GetGradeByIdAsync(int id)
        {
            var gradeDetails = await _context.Grades
                .Include(s => s.Subject)
                .FirstOrDefaultAsync(n => n.Id == id);
            return gradeDetails;
        }

        public async Task<NewGradeDropdownsVM> GetNewGradeDropdownsValues()
        {
            var response = new NewGradeDropdownsVM();
            response.Subjects = await _context.Subjects.OrderBy(n => n.SubjectName).ToListAsync();
            return response;
        }

        public async Task UpdateGradeAsync(NewGradeVM data)
        {
            var dbGrade = await _context.Grades.FirstOrDefaultAsync(n => n.Id == data.Id);
            
            if(dbGrade != null)
            {
                dbGrade.Grade1 = data.Grade1;
                dbGrade.Grade2 = data.Grade2;
                dbGrade.Grade3 = data.Grade3;
                dbGrade.Grade4 = data.Grade4;
                dbGrade.Grade5 = data.Grade5;
                dbGrade.SubjectId = data.SubjectId;                   
                await _context.SaveChangesAsync();
            }
        }
    }
}
