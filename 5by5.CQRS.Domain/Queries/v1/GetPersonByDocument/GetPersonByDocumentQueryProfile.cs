using _5by5.CQRS.Domain.Entities.v1;
using AutoMapper;

namespace _5by5.CQRS.Domain.Queries.v1.GetPersonByDocument;

public class GetPersonByDocumentQueryProfile : Profile
{
    public GetPersonByDocumentQueryProfile()
    {
        CreateMap<Person, GetPersonByDocumentQueryResponse>();
    }
}