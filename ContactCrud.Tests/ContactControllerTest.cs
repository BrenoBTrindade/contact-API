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
using ContactCrud.Api.Requests;
using ContactCrud.Api.Controllers;
using ContactCrud.Api.Core;


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
        _repositoryMock.Setup(repo => repo.GetAll())
                       .Returns(TestData.Contacts);

        var response = await _client.GetAsync("/contacts");

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        var content = await response.Content.ReadFromJsonAsync<List<Contact>>();
        Assert.NotNull(content);

        Assert.Equal(TestData.Contacts.Count, content.Count);
        Assert.Equal(TestData.Contacts[0].Id, content[0].Id);
        Assert.Equal(TestData.Contacts[1].Id, content[1].Id);
    }

    [Fact]
    public async Task GetByIdTest()
    {
        _repositoryMock.Setup(repo => repo.GetById(1))
               .Returns(TestData.Contacts.First(c => c.Id == 1));


        var response = await _client.GetAsync("/contacts/1");

        Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);

        var content = await response.Content.ReadFromJsonAsync<Contact>();
        Assert.NotNull(content);

        Assert.Equal(TestData.Contacts.First(c => c.Id == 1).Id, content.Id);
        Assert.Equal(TestData.Contacts.First(c => c.Id == 1).Name, content.Name);
        Assert.Equal(TestData.Contacts.First(c => c.Id == 1).Email, content.Email);
        Assert.Equal(TestData.Contacts.First(c => c.Id == 1).Phone, content.Phone);
        Assert.DoesNotMatch(TestData.Contacts.First(c => c.Id == 2).Phone, content.Phone);
    }
    [Fact]
    public async Task CreateTest()
    {
        var request = new ContactRequest
        {
            Name = "Luke",
            Email = "luke@email.com",
            Phone = "91988888888"
        };

        _repositoryMock.Setup(repo => repo.GetNextId())
               .Returns(3);

        _repositoryMock.Setup(repo => repo.Create(It.IsAny<Contact>()));

        var response = await _client.PostAsJsonAsync("/contacts", request);

        Assert.Equal(System.Net.HttpStatusCode.Created, response.StatusCode);
        
        var content = await response.Content.ReadFromJsonAsync<Contact>();
        Assert.NotNull(content);

        Assert.Equal(3, content!.Id);
        Assert.Equal(request.Name, content.Name);
        Assert.DoesNotMatch(request.Name, content.Email);
    }
    [Fact]
    public async Task DeleteTest()
    {
        _repositoryMock.Setup(repo => repo.Delete(1)).Returns(true);
        var response = await _client.DeleteAsync("/contacts/1");

        Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
        _repositoryMock.Verify(repo => repo.Delete(1), Times.Once);
    }
}

