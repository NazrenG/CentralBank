using CentralBank.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralBank.Business.Abstracts
{
    public interface IValTypeService
    {
        Task<List<ValType>> GetAllAsync();
        Task AddAsync(ValType val);
        Task UpdateAsync(ValType val);
        Task DeleteAsync(ValType val);
        Task DeleteList(List<ValType> list);
        Task<ValType> GetByIdAsync(int id);
    }
}
