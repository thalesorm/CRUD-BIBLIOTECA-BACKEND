using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Mapping
{
    public class BookMap
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.ToTable("Books");

            builder.HasKey(prop => prop.Id);

            builder.Property(prop => prop.Author)
                .HasColumnName("Author")
                .HasColumnType("varchar(250)")
                .IsRequired();

            builder.Property(prop => prop.Genre)
                .HasColumnName("Genre")
                .HasColumnType("varchar(250)")
                .IsRequired();

            builder.Property(prop => prop.Title)
                .HasColumnName("Title")
                .HasColumnType("varchar(250)")
                .IsRequired();


        }




    }
}
