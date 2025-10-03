using Library_Management_System.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System.Configurations
{
    internal class CategoryConfig : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            #region Properties
            builder.Property(C => C.Title).
                    HasColumnType("Varchar")
                    .HasMaxLength(50);

            builder.Property(c => c.Description).
                HasColumnType(("Varchar"))
                .HasMaxLength(100); 
            #endregion
        }
    }
}
