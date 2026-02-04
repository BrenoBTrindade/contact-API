using ContactCrud.Api.Requests;

namespace ContactCrud.Api.Core
{
    public class Contact
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public Contact(int id, ContactRequest request )
        {
            Id = id;
            Name = request.Name;
            Email = request.Email;
            Phone = request.Phone;
            CreatedAt = request.CreatedAt;
            UpdatedAt = request.UpdatedAt;
        }
    }
}
