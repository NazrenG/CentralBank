using CentralBank.Entities.Models;

namespace CentralBank.WepApi.Dtos
{
    public class ValCursDto
    {
        public DateTime? Date { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }

        public List<ValTypeDto>? ValTypes { get; set; }
    }
}
