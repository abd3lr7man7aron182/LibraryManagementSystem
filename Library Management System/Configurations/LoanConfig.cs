using Library_Management_System.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System.Configurations
{
    internal class LoanConfig : IEntityTypeConfiguration<Loan>
    {
        public void Configure(EntityTypeBuilder<Loan> builder)
        {
            #region Properties
            builder.Property(l => l.LoanDate)
                    .HasDefaultValueSql("GETDATE()");


            builder.Property(l => l.Status)
                .HasConversion<string>()
                .HasColumnType("varchar")
                .HasMaxLength(8); 
            #endregion
        }
    }
}
