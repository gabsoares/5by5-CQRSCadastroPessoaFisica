namespace _5by5.CQRS.Domain.Entities.v1;

public class Person
{
    public Person()
    {
        Id = Guid.NewGuid();
    }
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Document { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public DateTime Birthday { get; set; }
    public Address Address { get; set; }

    public static string GetOnlyNumbers(string text)
    {
        var stringNumber = new String((text ?? string.Empty).Where(Char.IsDigit).ToArray());
        return stringNumber;
    }
}