using Library_Management_System.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System.Models
{
    internal class Member :BaseEntity
    {
        #region Properties
        public string Name { get; set; } = null!;
        public String Email { get; set; } = null!;
        public String PhoneNumber { get; set; } = null!;
        public String Address { get; set; } = null!; 
        public DateTime MembershipDate { get; set; }
        public MemberStatus Status { get; set; }
        #endregion

        #region Relationships
        public ICollection<MemberLoan> MemberLoans { get; set; } = new HashSet<MemberLoan>();
        #endregion
    }
}
