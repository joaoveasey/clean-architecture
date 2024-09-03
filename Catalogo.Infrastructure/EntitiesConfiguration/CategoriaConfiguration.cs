using Catalogo.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalogo.Infrastructure.EntitiesConfiguration
{
    public class CategoriaConfiguration : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Nome).HasMaxLength(100).IsRequired();
            builder.Property(p => p.ImagemUrl).HasMaxLength(100).IsRequired();

            builder.HasData(
                new Categoria (1, "Smartphones", "smartphones.jpg"),
                new Categoria (2, "Notebooks", "notebooks.jpg"),
                new Categoria (3, "Monitores", "monitores.jpg"),
                new Categoria (4, "Tablets", "tablets.jpg"),
                new Categoria (5, "Smartwatches", "smartwatches.jpg")
            );
        }
    }
}
