using _5by5.CQRS.Domain.Contracts.v1;
using _5by5.CQRS.Infra.Repositories.Person.v1;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;

namespace _5by5.CQRS.Infra
{
    public static class Bootstrapper
    {
        public static IServiceCollection AddInfraContext(
        this IServiceCollection services,
        IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("Mongo");
            var clientSettings = MongoClientSettings.FromConnectionString(connectionString);
            var client = new MongoClient(clientSettings);

            BsonSerializer.RegisterSerializer(typeof(DateTime), DateTimeSerializer.LocalInstance);

            return services
                .AddSingleton(clientSettings)
                .AddSingleton<IMongoClient>(client)
                .AddScoped(typeof(IPersonRepository), typeof(PersonRepository))
                .AddScoped<IPersonRepository, PersonRepository>();
        }
    }
}