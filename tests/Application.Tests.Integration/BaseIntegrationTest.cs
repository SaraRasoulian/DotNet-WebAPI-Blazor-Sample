using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Tests.Integration;

public class BaseIntegrationTest : IClassFixture<IntegrationTestWebApplicationFactory>
{
    private readonly IServiceScope _serviceScope;
    protected readonly ISender _sender;
    protected BaseIntegrationTest(IntegrationTestWebApplicationFactory factory)
    {
        _serviceScope = factory.Services.CreateScope();
        _sender = _serviceScope.ServiceProvider.GetRequiredService<ISender>();
    }
}
