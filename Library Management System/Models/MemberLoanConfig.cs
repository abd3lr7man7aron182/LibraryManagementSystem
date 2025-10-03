using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System.Models
{
    internal class MemberLoanConfig : IEntityTypeConfiguration<MemberLoan>
    {
        public void Configure(EntityTypeBuilder<MemberLoan> builder)
        {
            builder.HasKey(m => new { m.MemberId, m.LoanId, m.BookId });
        }
    }
}
