using Library_Management_System.DbContexts;
using Library_Management_System.Models;
using Library_Management_System.Models.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System.Helpers
{
    internal static class LoanManagement
    {
        public static bool BorrowingBook(int MemberId, int BookId, int BorrowDays,LibraryDbContext dbContext)
        {
            try
            {
                var Member = dbContext.Members.Find(MemberId);
                if (Member is null || Member.Status ==Models.Enums.MemberStatus.Suspended)return false;

                var Book = dbContext.Books.Find(BookId);
                if(Book is null || Book.AvailableCopies==0)return false;

                Loan loan = new Loan();
                dbContext.Loans.Add(loan);


                MemberLoan memberLoan = new MemberLoan()
                {
                    MemberId = MemberId,
                    BookId = BookId,
                    loan = loan,
                    DueDate = DateTime.Now.AddDays(BorrowDays)
                };

                dbContext.MemberLoans.Add(memberLoan);
                Book.AvailableCopies -= 1; 
                 return dbContext.SaveChanges() > 0;

            }
            catch(Exception ex) 
            {
                Console.WriteLine(ex);
                return false;
            }
        }
        //public static bool ReturnBook(int memberId, int bookId, LibraryDbContext dbContext)
        //{
        //    try
        //    {
        //        // 1. Find the active loan (not yet returned)
        //        var memberLoan = dbContext.MemberLoans
        //            .FirstOrDefault(ml => ml.MemberId == memberId
        //                               && ml.BookId == bookId
        //                               && ml.ReturnDate == null);

        //        if (memberLoan == null)
        //            return false; // No active loan

        //        // 2. Update return date
        //        memberLoan.ReturnDate = DateTime.Now;

        //        // 3. Restore book copies
        //        var book = dbContext.Books.Find(bookId);
        //        if (book != null)
        //            book.AvailableCopies += 1;

        //        // 4. Check if overdue
        //        if (memberLoan.ReturnDate > memberLoan.DueDate)
        //        {
        //            int overdueDays = (memberLoan.ReturnDate.Value - memberLoan.DueDate).Days;

        //            // Fine = overdue days * 10% of book price
        //            int fineAmount = (int)(overdueDays * (0.1m * book.Price));

        //            // Create Fine record
        //            var fine = new Fine()
        //            {
        //                LoanId = memberLoan.LoanId,
        //                Amount = fineAmount,
        //                IssuedDate = DateTime.Now,
        //                PaidDate = DateTime.MinValue, // Not paid yet
        //                Status = FineStatus.Pending
        //            };
        //            dbContext.Fines.Add(fine);

        //            // Suspend member
        //            var member = dbContext.Members.Find(memberId);
        //            if (member != null)
        //                member.Status = MemberStatus.Suspended;

        //            // Loan status = Overdue
        //            memberLoan.loan.Status = LoanStatus.Overdue;
        //        }
        //        else
        //        {
        //            // Returned on time
        //            memberLoan.loan.Status = LoanStatus.Returned;
        //        }

        //        // 5. Save changes
        //        return dbContext.SaveChanges() > 0;
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine($"Error returning book: {ex.Message}");
        //        return false;
        //    }
        //}

        public static bool ReturnBook(int memberId, int bookId, LibraryDbContext dbContext)
        {
            try
            {
                
                var memberLoan = dbContext.MemberLoans
                    .Include(ml => ml.loan)
                    .FirstOrDefault(ml => ml.MemberId == memberId
                                       && ml.BookId == bookId
                                       && ml.ReturnDate == null);

                if (memberLoan == null)
                    return false; 

                
                memberLoan.ReturnDate = DateTime.Now;

                
                var book = dbContext.Books.Find(bookId);
                if (book != null)
                    book.AvailableCopies += 1;

                
                if (memberLoan.ReturnDate > memberLoan.DueDate)
                {
                    int overdueDays = (memberLoan.ReturnDate.Value - memberLoan.DueDate).Days;
                    int fineAmount = (int)(overdueDays * (0.1m * book.Price));

                    var fine = new Fine()
                    {
                        LoanId = memberLoan.LoanId,
                        Amount = fineAmount,
                        IssuedDate = DateTime.Now,
                        PaidDate = DateTime.MinValue, 
                        Status = FineStatus.Pending
                    };
                    dbContext.Fines.Add(fine);

                    
                    var member = dbContext.Members.Find(memberId);
                    if (member != null)
                        member.Status = MemberStatus.Suspended;

                    
                    memberLoan.loan.Status = LoanStatus.Overdue;
                }
                else
                {
                    
                    memberLoan.loan.Status = LoanStatus.Returned;
                }

                return dbContext.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }


    }
}
