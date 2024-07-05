namespace _5by5.CQRS.Domain.Commands.v1.DeletePerson;

public class DeletePersonCommandResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
}