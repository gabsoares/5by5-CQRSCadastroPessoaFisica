using _5by5.CQRS.Domain.Entities.v1;
using System.Linq.Expressions;

namespace _5by5.CQRS.Domain.Contracts.v1;

public interface IPersonRepository
{
    Task Post(Person person, CancellationToken cancellationToken);
    Task<Person> Get(Expression<Func<Person, bool>> lambda, CancellationToken cancellationToken);
    Task Delete(Person person, CancellationToken cancellationToken);
}