using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System.Models
{
    internal class Category : BaseEntity
    {
        #region Properties
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;


        #endregion
        #region Relatioship
        public ICollection<Book> CatogeryBooks { get; set; } = new HashSet<Book>(); 
        #endregion

    }
}
