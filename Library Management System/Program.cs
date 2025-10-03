using Library_Management_System.DbContexts;
using Library_Management_System.Helpers;
using Microsoft.EntityFrameworkCore;

namespace Library_Management_System
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using LibraryDbContext dbContext = new LibraryDbContext();

            #region DataSeed
            bool result = LibraryDbContextSeed.SeedData(dbContext);
            if (result)
                Console.WriteLine("data has been seeded");
            else
                Console.WriteLine("no data seeded");
            #endregion

            #region 1:Retrieve the book title, its category title , and the author’s full name for all books whose price is greater than 300.
            var Books = dbContext.Books
                                 .Where(b => b.Price > 300)
                                 .Select(b => new
                                 {
                                     bookTilt = b.Title,
                                     Category = b.BoookCategory.Title,
                                     Author = b.BookAuthor.FirstName + " " + b.BookAuthor.LastName
                                 })
                                 .ToList();

            foreach (var Book in Books)
            {
                Console.WriteLine(Book);
            }
            #endregion
            Console.WriteLine("---------------------------------\n");
            #region 2:Retrieve All Authors And His/Her Books if Exists. 
            var authorsBook = dbContext.Authors.Include(x => x.AuthorBooks).ToList();
            foreach (var Author in authorsBook)
            {
                Console.WriteLine($"Authors Name : {Author.FirstName} {Author.LastName} ");
                foreach (var Book in Author.AuthorBooks)
                {
                    Console.WriteLine($"{Book.Title} {Book.Price} {Book.TotalCopies}");
                }
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
            }
            #endregion
            Console.WriteLine("---------------------------------\n");

            #region 3:Member with id 1 Want To Borrow The Book With Id 2 And He Will Return it After 5 Days
            int memberId = 1;
            int bookId = 1;
            int borrowDays = 5;

            bool Borrowing = LoanManagement.BorrowingBook(memberId, bookId, borrowDays, dbContext);
            if (Borrowing)
                Console.WriteLine("Borrowing successfully");
            else
                Console.WriteLine("Borrowing Faild , Check Member Status | Book Availability");
            Console.WriteLine("\nTryBorroing With Suspended Member");
            memberId = 3;
            bookId = 2;
            borrowDays = 5;

            Borrowing = LoanManagement.BorrowingBook(memberId, bookId, borrowDays, dbContext);
            if (Borrowing)
                Console.WriteLine("Borrowing successfully");
            else
                Console.WriteLine("Borrowing Faild , Check Member Status | Book Availability");
            //Borrowing Faild , Check Member Status | Book Availability
            #endregion

            #region 4: After 10 Days Member with id 1 Returned The Book
             memberId = 1;
             bookId = 2;
            Console.WriteLine("\nReturning Book...");
            bool returned = LoanManagement.ReturnBook(memberId, bookId, dbContext);
            if (returned)
                Console.WriteLine("Book returned successfully ");
            else
                Console.WriteLine("Return failed ,Check if loan exists");
            #endregion
            Console.WriteLine("---------------------------------\n");

            #region 5: Retrieve all members who currently have active loans (i.e., loans that have not yet been returned)
            var activeMembers = dbContext.Members.Include(x => x.MemberLoans)
                .Where(x => x.MemberLoans.Any(l=>l.ReturnDate == null))
                .ToList();

            foreach (var member in activeMembers)
            {
                Console.WriteLine($"Member: {member.Name} (ID: {member.Id})");
            }
            #endregion
        }
    }
}
