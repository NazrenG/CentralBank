using CentralBank.WepApi.Dtos;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Net.Http.Headers;
using System.Text;

namespace CentralBank.WepApi.Formatters
{
    public class VCardOutputFormatter : TextOutputFormatter
    {
        public VCardOutputFormatter()
        {
            SupportedMediaTypes.Add(MediaTypeHeaderValue.Parse("text/card"));
            SupportedEncodings.Add(Encoding.UTF8);
            SupportedEncodings.Add(Encoding.Unicode);
        }
        public override async Task WriteResponseBodyAsync(OutputFormatterWriteContext context, Encoding selectedEncoding)
        {
            var response = context.HttpContext.Response;
            var sb = new StringBuilder();
            sb.AppendLine("|  ID   |  CODE |                     NAME                   |  NOMINAL   |    VALUE   |");
            if (context.Object is IEnumerable<ValuteDto> list)
            {
                foreach (var item in list)
                {
                    FormatVCard(sb, item);
                }
            }
            else if (context.Object is ValuteDto valute)
            {
                FormatVCard(sb, valute);
            }
            await response.WriteAsync(sb.ToString());
        }

        private void FormatVCard(StringBuilder sb, ValuteDto item)
        {
            sb.AppendLine("------------------------------------------------------------------------------------------");
            sb.AppendLine($" {item.Id}   {item.Code?.PadLeft(10,' ')}    {item.Name?.PadRight(45,' ')}{item.Nominal?.PadRight(10,' ')}{item.Value?.PadRight(15,' ')}");
            
        }
    }
}
