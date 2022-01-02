using Darbas.Data.Base;
using Darbas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Darbas.Data.Services
{
    public interface IStudentsService:IEntityBaseRepository<Student>
    {
    }
}
