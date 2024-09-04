using CentralBank.Core.DataAccess;
using CentralBank.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralBank.DataAccess.Abstracts
{
    public interface IValCursDal:IEntityRepository<ValCurs>
    {
    }
}
