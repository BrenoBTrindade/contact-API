using Microsoft.AspNetCore.Mvc;
using ContactCrud.Api.Core;
using ContactCrud.Api.Requests;
using ContactCrud.Api.Repositories;

namespace ContactCrud.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContactsController : ControllerBase
    {
        private readonly IContactRepository _repository;

        public ContactsController(IContactRepository repository) {
            _repository = repository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Contact>> GetAll()
        {
            var Contacts = _repository.GetAll();
            return Ok(Contacts);
        }

        [HttpGet("{id}", Name = "GetById")]
        public ActionResult GetById(int id)
        {
            var contact = _repository.GetById(id);

            if(contact == null ) return NotFound("Contato não encontrado");
            return Ok(contact);
        }
        [HttpPost]
        public ActionResult Create(ContactRequest request)
        {
            int id = _repository.GetNextId();
            var contact = new Contact(id, request);
            _repository.Create(contact);

            return CreatedAtAction("GetById", new { id = contact.Id }, contact);

        }
        [HttpPut("{id}")]
        public ActionResult Update(int id, ContactRequest request)
        {
            var contact = new Contact(id, request);

            var updated = _repository.Update(id, contact);

            if (!updated)
                return NotFound("Contact not found");

            return Ok($"o contato de {request.Name} Foi Atualizado");
        }
        [HttpDelete("{id}")]
        public ActionResult Delete(int id) { 
            
            var contactDeleted = _repository.Delete(id);

            if (!contactDeleted) return NotFound("Contato não encontrado");

            return NoContent();
        }
    }
}
