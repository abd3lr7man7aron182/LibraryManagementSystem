using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System.Models
{
    internal class MemberLoan
    {
        #region Properties
        public DateTime DueDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        #endregion


        #region Relationship
        public int BookId { get; set; }
        public Book Book { get; set; } = null!;

        public int LoanId { get; set; }

        public Loan loan { get; set; } = null!;


        public int MemberId { get; set; }

        public Member Member { get; set; } = null!;

        #endregion

    }
}
