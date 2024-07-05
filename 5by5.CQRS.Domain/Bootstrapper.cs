using _5by5.CQRS.Domain.Commands.v1.CreatePerson;
using _5by5.CQRS.Domain.Contracts.v1;
using _5by5.InterAction.Sample.Domain.Pipes.v1;
using _5by5.InterAction.Sample.Domain.Services.v1;
using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace _5by5.CQRS.Domain;

public static class Bootstrapper
{
    public static IServiceCollection AddDomainContext(this IServiceCollection services, IConfiguration configuration)
    {
        return services
            .AddAutoMapper(typeof(Bootstrapper))
            .AddMediatR(config => config.RegisterServicesFromAssemblyContaining(typeof(Bootstrapper)))
            .AddScoped<IDomainNotificationService, DomainNotificationServiceHandler>()
            .AddScoped(typeof(IPipelineBehavior<,>), typeof(FailFastValidation<,>))
            .AddCommands()
            .AddValidators();
    }

    private static IServiceCollection AddCommands(this IServiceCollection services)
    {
        return services
            .AddTransient<CreatePersonCommandHandler>();
    }

    private static IServiceCollection AddValidators(this IServiceCollection services)
    {
        services.AddFluentValidationAutoValidation();

        services.AddScoped<IValidator<CreatePersonCommand>, CreatePersonCommandValidator>();
        return services;
    }
}