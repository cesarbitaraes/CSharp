using Flunt.Validations;
using PaymentContext.Shared.ValueObjects;

namespace PaymentContext.Domain.ValueObjects;

public class Name : ValueObject
{
    public Name(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
        
        
       AddNotifications(new Contract<string>()
           .Requires()
           .IsGreaterThan(FirstName, 3, "Name.FirstName", "Nome deve conter pelo menos 3 caracteres")
           .IsGreaterThan(LastName, 3, "Name.LastName","Sobrenome deve conter pelo menos 3 caracteres")
           .IsLowerOrEqualsThan(FirstName, 40, "Name.FirstName", "Nome deve conter até 40 caracteres"));
    }

    public string FirstName { get; set; }
    public string LastName { get; set; }

    public override string ToString()
    {
        return $"{FirstName} {LastName}";
    }
}