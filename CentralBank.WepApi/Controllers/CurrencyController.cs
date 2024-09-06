using CentralBank.Business.Abstracts;
using CentralBank.Entities.Data;
using CentralBank.Entities.Models;
using CentralBank.WepApi.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CentralBank.WepApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrencyController : ControllerBase
    {
        private readonly IValuteService valuteService;
        private readonly IValTypeService valTypeService;
        private readonly IValCursService valCursService;

        public CurrencyController(IValuteService valuteService, IValTypeService valTypeService, IValCursService valCursService)
        {
            this.valuteService = valuteService;
            this.valTypeService = valTypeService;
            this.valCursService = valCursService;
        }




        // GET: api/<CurrencyController>
        [HttpGet("ValCurs")]
        public async Task<IActionResult> GetAll()
        {
            var valCurs = await valCursService.GetAllAsync();

            var valCursDto=valCurs.Select(v=>new ValCursDto
            {
                Date = v.Date,
                Description = v.Description,
                Name = v.Name,
                ValTypes=v.ValType?.Select(p=>new ValTypeDto
                {
                    Type = p.Type,
                    Valutes=p.Valute?.Select(x=>new ValuteDto
                    {
                        Code = x.Code,
                        Name = x.Name,
                        Nominal=x.Nominal,
                        Value=x.Value
                    }).ToList()
                }).ToList(),
            }).ToList();    

            return Ok(valCursDto); 
        }


        [HttpGet("ValType")]
        public async Task<IActionResult> GetValType()
        {
            var valType = await valTypeService.GetAllAsync();

            var valTypeDto = valType.Select(p => new ValTypeDto
            {
                Type = p.Type,
                Valutes = p.Valute?.Select(x => new ValuteDto
                {
                    Code = x.Code,
                    Name = x.Name,
                    Nominal = x.Nominal,
                    Value = x.Value
                }).ToList()
            }).ToList();
            return Ok(valTypeDto);  
        }

        [HttpGet("Valute")]
        public async Task<IActionResult> GetValCurs()
        {
            var value = await valuteService.GetAllAsync();
            var valueDto = value.Select(p => new ValuteDto
            {
                Name = p.Name,
                Nominal = p.Nominal,
                Code = p.Code,
                Value = p.Value
            }).ToList(); 


            return Ok(valueDto);   
        }

      

        // POST api/<CurrencyController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<CurrencyController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CurrencyController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
