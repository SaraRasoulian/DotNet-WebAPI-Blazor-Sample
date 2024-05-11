﻿using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Infrastructure.DbContexts;
using Testcontainers.PostgreSql;

namespace Application.Tests.Integration;

public class IntegrationTestWebApplicationFactory : WebApplicationFactory<Program>, IAsyncLifetime
{
    private readonly PostgreSqlContainer _dbContainer = new PostgreSqlBuilder()
        .WithImage("postgres:latest")
        .WithDatabase("StudentManagementDB_Test")
        .WithUsername("postgres")
        .WithPassword("mysecretpassword")
        .Build();

    public async Task InitializeAsync()
    {
        await _dbContainer.StartAsync();

        using (var scope = Services.CreateScope())
        {
            var scopedServices = scope.ServiceProvider;
            var cntx = scopedServices.GetRequiredService<StudentManagementDBContext>();

            await cntx.Database.EnsureCreatedAsync();
        }
    }

    public new async Task DisposeAsync()
    {
        await _dbContainer.StopAsync();
    }

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureTestServices(services =>
        {
            var descriptor = services.SingleOrDefault(s => s.ServiceType == typeof(DbContextOptions<StudentManagementDBContext>));

            if (descriptor is not null)
            {
                services.Remove(descriptor);
            }

            services.AddDbContext<StudentManagementDBContext>(options =>
            {
                options.UseNpgsql(_dbContainer.GetConnectionString());
            });
        });
    }
}
