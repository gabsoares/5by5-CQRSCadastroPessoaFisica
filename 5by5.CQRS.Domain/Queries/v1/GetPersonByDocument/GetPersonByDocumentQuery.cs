using MediatR;

namespace _5by5.CQRS.Domain.Queries.v1.GetPersonByDocument;

public class GetPersonByDocumentQuery(string document) : IRequest<GetPersonByDocumentQueryResponse>
{
    public string Document { get; set; } = document;
}
