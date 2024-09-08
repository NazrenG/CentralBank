using CentralBank.Entities.Models;

namespace CentralBank.WepApi.Dtos
{
    public class ValTypeDto
    {
        public int Id { get; set; }
        public string? Type { get; set; } 
        public int ValCursId { get; set; }
    }
}
