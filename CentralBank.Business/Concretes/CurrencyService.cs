using CentralBank.Entities.Data;
using CentralBank.Entities.Models;
using System.Xml.Linq;

namespace CentralBank.Business.Concretes
{
    public class CurrencyService 
    {
        private readonly CentralBankDbContext centralBankDbContext;
        private readonly HttpClient _httpClient;

        public CurrencyService(CentralBankDbContext centralBankDbContext, HttpClient httpClient)
        {
            this.centralBankDbContext = centralBankDbContext;
            _httpClient = httpClient;
        }
        //url-den xml metodlarini elde etmek
        public async Task<string?> GetXmlDataFromUrl()
        {
            string url = "https://www.cbar.az/currencies/02.09.2024.xml";
            HttpResponseMessage response = await _httpClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }
            return null;
        }

        // xml melumatlarinin obyekt strukturuna cevrilmesi
        public Root ParseXmlData(string xmlData)
        {
            //xml melumatlarini oz sinifinde tehlil edir
            XDocument xmlDoc = XDocument.Parse(xmlData);

            var root = new Root
            {
                ValCurs = new ValCurs
                {
                    Date = DateTime.Parse(xmlDoc.Root?.Attribute("Date")?.Value ?? DateTime.Now.ToString()),
                    Name = xmlDoc.Root?.Attribute("Name")?.Value,
                    ValType = xmlDoc.Root?.Elements("ValType").Select(valType => new ValType
                    {
                        Type = valType.Attribute("Type")?.Value,
                        Valute = valType.Elements("Valute").Select(valute => new Valute
                        {
                            Code = valute.Attribute("Code")?.Value,
                            Name = valute.Element("Name")?.Value,
                            Value = valute.Element("Value")?.Value,
                            Nominal = valute.Element("Nominal")?.Value
                        }).ToList()
                    }).ToList()
                }
            };

            return root;
        }


        // db-e table-lari elave etmek
        public async Task StoreCurrencyData(Root root)
        {
            if (root?.ValCurs != null)
            {
                // db saxlamaq ucun valcurs obyekti yaradiriq
                var valCurs = new ValCurs
                {
                    Date = root.ValCurs.Date,
                    Name = root.ValCurs.Name,
                    Description = root.ValCurs.Description,
                    ValType = new List<ValType>()
                };

                // Her bir ValType'ı ValCurs'a elave edirik
                if (root.ValCurs.ValType != null)
                {
                    foreach (var valTypeData in root.ValCurs.ValType)
                    {
                        var valType = new ValType
                        {
                            Type = valTypeData.Type,
                            Valute = new List<Valute>()
                        };

                        // Her ValType ucun onunla elaqeli Valute elave edirik
                        if (valTypeData.Valute != null)
                        {
                            foreach (var valuteData in valTypeData.Valute)
                            {
                                var valute = new Valute
                                {
                                    Code = valuteData.Code,
                                    Name = valuteData.Name,
                                    Value = valuteData.Value,
                                    Nominal = valuteData.Nominal
                                };

                                // Valute'ı ValType'a elave edirik
                                valType.Valute.Add(valute);
                            }
                        }

                        // ValType'ı ValCurs'a elave edirik
                        valCurs.ValType.Add(valType);
                    }
                }

                // DB-e ValCurs'ı ve onunla elaqeli ValType/Valute'ları elave edirik
                centralBankDbContext.ValCurs.Add(valCurs);
                await centralBankDbContext.SaveChangesAsync();
            }
        }


    }
}
