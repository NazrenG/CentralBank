using CentralBank.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralBank.Business.Abstracts
{
    public interface IValCursService
    {
        Task<List<ValCurs>> GetAllAsync();
         Task AddAsync(ValCurs val);
        Task UpdateAsync(ValCurs val);
        Task DeleteAsync(ValCurs val);
        Task<ValCurs> GetByIdAsync(int id);
    }
}
