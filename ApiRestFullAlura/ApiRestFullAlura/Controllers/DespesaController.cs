using ApiRestFullAlura.Data;
using ApiRestFullAlura.Data.Dtos;
using ApiRestFullAlura.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRestFullAlura.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DespesaController : ControllerBase
    {
        private FinanceiroContext _context;
        private IMapper _mapper;

        public DespesaController(FinanceiroContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AdicionaDespesa([FromBody] CreateDespesaDto despesaDto)
        {
            Despesa despesa = _mapper.Map<Despesa>(despesaDto);

            _context.Despesas.Add(despesa);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecuperaDespesaPorId), new { Id = despesa.Id }, despesa);
        }

        [HttpGet]
        public IEnumerable<Despesa> RecuperaDespesa()
        {
            return _context.Despesas;
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaDespesaPorId(int id)
        {
            Despesa despesa = _context.Despesas.FirstOrDefault(despesa => despesa.Id == id);
            if (despesa != null)
            {
                ReadDespesaDto despesaDto = _mapper.Map<ReadDespesaDto>(despesa);
                return Ok(despesa);
            }
            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaDespesa(int id, [FromBody] UpdateDespesaDto despesaDto)
        {
            Despesa despesa = _context.Despesas.FirstOrDefault(despesa => despesa.Id == id);
            if (despesa == null)
            {
                return NotFound();
            }
            _mapper.Map(despesaDto, despesa);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletaDespesa(int id)
        {
            Despesa despesa = _context.Despesas.FirstOrDefault(despesa => despesa.Id == id);
            if (despesa == null)
            {
                return NotFound();
            }
            _context.Remove(despesa);
            _context.SaveChanges();
            return NoContent();
        }

    }
}
