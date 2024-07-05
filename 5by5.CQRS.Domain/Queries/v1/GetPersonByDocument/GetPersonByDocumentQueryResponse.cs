using _5by5.CQRS.Domain.Entities.v1;

namespace _5by5.CQRS.Domain.Queries.v1.GetPersonByDocument;

public class GetPersonByDocumentQueryResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Document { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public DateTime Birthday { get; set; }
    public Address Address { get; set; }
}