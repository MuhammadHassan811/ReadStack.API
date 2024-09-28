using ReadStack.Core.Entities;

namespace ReadStack.Application.Models;

public class UsersViewModel
{
    public UsersViewModel(string fullName, DateTime birthdate, string email, string phone, List<string> loans)
    {
        FullName = fullName;
        Birthdate = birthdate;
        Email = email;
        Phone = phone;
        Loans = loans;
    }

    public string FullName { get; private set; }
    public DateTime Birthdate { get; private set; }
    public string Email { get; private set; }
    public string Phone { get; private set; }
    public List<string> Loans { get; set; }

    public static UsersViewModel FromEntity(User user)
    {
        var loans = user.Loans.Select(u => u.Book).Select(b => b.Title).ToList();

        return new UsersViewModel(user.FullName, user.Birthdate, user.Email, user.Phone, loans);
    }
}