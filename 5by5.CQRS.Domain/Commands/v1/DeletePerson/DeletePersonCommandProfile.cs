using _5by5.CQRS.Domain.Entities.v1;
using AutoMapper;

namespace _5by5.CQRS.Domain.Commands.v1.DeletePerson;

public class DeletePersonCommandProfile : Profile
{
    public DeletePersonCommandProfile()
    {
        CreateMap<DeletePersonCommand, Person>()
            .ForMember(fieldoutput => fieldoutput.Document, opt => opt
            .MapFrom(input => Person.GetOnlyNumbers(input.Document)));

        CreateMap<Person, DeletePersonCommandResponse>();
    }
}