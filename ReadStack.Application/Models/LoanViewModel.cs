using ReadStack.Core.Entities;

namespace ReadStack.Application.Models
{
    public class LoanViewModel
    {
        public LoanViewModel(
            string title, string fullName, DateTime loanDate, 
            DateTime returnDate, decimal cost, int bookId, int userId)
        {
            Title = title;
            FullName = fullName;
            LoanDate = loanDate;
            ReturnDate = returnDate;
            Cost = cost;
            BookId = bookId;
            UserId = userId;
        }

        public string Title { get; set; }
        public string FullName { get; set; }
        public DateTime LoanDate { get; private set; }
        public DateTime ReturnDate { get; private set; }
        public decimal Cost { get; private set; }
        public int BookId { get; private set; }
        public int UserId { get; private set; }

        public static LoanViewModel FromEntity(Loan loan)
                => new(loan.Book.Title, loan.User.FullName, loan.LoanDate, loan.ReturnDate, loan.Cost, loan.BookId, loan.UserId);
    }
}
