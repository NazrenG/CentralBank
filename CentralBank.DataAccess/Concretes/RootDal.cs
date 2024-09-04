using CentralBank.Core.DataAccess.EntityFramework;
using CentralBank.DataAccess.Abstracts;
using CentralBank.Entities.Data;
using CentralBank.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralBank.DataAccess.Concretes
{
    public class RootDal : EFEntityRepositoryBase<Root, CentralBankDbContext>, IRootDal
    {
        public RootDal(CentralBankDbContext context) : base(context)
        {
        }
    }
}
