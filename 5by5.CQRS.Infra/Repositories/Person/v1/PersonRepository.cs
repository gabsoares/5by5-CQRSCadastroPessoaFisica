using _5by5.CQRS.Domain.Contracts.v1;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System.Linq.Expressions;

namespace _5by5.CQRS.Infra.Repositories.Person.v1;

public class PersonRepository : IPersonRepository
{
    private readonly IMongoCollection<Domain.Entities.v1.Person> _personCollection;

    public PersonRepository(IMongoClient client, IConfiguration configuration)
    {
        var database = client.GetDatabase(configuration.GetValue<string>("DatabaseName"));
        _personCollection = database.GetCollection<Domain.Entities.v1.Person>(configuration.GetValue<string>("PersonCollection"));
    }

    public async Task Delete(Domain.Entities.v1.Person person, CancellationToken cancellationToken)
    {
        await _personCollection.DeleteOneAsync(x => x.Id == person.Id, cancellationToken);
    }

    public async Task<Domain.Entities.v1.Person> Get(Expression<Func<Domain.Entities.v1.Person, bool>> lambda, CancellationToken cancellationToken)
    {
        return await _personCollection.Find(lambda).FirstOrDefaultAsync(cancellationToken);
    }

    public async Task Post(Domain.Entities.v1.Person person, CancellationToken cancellationToken)
    {
        await _personCollection.InsertOneAsync(person, cancellationToken: cancellationToken);
    }
}