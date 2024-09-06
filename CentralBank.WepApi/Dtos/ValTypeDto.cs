using CentralBank.Entities.Models;

namespace CentralBank.WepApi.Dtos
{
    public class ValTypeDto
    {
        public string? Type { get; set; }
        public List<ValuteDto>? Valutes { get; set; }
    }
}
