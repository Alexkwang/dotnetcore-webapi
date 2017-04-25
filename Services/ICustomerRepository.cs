using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webapi.Models;

namespace webapi.Services
{
    public interface ICustomerRepository
    {
        Customer Add(Customer customer);
        IEnumerable<Customer> GetAll();
        Customer GetById(int Id);
        void Update(Customer customer);
        void Delete(Customer customer);

    }
}
