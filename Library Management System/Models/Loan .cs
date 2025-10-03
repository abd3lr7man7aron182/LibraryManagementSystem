using Library_Management_System.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System.Models
{
    internal class Loan :BaseEntity
    {
        #region Properties
        public DateTime LoanDate { get; set; }
        public LoanStatus Status { get; set; }
        #endregion

        #region Relationship

        public Fine? fine { get; set; }


        public ICollection<MemberLoan> LoanBooks { get; set; }= new HashSet<MemberLoan>();
        #endregion
    }
}
