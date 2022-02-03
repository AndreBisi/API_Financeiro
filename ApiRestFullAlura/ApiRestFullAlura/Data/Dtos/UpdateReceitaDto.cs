using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRestFullAlura.Data.Dtos
{
    public class UpdateReceitaDto
    {
        [Required(ErrorMessage = "A descrição é obrigatória")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "O valor deve ser informado")]
        public decimal Valor { get; set; }

        [Required(ErrorMessage = "A data deve ser informada")]
        public DateTime Data { get; set; }
    }
}
