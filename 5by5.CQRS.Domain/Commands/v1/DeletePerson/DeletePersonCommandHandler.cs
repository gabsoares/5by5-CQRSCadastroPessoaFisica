using _5by5.CQRS.Domain.Contracts.v1;
using _5by5.CQRS.Domain.Entities.v1;
using AutoMapper;
using MediatR;

namespace _5by5.CQRS.Domain.Commands.v1.DeletePerson;

public class DeletePersonCommandHandler(IPersonRepository repository, IMapper mapper) : IRequestHandler<DeletePersonCommand, DeletePersonCommandResponse>
{
    public async Task<DeletePersonCommandResponse> Handle(DeletePersonCommand request, CancellationToken cancellationToken)
    {
        var person = mapper.Map<DeletePersonCommand, Person>(request);
        await repository.Delete(person, cancellationToken);

        return mapper.Map<DeletePersonCommandResponse>(person);
    }
}