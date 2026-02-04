using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Moq;
using Xunit;
using ContactCrud.Api.Repositories;
using ContactCrud.Api.Core;
using ContactCrud.Api.Requests;

namespace ContactCrud.Tests;

public class ContactControllerTest : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly HttpClient _client;
    private readonly Mock<IContactRepository> _repositoryMock;

    public ContactControllerTest(WebApplicationFactory<Program> factory)
    {
        _repositoryMock = new Mock<IContactRepository>();

        _client = factory.WithWebHostBuilder(builder =>
        {
            builder.ConfigureServices(services =>
            {
                services.RemoveAll<IContactRepository>();
                services.AddScoped<IContactRepository>(_ => _repositoryMock.Object);
            });
        }).CreateClient();
    }

    [Fact]
    public async Task GetAllTest()
    {
        var contacts = new List<Contact>
        {
            new Contact(1, new ContactRequest
            {
                Name = "Breno",
                Email = "Breno@email.com",
                Phone = "91981561194"
            }),
            new Contact(2, new ContactRequest
            {
                Name = "Cisley",
                Email = "Cisley@email.com",
                Phone = "91981564194"
            }),
        };

        _repositoryMock.Setup(repo => repo.GetAll()).Returns(contacts);

        var response = await _client.GetAsync("/contacts");

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        var content = await response.Content.ReadFromJsonAsync<List<Contact>>();
        Assert.NotNull(content);

        Assert.Equal(contacts.Count, content.Count);
        Assert.Equal(contacts[0].Id, content[0].Id);
        Assert.Equal(contacts[1].Id, content[1].Id);
    }
}
