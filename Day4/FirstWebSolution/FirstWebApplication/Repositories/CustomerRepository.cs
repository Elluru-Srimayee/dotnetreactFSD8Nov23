using FirstWebApplication.Interfaces;
using FirstWebApplication.Models;

namespace FirstWebApplication.Repositories
{
    public class CustomerRepository : IRepository<string, Customer>
    {
        Dictionary<string, Customer> _customers = new Dictionary<string, Customer>();
        public Customer Add(Customer item)
        {
            _customers.Add(item.Email, item);
            return item;
        }

        public Customer Delete(string id)
        {
            var customer = Get(id);
            if (customer != null)
            {
                _customers.Remove(customer.Email);
                return customer;
            }
            return null;
        }

        public IList<Customer> GetAll()
        {
            if (_customers.Count == 0)
                return null;
            return _customers.Values.ToList();
        }

        public Customer Get(string id)
        {
            if (_customers.ContainsKey(id))
            {
                return _customers[id];
            }
            return null;
        }

        public Customer Update(Customer item)
        {
            var customer = Get(item.Email);
            if (customer != null)
            {
                _customers[item.Email] = item;
                return item;
            }
            return null;
        }
    }

}
