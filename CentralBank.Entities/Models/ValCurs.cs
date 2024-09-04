using CentralBank.Core.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralBank.Entities.Models
{
    public class ValCurs:IEntity
    {
        public List<ValType>? ValType { get; set; }
        public string? _Date { get; set; }
        public string? _Name { get; set; }
        public string? _Description { get; set; }
    }
}
