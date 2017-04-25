using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webapi.Models;
using webapi.Services;

namespace webapi.Controllers
{
    [Route("api/[controller]")]
    public class CustomerController : Controller
    {
        private ICustomerRepository _customerRepository;

        public CustomerController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        [HttpGet]
        public IEnumerable<Customer> Get()
        {

            return _customerRepository.GetAll();
        }

        //get customer/1
        [HttpGet("{id}", Name = "GetCustomer")]
        public IActionResult Get(int Id)
        {
            var customer = _customerRepository.GetById(Id);

            if (customer == null)
                return NotFound();

            return Ok(customer);
        }

        //post add new
        [HttpPost]
        public IActionResult Post([FromBody]Customer customer)
        {
            if (customer == null)
            { return BadRequest(); }

            var createNewCustomer = _customerRepository.Add(customer);

            return CreatedAtRoute("GetCustomer", new { id = createNewCustomer.Id }, createNewCustomer);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Customer customer)
        {
            if (customer == null)
            {
                return BadRequest();
            }

            var note = _customerRepository.GetById(id);

            if (note == null)
            {
                return NotFound();
            }

            customer.Id = id;
            _customerRepository.Update(customer);

            return NoContent();

        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var customer = _customerRepository.GetById(id);
            if (customer == null)
            {
                return NotFound();
            }

            _customerRepository.Delete(customer);

            return NoContent();

        }

    }
}
