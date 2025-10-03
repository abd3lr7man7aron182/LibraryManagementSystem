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
    internal class FineConfig : IEntityTypeConfiguration<Fine>
    {
        public void Configure(EntityTypeBuilder<Fine> builder)
        {
            #region Properties
            builder.Property(f => f.Amount)
                    .HasPrecision(6, 2);
            builder.Property(l => l.Status)
                .HasConversion<string>()
                .HasColumnType("varchar")
                .HasMaxLength(7);

            builder.Property(l => l.IssuedDate)
                    .HasDefaultValueSql("GETDATE()");
            #endregion
            #region relationship

            builder.HasOne(x => x.loan)
                .WithOne(x => x.fine)
                .HasForeignKey<Fine>(x => x.LoanId);
            #endregion
        }
    }
}
