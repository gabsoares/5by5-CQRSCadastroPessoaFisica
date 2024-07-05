namespace _5by5.CQRS.Domain.Queries.v1.GetPersonById;

using _5by5.CQRS.Domain.Entities.v1;
using AutoMapper;

public class GetPersonByDocumentQueryProfile : Profile
{
    public GetPersonByDocumentQueryProfile()
    {
        CreateMap<Person, GetPersonByDocumentQueryResponse>();
    }
}
