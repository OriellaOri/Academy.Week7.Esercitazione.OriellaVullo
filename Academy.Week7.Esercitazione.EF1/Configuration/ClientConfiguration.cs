using Academy.Week7.Esercitazione.Core1.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Academy.Week7.Esercitazione.EF1.Configuration
{
    public class ClientConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            /* PK */
            builder.HasKey(c => c.Id);

            /* proprietà richieste */
            builder.Property(c => c.ClientCode).IsRequired();
            builder.Property(c => c.Name).IsRequired();
            builder.Property(c => c.LastName).IsRequired();
        }
    }
}
