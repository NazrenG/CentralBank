using CentralBank.Business.Abstracts;
using CentralBank.Entities.Models;
using CentralBank.WepApi.Dtos;
using Microsoft.AspNetCore.Mvc;


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

            var valCursDto = valCurs.Select(v => new ValCursDto
            {
                Id = v.Id,
                Date = v.Date,
                Description = v.Description,
                Name = v.Name,
                ValTypeCount = v.ValType == null ? 0 : v.ValType.Count()
            }).ToList();

            return Ok(valCursDto);
        }


        [HttpGet("ValType")]
        public async Task<IActionResult> GetValType()
        {
            var valType = await valTypeService.GetAllAsync();

            var valTypeDto = valType.Select(p => new ValTypeDto
            {
                Id = p.Id,
                Type = p.Type,
              
            }).ToList();
            return Ok(valTypeDto);
        }

        [HttpGet("Valute")]
        public async Task<IActionResult> GetValute()
        {
            var value = await valuteService.GetAllAsync();
            var valueDto = value.Select(p => new ValuteDto
            {
                Id = p.Id,
                Name = p.Name,
                Nominal = p.Nominal,
                Code = p.Code,
                Value = p.Value
            }).ToList();


            return Ok(valueDto);
        }



        // POST api/<CurrencyController>
        // POST Valute.
        [HttpPost("Valute")]
        public async Task<IActionResult> Post([FromBody] ValutePostDto value)
        {
            var valute = new Valute
            {
                Name = value.Name,
                Code = value.Code,
                Nominal = value.Nominal,
                Value = value.Value,
                ValTypeId= value.ValTypeId
            };
           await valuteService.AddAsync(valute);
            //var valTyp = await valTypeService.GetByIdAsync(value.ValTypeId);
            //valTyp.Valute.Add(valute);

            return Ok(valute);
        }

        // POST ValType.
        [HttpPost("ValType")]
        public async Task<IActionResult> Post([FromBody] ValTypePostDto value)
        {
            var valuteType = new ValType
            {
                Type = value.Type,
                ValCursId = value.ValCursId,
            };
            
           await valTypeService.AddAsync(valuteType);
            //var valcurs = await valCursService.GetByIdAsync(value.ValCursId);
            //valcurs.ValType.Add(valuteType);

            return Ok(valuteType);
        }

        // POST ValCurs.
        [HttpPost("ValCurs")]
        public async Task<IActionResult> Post([FromBody] ValCursPostDto value)
        {
            var cursType = new ValCurs
            {
                Name=value.Name,
                Description=value.Description,
                Date = value.Date,
            };

           await  valCursService.AddAsync(cursType);
            

            return Ok(cursType);
        }

        // PUT api/<CurrencyController>/5
        [HttpPut("{id}/Value")]
        public async Task<IActionResult> Put(int id, [FromBody] ValutePostDto value)
        {
            var valute = await valuteService.GetByIdAsync(id);
            if (valute != null)
            {
                valute.Code = value.Code;
                valute.Nominal = value.Nominal;
                valute.Value = value.Value;
                valute.Name = value.Name;
                await valuteService.UpdateAsync(valute);
                return Ok(valute);
            }

            return NotFound();

        }
        [HttpPut("{id}/ValType")]
        public async Task<IActionResult> Put(int id, [FromBody] ValTypeDto value)
        {
           var valType=await valTypeService.GetByIdAsync(id);
            if (valType != null) {
                valType.Type = value.Type;

                //List<ValuteDto> List<Valute>-a cevrilir
                //valType.Valute = value.Valutes.Select(v => { return new Valute {Name=v.Name,Code=v.Code,Nominal=v.Nominal,Value=v.Value  }; }).ToList();
            await valTypeService.UpdateAsync(valType);
                return Ok(valType);
            }
            return NotFound();
        }

        [HttpPut("{id}/ValCurs")]
        public async Task<IActionResult> Put(int id, [FromBody] ValCursDto value)
        {
           var curs =await valCursService.GetByIdAsync(id);
            if (curs != null) {

                curs.Description = value.Description;
                curs.Date= value.Date;
                curs.Name = value.Name;
           await valCursService.UpdateAsync(curs);
                return Ok(curs);
            }

            return NotFound();
        }

        // DELETE api/<CurrencyController>/5
        [HttpDelete("{id}/Valute")]
        public async Task<IActionResult> Delete(int id)
        {
            var valute = await valuteService.GetByIdAsync(id);
            if (valute == null) return NotFound();
            await valuteService.DeleteAsync(valute);
            return Ok();
        }
        
        [HttpDelete("{id}/ValType")]
        public async Task<IActionResult> DeleteValType(int id)
        {
            var valute = await valTypeService.GetByIdAsync(id);
            if (valute == null) return NotFound();
            await valTypeService.DeleteAsync(valute);
            return Ok();
        } 

        [HttpDelete("{id}/ValCurs")]
        public async Task<IActionResult> DeleteValCurs(int id)
        {
            var valute = await valCursService.GetByIdAsync(id);
            if (valute == null) return NotFound();
            await valCursService.DeleteAsync(valute);
            return Ok();
        }
    }
}
