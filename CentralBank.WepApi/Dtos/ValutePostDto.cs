namespace CentralBank.WepApi.Dtos
{
    public class ValutePostDto
    {
        public string? Nominal { get; set; }
        public string? Name { get; set; }
        public string? Value { get; set; }
        public string? Code { get; set; }
        public int ValTypeId { get; set; }

    }
}
