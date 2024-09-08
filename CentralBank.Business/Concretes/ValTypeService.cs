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
    public class ValTypeService : IValTypeService
    {
        private readonly IValTypeDal valTypeDal;
        private readonly IValuteDal valuteDal;

        public ValTypeService(IValTypeDal valTypeDal)
        {
            this.valTypeDal = valTypeDal;
        }

        public async Task AddAsync(ValType val)
        {
          await valTypeDal.Add(val);
        }

        public async Task DeleteAsync(ValType val)
        {
           await valTypeDal.Delete(val);
            //var list = await valuteDal.GetList();
            //var sortedList=list.Where(v=>v.Id == val.Id).ToList();
            //await valuteDal.DeleteList(sortedList);
        }

        public async Task DeleteList(List<ValType> list)
        {
           await valTypeDal.DeleteList(list);

            
        }

        public async Task<List<ValType>> GetAllAsync()
        {
           return await valTypeDal.GetList();
        }

        public async Task<ValType> GetByIdAsync(int id)
        {
           return await valTypeDal.Get(v=>v.Id == id);
        }

        public async Task UpdateAsync(ValType val)
        {
            await valTypeDal.Update(val);
        }
    }
}
