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

            var nameConverter = new ValueConverter<CustomerFirstName, string>(n => n.Value,
            n => new CustomerFirstName(n));

            var lastNameConverter = new ValueConverter<CustomerLastName, string>(ln => ln.Value,
           ln => new CustomerLastName(ln));

            var banckAccountConverter = new ValueConverter<CustomerBankAccount, string>(bac => bac.Value,
              bac => new CustomerBankAccount(bac));

            var dateOfBirthConverter = new ValueConverter<CustomerDateOfBirth, DateTime>(dob => dob.Value,
              dob => new CustomerDateOfBirth(dob));

            var emailConverter = new ValueConverter<CustomerEmail, string>(ce => ce.Value,
             ce => new CustomerEmail(ce));

            var phoneConverter = new ValueConverter<CustomerPhoneNumber, string>(cpn => cpn.Value,
            cpn => new CustomerPhoneNumber(cpn));

            builder
                .Property(pl => pl.Id)
                .HasConversion(id => id.Value, id => new CustomerId(id));

            builder
                .Property(typeof(CustomerFirstName), "_name")
                .HasConversion(nameConverter)
                .HasColumnName("Name");
            builder
                .Property(typeof(CustomerLastName), "_lastName")
                .HasConversion(lastNameConverter)
                .HasColumnName("LastName");
            builder
                .Property(typeof(CustomerDateOfBirth), "_dateOfBirth")
                .HasConversion(dateOfBirthConverter)
                .HasColumnName("DateOfBirth");
            builder
                .Property(typeof(CustomerPhoneNumber), "_phoneNumber")
                 .HasConversion(phoneConverter)
                .HasColumnName("PhoneNumber");
            builder
                .Property(typeof(CustomerEmail), "_email")
                .HasConversion(emailConverter)
                .HasColumnName("Email");
            builder
                .Property(typeof(CustomerBankAccount), "_bankAccount")
                .HasConversion(banckAccountConverter)
                .HasColumnName("BankAccount");

            builder.ToTable("Customer");
        }

    }
}
