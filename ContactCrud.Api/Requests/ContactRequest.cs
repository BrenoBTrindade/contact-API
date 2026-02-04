using ContactCrud.Api.Core;

namespace ContactCrud.Api.Requests
{
    public class ContactRequest
    {
    public string? Name { get; set; }
    public string? Email { get; set; }
    public string? Phone {  get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    }
}
