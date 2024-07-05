using MediatR;

namespace _5by5.CQRS.Domain.Queries.v1.GetPersonById;
public class GetPersonByIdQuery(Guid id) : IRequest<GetPersonByDocumentQueryResponse>
{
    public Guid Id { get; set; } = id;
}