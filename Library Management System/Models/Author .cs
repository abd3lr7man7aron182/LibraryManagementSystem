using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System.Models
{
    internal class Author :BaseEntity
    {
        #region Properties
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public DateTime DateOfBirth { get; set; }
        #endregion

        #region Relationships

        public ICollection<Book> AuthorBooks { get; set; } = new HashSet<Book>();
        #endregion

    }
}
