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
    public class UserMap
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");

            builder.HasKey(prop => prop.Id);

            builder.Property(prop => prop.Name)
                .HasColumnName("Name")
                .HasColumnType("varchar(250)")
                .IsRequired();

            builder.Property(prop => prop.CPF)
                .HasColumnName("CPF")
                .HasColumnType("varchar(11)")
                .IsRequired();

            builder.Property(prop => prop.Email)
                .HasColumnName("Email")
                .HasColumnType("varchar(250)")
                .IsRequired();

            builder.Property(prop => prop.Telephone)
                .HasColumnName("Telephone")
                .HasColumnType("varchar(13)")
                .IsRequired();

            builder.Property(prop => prop.NickName)
                .HasColumnName("NickName")
                .HasColumnType("varchar(250)")
                .IsRequired();

            builder.Property(prop => prop.Password)
                .HasColumnName("Password")
                .HasColumnType("varchar(10)")
                .IsRequired();
        }
    }
}
