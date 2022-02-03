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
    public class ReceitaController : ControllerBase
    {
        private ReceitaContext _context;
        private IMapper _mapper;

        public ReceitaController(ReceitaContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AdicionaReceita([FromBody]CreateReceitaDto receitaDto)
        {
            Receita receita = _mapper.Map<Receita>(receitaDto);

            _context.Receitas.Add(receita);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecuperaReceitaPorId), new { Id = receita.Id}, receita);
        }

        [HttpGet]
        public IEnumerable<Receita> RecuperaReceita()
        {
            return _context.Receitas;
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaReceitaPorId(int id) 
        {
            Receita receita = _context.Receitas.FirstOrDefault(receita => receita.Id == id);
            if(receita != null)
            {
                ReadReceitaDto receitaDto = _mapper.Map<ReadReceitaDto>(receita);
                return Ok(receita);
            }
            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaReceita(int id, [FromBody] UpdateReceitaDto receitaDto)
        {
            Receita receita = _context.Receitas.FirstOrDefault(receita => receita.Id == id);
            if (receita == null)
            {
                return NotFound();
            }
            _mapper.Map(receitaDto, receita);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletaReceita(int id)
        {
            Receita receita = _context.Receitas.FirstOrDefault(receita => receita.Id == id);
            if (receita == null)
            {
                ReadReceitaDto receitaDto = new ReadReceitaDto
                {
                    Descricao = receita.Descricao,
                    Valor = receita.Valor,
                    Data = receita.Data,
                    Id = receita.Id
                };
                return NotFound();
            }
            _context.Remove(receita);
            _context.SaveChanges();
            return NoContent();

        }
    }
}
