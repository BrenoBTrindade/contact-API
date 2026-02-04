
using ContactCrud.Api.Core;
using ContactCrud.Api.Requests;

namespace ContactCrud.Tests;

public static class TestData
{
	public static readonly List<Contact> Contacts = new()
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
}
