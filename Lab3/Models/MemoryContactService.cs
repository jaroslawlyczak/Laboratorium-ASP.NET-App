using System.Xml.Linq;

namespace Lab3.Models
{
    public class MemoryContactService : IContactService
    {

        private Dictionary<int, Contact> _items = new Dictionary<int, Contact>()
        { 
                { 1, new Contact() { Id = 1, Name = "John Doe", Email = "JohnDoe@gmail.com", Phone = "123456789" } },
                { 2, new Contact() { Id = 2, Name = "Roman ree", Email = "romannn@gmail.com", Phone = "123456789" } }


        };

        public int Add(Contact item)
        {
            int id = _items.Keys.Count != 0 ? _items.Keys.Max() : 0;
            item.Id = id + 1;
            _items.Add(item.Id, item);
            return item.Id;
        }

        public void Delete(int id)
        {
            _items.Remove(id);
        }

        public List<Contact> FindAll()
        {
            return _items.Values.ToList();
        }

        public Contact? FindById(int id)
        {
            return _items[id];
        }

        public void Update(Contact item)
        {
            _items[item.Id] = item;
        }   
    }
}

