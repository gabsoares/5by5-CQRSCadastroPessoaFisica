using _5by5.CQRS.Domain.Contracts.v1;
using AutoMapper;
using MediatR;

namespace _5by5.CQRS.Domain.Queries.v1.GetPersonById;

public class GetPersonByDocumentQueryHandler(IMapper mapper, IPersonRepository repository)
    : IRequestHandler<GetPersonByIdQuery, GetPersonByDocumentQueryResponse>
{
    public async Task<GetPersonByDocumentQueryResponse> Handle(GetPersonByIdQuery request, CancellationToken cancellationToken)
    {
        var person = await repository.Get(p => p.Id == request.Id, cancellationToken);

        return mapper.Map<GetPersonByDocumentQueryResponse>(person);
    }
}