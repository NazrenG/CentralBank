using CentralBank.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralBank.Business.Abstracts
{
    public interface IValuteService
    {
        Task<List<Valute>> GetAllAsync();
        Task AddAsync(Valute val);
        Task UpdateAsync(Valute val);
        Task DeleteAsync(Valute val);
        Task<Valute> GetByIdAsync(int id);
    }
}
