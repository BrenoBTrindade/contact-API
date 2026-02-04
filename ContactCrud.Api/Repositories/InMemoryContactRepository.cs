using ContactCrud.Api.Core;
namespace ContactCrud.Api.Repositories
{
    public class InMemoryContactRepository : IContactRepository
    {
        private readonly List<Contact> _contacts = new();

        public IEnumerable<Contact> GetAll()
        {
            return _contacts;
        }

        public Contact? GetById(int id)
        {
            return _contacts.FirstOrDefault(contact => contact.Id == id);
        }

        public int GetNextId()
        {
            if (_contacts.Count == 0)
            {
                return 1;
            }
            return _contacts.Max(contato  => contato.Id) + 1;

        }

        public bool Create(Contact contact)
        {
            contact.Id = GetNextId();
            contact.CreatedAt = DateTime.Now;
            contact.UpdatedAt = DateTime.Now;

            _contacts.Add(contact);
            return true;
        }

        public bool Update(int id, Contact updatedContact)
        {
            var existing = GetById(id);
            if (existing == null) return false;

            if (!string.IsNullOrWhiteSpace(updatedContact.Name))
                existing.Name = updatedContact.Name;

            if (!string.IsNullOrWhiteSpace(updatedContact.Email))
                existing.Email = updatedContact.Email;

            if (!string.IsNullOrWhiteSpace(updatedContact.Phone))
                existing.Phone = updatedContact.Phone;

            existing.UpdatedAt = DateTime.UtcNow;
            return true;
        }


        public bool Delete(int id)
        {
            var contact = GetById(id);

            if (contact == null)
            {
                return false;
            }
            _contacts.Remove(contact);
            return true;
        }
    }
}
