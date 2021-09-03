using Academy.Week7.Esercitazione.Core1.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Academy.Week7.Esercitazione.EF1.Configuration
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            /* PK */
            builder.HasKey(o => o.Id);

            /* proprietà richieste */
            builder.Property(o => o.DateOrder).IsRequired();
            builder.Property(o => o.OrderCode).IsRequired();
            builder.Property(o => o.Amount).IsRequired();
            builder.Property(o =>o.IdClient).IsRequired();

            /* un ordine ha un cliente || un cliente ha tanti ordini || FK tramite ID del cliente */
            builder.HasOne(o => o.Client).WithMany(c => c.Orders).HasForeignKey(o => o.IdClient);
        }
    
    }
}
