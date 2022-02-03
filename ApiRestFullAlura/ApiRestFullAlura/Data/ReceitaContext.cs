using ApiRestFullAlura.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRestFullAlura.Data
{
    public class ReceitaContext : DbContext
    {
        public ReceitaContext(DbContextOptions<ReceitaContext> opt) : base(opt)
        {
        }

        public DbSet<Receita> Receitas { get; set; }
    }
}
