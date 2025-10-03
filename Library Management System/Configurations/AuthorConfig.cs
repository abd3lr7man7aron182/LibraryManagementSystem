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
    internal class AuthorConfig : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            #region Properties
            builder.Property(a => a.FirstName).
                    HasColumnType("varchar")
                    .HasMaxLength(20);

            builder.Property(a => a.LastName).
                HasColumnType("varchar")
                .HasMaxLength(20); 
            #endregion
        }
    }
}
