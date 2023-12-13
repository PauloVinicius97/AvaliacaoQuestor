using AvaliacaoQuestor.Domain.Entities;
using AvaliacaoQuestor.Infra.Data.Mappings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaliacaoQuestor.Infra.Data.Context
{
    public class AvaliacaoQuestorContext : DbContext
    {
        public DbSet<Banco>? Bancos { get; set; }
        public DbSet<Boleto>? Boletos { get; set; }

        public AvaliacaoQuestorContext(DbContextOptions<AvaliacaoQuestorContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BancoMap());
            modelBuilder.ApplyConfiguration(new BoletoMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
