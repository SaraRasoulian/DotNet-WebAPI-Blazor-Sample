using WebAPI.Tests.Acceptance.Hooks;

namespace WebAPI.Tests.Acceptance;

public abstract class BaseAcceptanceTest : IClassFixture<AcceptanceTestWebApplicationFactory>
{
    protected readonly HttpClient _httpClient;

    protected BaseAcceptanceTest(AcceptanceTestWebApplicationFactory factory)
    {
        _httpClient = factory.CreateDefaultClient();
    }
}