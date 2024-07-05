using _5by5.CQRS.Domain.Contracts.v1;
using _5by5.CQRS.Domain.Entities.v1;
using AutoMapper;
using MediatR;

namespace _5by5.CQRS.Domain.Commands.v1.CreatePerson;

public class CreatePersonCommandHandler (IPersonRepository repository, IMapper mapper, IDomainNotificationService domainNotification)
    : IRequestHandler<CreatePersonCommand, CreatePersonCommandResponse>
{
    public async Task<CreatePersonCommandResponse> Handle(CreatePersonCommand request, CancellationToken cancellationToken)
    {
        var customer = mapper.Map<CreatePersonCommand, Person>(request);
        await repository.Post(customer, cancellationToken);

        return mapper.Map<CreatePersonCommandResponse>(customer);
    }
}