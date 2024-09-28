
using ReadStack.Core.Entities;

namespace ReadStack.Application.Models;

public class CreateUserInputModel
{
    public string FullName { get; set; }
    public DateTime Birthdate { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }

    public User ToEntity()
        => new(FullName, Birthdate, Email, Phone, true);
}