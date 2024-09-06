using CentralBank.Business.Abstracts;
using CentralBank.DataAccess.Abstracts;
using CentralBank.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralBank.Business.Concretes
{
    public class ValCursService : IValCursService
    {
        private readonly IValCursDal valCursDal;

        public ValCursService(IValCursDal valCursDal)
        {
            this.valCursDal = valCursDal;
        }

        public async Task AddAsync(ValCurs val)
        {
            await valCursDal.Add(val);
        }

        public async Task DeleteAsync(ValCurs val)
        {
            await valCursDal.Delete(val);
        }

        public async Task<List<ValCurs>> GetAllAsync()
        {
            return await valCursDal.GetList();
        }

        public async Task<ValCurs> GetByIdAsync(int id)
        {
            return await valCursDal.Get(v => v.Id == id);
        }

        public async Task UpdateAsync(ValCurs val)
        {
            await valCursDal.Update(val);
        }
    }
}
