using Academy.Week7.Esercitazione.Core1.Entities;
using Academy.Week7.Esercitazione.EF1.Configuration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Academy.Week7.Esercitazione.EF1
{
    public class EsercitazioneContext : DbContext
    {
        //REST
        public EsercitazioneContext(DbContextOptions<EsercitazioneContext> options) : base(options) { }
        //WCF
        public EsercitazioneContext() : base() { }

        public DbSet<Order> Orders { get; set; }
        public DbSet<Client> Clients { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            {
                options.UseSqlServer(@"Data Source= (localdb)\MSSQLLocalDB;" +
                    "Initial Catalog = ESOrdini;" +
                    "Integrated Security=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new OrderConfiguration());
            modelBuilder.ApplyConfiguration(new ClientConfiguration());
        }
    }
}
