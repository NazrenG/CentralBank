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
        public int Id {  get; set; }
       
        public DateTime? Date { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
         //one-to-many
        public List<ValType>? ValType { get; set; }
    }
}
