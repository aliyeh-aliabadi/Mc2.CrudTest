using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mc2.CrudTest.Domain.Entities;
using Mc2.CrudTest.Domain.ValueObjects;

namespace Mc2.CrudTest.Infrastructure.EF.Config
{
    internal sealed class WriteConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(c => c.Id);


            builder
                .Property(pl => pl.Id)
                .HasConversion(id => id.Value, id => new CustomerId(id));

            builder
                .Property(typeof(string), "_name")
                .HasColumnName("FirstName");
            builder
                .Property(typeof(string), "_lastName")
                .HasColumnName("LastName");
            builder
    .Property(typeof(string), "_dateOfBirth")
    .HasColumnName("DateOfBirth");
            builder
    .Property(typeof(string), "_phoneNumber")
    .HasColumnName("PhoneNumber");
            builder
    .Property(typeof(string), "_email")
    .HasColumnName("Email");
            builder
    .Property(typeof(string), "_bankAccountNumber")
    .HasColumnName("BankAccountNumber");

            builder.ToTable("Customer");
        }

    }
}
