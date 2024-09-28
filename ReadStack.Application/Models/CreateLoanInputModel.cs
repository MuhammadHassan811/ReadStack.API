using ReadStack.Core.Entities;

namespace ReadStack.Application.Models;

public class CreateLoanInputModel
{
    public int BookId { get; set; }
    public int UserId { get; set; }
    public decimal Cost { get; set; }
    public Loan ToEntity()
        => new Loan(BookId, UserId, Cost);
}