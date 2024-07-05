using _5by5.CQRS.Domain.Commands.v1.CreatePerson;
using _5by5.CQRS.Domain.Commands.v1.DeletePerson;
using _5by5.CQRS.Domain.Entities.v1;
using _5by5.CQRS.Domain.Queries.v1.GetPersonByDocument;
using _5by5.CQRS.Domain.Queries.v1.GetPersonById;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace _5by5.CQRS.API.Controllers.v1;

[Route("api/[controller]")]
[ApiController]
public sealed class PeopleController(IMediator bus) : ControllerBase
{
    [HttpGet("{id:guid}")]
    public async Task<ActionResult<Person>> Get(Guid id)
    {
        var person = await bus.Send(new GetPersonByIdQuery(id));

        if (person is null) return NotFound("Pessoa não encontrada!!!");

        return StatusCode((int)HttpStatusCode.OK, new
        {
            Content = person
        });
    }

    [HttpPost]
    public async Task<IActionResult> Post(CreatePersonCommand createPerson, CancellationToken token)
    {
        var person = await bus.Send(new GetPersonByDocumentQuery(createPerson.Document));

        if (person is not null) return Conflict("O CPF " + person.Document + " já está cadastrado!!!");

        return StatusCode((int)HttpStatusCode.Created, new
        {
            Content = await bus.Send(createPerson, token),
            Notification = "Pessoa cadastrada com sucesso!"
        });
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id, CancellationToken token)
    {
        var person = await bus.Send(new GetPersonByIdQuery(id));

        if (person is null) return NotFound("Pessoa não encontrada!!!");

        return StatusCode((int)HttpStatusCode.OK, new
        {
            Content = await bus.Send(new DeletePersonCommand(person.Id)),
            Notification = "Pessoa deletada com sucesso!!!"
        });
    }
}