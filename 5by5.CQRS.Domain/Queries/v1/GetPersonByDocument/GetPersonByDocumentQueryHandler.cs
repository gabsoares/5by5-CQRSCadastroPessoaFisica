using _5by5.CQRS.Domain.Contracts.v1;
using AutoMapper;
using MediatR;

namespace _5by5.CQRS.Domain.Queries.v1.GetPersonByDocument;

public class GetPersonByDocumentQueryHandler(IMapper mapper, IPersonRepository repository) : IRequestHandler<GetPersonByDocumentQuery, GetPersonByDocumentQueryResponse>
{
    public async Task<GetPersonByDocumentQueryResponse> Handle(GetPersonByDocumentQuery request, CancellationToken cancellationToken)
    {
        var person = await repository.Get(p => p.Document == request.Document, cancellationToken);

        return mapper.Map<GetPersonByDocumentQueryResponse>(person);
    }
}