using Darbas.Data.Base;
using Darbas.Data.ViewModels;
using Darbas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Darbas.Data.Services
{
    public interface IGradesService:IEntityBaseRepository<Grade>
    {
        Task<Grade> GetGradeByIdAsync(int id);
        Task<NewGradeDropdownsVM> GetNewGradeDropdownsValues();
        Task AddNewGradeAsync(NewGradeVM data);
        Task UpdateGradeAsync(NewGradeVM data);
    }
}
