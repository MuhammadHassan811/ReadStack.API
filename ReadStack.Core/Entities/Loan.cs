
using ReadStack.Core.Enums;

namespace ReadStack.Core.Entities;

public class Loan : BaseEntity
{
    public Loan(int bookId, int userId, decimal cost)
    : base()
    {
        BookId = bookId;
        UserId = userId;
        Status = LoanStatusEnum.Available;
        Cost = cost;
    }

    public int Id { get; private set; }
    public DateTime LoanDate { get; private set; }
    public DateTime ReturnDate { get; private set; }
    public LoanStatusEnum Status { get; private set; }
    public decimal Cost { get; private set; }

    public int BookId { get; private set; }
    public Book Book { get; private set; }
    public int UserId { get; private set; }
    public User User { get; private set; }

    public void Lend()
    {
        if (Status == LoanStatusEnum.Available)
        {
            Status = LoanStatusEnum.Borrowed;
            LoanDate = DateTime.Now;
            ReturnDate = LoanDate.AddDays(7);
        }
    }

    public void Returned()
    {
        if (Status == LoanStatusEnum.Borrowed)
        {
            Status = LoanStatusEnum.Returned;
        }
    }

    public void Fees()
    {
        if (Status == LoanStatusEnum.Late)
        {
            Cost = Cost + 10;
        }
    }

    public void Unavailable()
    {
        if (Status == LoanStatusEnum.None || Status == LoanStatusEnum.Unavailable)
        {
            Status = LoanStatusEnum.Unavailable;
        }
    }

    public void Update(int bookId, decimal cost)
    {
        BookId = bookId;
        Cost = cost;
    }
}