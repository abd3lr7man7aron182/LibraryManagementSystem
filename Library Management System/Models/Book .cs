using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System.Models
{
    internal class Book : BaseEntity
    {
        #region Properties
        public string Title { get; set; } = null!;
        public Decimal Price { get; set; }
        public int PublicationYear { get; set; }

        public int AvailableCopies { get; set; }
        public int TotalCopies { get; set; }
        #endregion

        #region Relationships

        #region Book - Auther  relationship
        public  int AuthorId { get; set; }
        public Author BookAuthor { get; set; } =null!;
        #endregion

        #region Book - Category relationship
        public  int CategoryId { get; set; }
        public  Category BoookCategory { get; set; }
        #endregion

        #region Book - MemberLoan relationship

        public ICollection<MemberLoan> BookLoans { get; set; } = new HashSet<MemberLoan>();
        #endregion
        #endregion

    }
}
