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
    public class ValuteService : IValuteService
    {
        private readonly IValuteDal valuteDal;

        public ValuteService(IValuteDal _valuteDal)
        {
            this.valuteDal = _valuteDal;
        }

        public async Task AddAsync(Valute val)
        {
            await valuteDal.Add(val);
        }

        public async Task DeleteAsync(Valute val)
        {
            await valuteDal.Delete(val);
        }

        public async Task<List<Valute>> GetAllAsync()
        {
            return await valuteDal.GetList();
        }

        public async Task<Valute> GetByIdAsync(int id)
        {
            return await valuteDal.Get(p => p.Id == id);
        }

        public async Task UpdateAsync(Valute val)
        {
            await valuteDal.Update(val);
        }
    }
}
