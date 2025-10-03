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
    internal class MemberConfig : IEntityTypeConfiguration<Member>
    {
        public void Configure(EntityTypeBuilder<Member> builder)
        {
            #region Properties
            builder.Property(a => a.Name).
                        HasColumnType("varchar")
                        .HasMaxLength(50);

            builder.Property(a => a.Email).
                    HasColumnType("varchar")
                    .HasMaxLength(100);

            builder.Property(a => a.PhoneNumber).
                    HasColumnType("varchar")
                    .HasMaxLength(11);

            builder.Property(a => a.Address).
                    HasColumnType("varchar")
                    .HasMaxLength(100);
            builder.Property(a => a.MembershipDate)
                .HasDefaultValueSql("GETDATE()");

            builder.Property(a => a.Status)
                .HasConversion<string>()
                .HasColumnType("Varchar")
                .HasMaxLength(9);

            builder.ToTable(Tb =>
            {
                Tb.HasCheckConstraint("ValidEmailCheck", "Email like '_%@_%._%'");
                Tb.HasCheckConstraint("ValidPhoneNumberCheck", "PhoneNumber like '01%' and  PhoneNumber not like '%[^0-9]%'");
            }); 
            #endregion
        }
    }
}
