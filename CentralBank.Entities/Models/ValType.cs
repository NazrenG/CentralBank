using CentralBank.Core.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralBank.Entities.Models
{
    public class ValType:IEntity
    {
        public int Id {  get; set; }
   
        public string? Type { get; set; }
        //foreign key
        public int ValCursId {  get; set; }
        public ValCurs Curs { get; set; }   
        // one-to-many
        public List<Valute>? Valute { get; set; }
    }
}
