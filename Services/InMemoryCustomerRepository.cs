using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webapi.Models;

namespace webapi.Services
{
    public class InMemoryCustomerRepository : ICustomerRepository
    {
        private readonly CustomerAPIContext _context;

        public InMemoryCustomerRepository(CustomerAPIContext context)
        {
            _context = context;
        }

        public Customer Add(Customer customer)
        {
            var addCustomer = _context.Add(customer);
            _context.SaveChanges();
            customer.Id = addCustomer.Entity.Id;
            return customer;
        }

        public void Delete(Customer customer)
        {
            _context.Remove(customer);
            _context.SaveChanges();
        }

        public IEnumerable<Customer> GetAll()
        {
            return _context.Customers.ToList();
        }

        public Customer GetById(int Id)
        {
            return _context.Customers.SingleOrDefault(x=>x.Id==Id);
        }

        public void Update(Customer customer)
        {
            var updateCustomer = GetById(customer.Id);
            updateCustomer.Name = customer.Name;
            updateCustomer.City = customer.City;
            _context.Update(updateCustomer);
            _context.SaveChanges();


        }
    }
}
