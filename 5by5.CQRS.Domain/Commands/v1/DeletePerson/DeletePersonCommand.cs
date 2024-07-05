using MediatR;

namespace _5by5.CQRS.Domain.Commands.v1.DeletePerson;

public class DeletePersonCommand(Guid id) : IRequest<DeletePersonCommandResponse>
{
    public Guid Id { get; set; } = id;
    public string Document { get; set; } = string.Empty;
}