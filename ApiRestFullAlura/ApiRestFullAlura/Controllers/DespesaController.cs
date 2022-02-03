using ApiRestFullAlura.Models;
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
        private static List<Despesa> despesas = new List<Despesa>();

        [HttpPost]
        public void AdicionaDespesa(Despesa despesa)
        {
            despesas.Add(despesa);
        }
    }
}
