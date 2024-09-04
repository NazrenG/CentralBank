using CentralBank.Core.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralBank.Entities.Models
{
    public class Valute:IEntity
    {
        public string? Nominal { get; set; }
        public string? Name { get; set; }
        public string? Value { get; set; }
        public string? _Code { get; set; }
    }
}
