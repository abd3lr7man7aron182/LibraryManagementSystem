using Library_Management_System.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System.Models
{
    internal class Fine : BaseEntity
    {
        #region Properties
        public int Amount { get; set; }
        public DateTime IssuedDate { get; set; }
        public DateTime PaidDate { get; set; }
        public FineStatus Status { get; set; }
        #endregion
        #region Relationship
        public int LoanId { get; set; }
        public Loan loan { get; set; } = null!;
        #endregion

    }
}
