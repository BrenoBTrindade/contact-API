using ContactCrud.Api.Core;

namespace ContactCrud.Api.Repositories
{
    public interface IContactRepository
    {
        public IEnumerable<Contact> GetAll();
        public Contact? GetById(int id);
        public bool Create(Contact contact);
        public bool Update(int id, Contact updatedContact);
        public bool Delete(int id);
        public int GetNextId();

    }
}
