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
    internal class BookConfig : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            #region Properties
            builder.Property((x => x.Title))
                    .HasColumnType("Varchar")
                    .HasMaxLength(50);

            builder.Property(x => x.Price)
                .HasPrecision(6, 2);

            builder.ToTable(tb =>
            {
                tb.HasCheckConstraint("PublicationYearCheck", "PublicationYear Between 1950 and Year(GetDate())");
                tb.HasCheckConstraint("AvailableCopiesCheck", "AvailableCopies <= TotalCopies");
            });
            #endregion
            #region Relationship

            builder.HasOne(b => b.BookAuthor)
                .WithMany(a => a.AuthorBooks)
                .HasForeignKey(a => a.AuthorId)
                .OnDelete(DeleteBehavior.Restrict);


            builder.HasOne(x=>x.BoookCategory)
                .WithMany(x=>x.CatogeryBooks)
                .HasForeignKey(x=>x.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);
            #endregion
        }
    }
}
