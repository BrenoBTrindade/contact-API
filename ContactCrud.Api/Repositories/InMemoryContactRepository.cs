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

        public bool Update(int id, Contact UpdatedContact)
        {
            var existingContact = GetById(id);

            if (existingContact == null)
            {
                return false;
            }
            existingContact.Name = UpdatedContact.Name;
            existingContact.Email = UpdatedContact.Email;
            existingContact.Phone = UpdatedContact.Phone;
            existingContact.UpdatedAt = DateTime.UtcNow;

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
