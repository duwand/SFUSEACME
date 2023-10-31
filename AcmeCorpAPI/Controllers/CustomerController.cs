using AcmeCorpAPI.DataContext;
using AcmeCorpAPI.Models;
using AcmeCorpAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AcmeCorpAPI.Controllers
{
    [ApiController]
    [Route("api/customers")]
    [Authorize(Roles = UserRoles.Admin)]
    public class CustomerController : ControllerBase
    {

        private readonly ICustomerService _customerService;
        private readonly IContactInfoService _contactinfoService;
       

        public CustomerController(ICustomerService customerService, IContactInfoService contactinfoService)
        {
            _customerService = customerService;
            _contactinfoService = contactinfoService;
        }

        [HttpGet]
        
        public IActionResult GetCustomerList()
        {
            try
            {
                var customers = _customerService.GetAll();

                return Ok(customers);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetbyCustomerID([FromRoute] int id)
        {
            var customer = _customerService.GetCustomerById(id);

            if (customer == null)
            {
                return NotFound("Customer doesnt exist");
            }
            return Ok(customer);
        }

        [HttpPost]
        public IActionResult CreateCustomer([FromBody] CustomerModel addcustomer)
        {
            //to check if customer already exists or not
            bool customerExists = _customerService.Exists(addcustomer.CustomerID, addcustomer.Name);
            if (customerExists)
            {
                return BadRequest("Customer Already exists");
            }

            var newCustomer = new CustomerModel();
            _customerService.Add(addcustomer);

            var newContactInfo = new ContactInfoModel
            {
                CustomerID = addcustomer.CustomerID,
                Phone = addcustomer.Phone,
                Email = addcustomer.Email
            };
            _contactinfoService.Add(newContactInfo);

            if (newCustomer == null || newContactInfo == null)
            {
                return BadRequest();
            }

            return Ok("Customer has been created successfully");
        }

        [HttpPut]
        [Route("update/{id}")]
        public IActionResult UpdateCustomerfromID([FromRoute] int id, [FromBody] CustomerModel customer)
        {
            //to get customer that has to be updated
            var customerExists = _customerService.GetCustomerById(id);
            
            if (customerExists == null)
            {
                return NotFound("Customer doesnt exist");
            }

            //making changes
            customerExists.Name = customer.Name;
            customerExists.Phone = customer.Phone;
            customerExists.Email = customer.Email;  
            customerExists.Address = customer.Address;  
            
            _customerService.Update(customerExists);

            var contactExist = _contactinfoService.GetContactInfobyID(id);

            contactExist.CustomerID = customer.CustomerID;
            contactExist.Phone = customer.Phone;
            contactExist.Email = customer.Email ;
            
            _contactinfoService.Update(contactExist);

            return Ok();
        }

        [HttpDelete]
        [Route("delete/{id:int}")]
        public IActionResult DeleteCustomer([FromRoute] int id)
        {
            var customerExists = _customerService.GetCustomerById(id);

            if (customerExists == null)
            {
                return NotFound("Customer doesnt exist");
            }

            _customerService.Delete(id);
            _contactinfoService.Delete(id);

            return Ok("Successfully deleted");
        }

    }
}
