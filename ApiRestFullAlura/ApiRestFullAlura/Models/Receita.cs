using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRestFullAlura.Models
{
    public class Receita
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "A descrição é obrigatória")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "O valor deve ser informado")]
        public decimal Valor { get; set; }

        [Required(ErrorMessage = "A data deve ser informada")]
        public DateTime Data { get; set; }
    }
}
