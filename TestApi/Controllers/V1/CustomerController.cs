using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestApi.Contracts;
using TestApi.Contracts.Request;
using TestApi.Contracts.Response;
using TestApi.Domain;
using TestApi.Services.Interfaces;

namespace TestApi.Controllers.V1
{
    public class CustomerController :Controller
    {
        private readonly IICustomers _iCustomers;
        private readonly IMapper _mapper;
        public CustomerController(IICustomers iCustomers, IMapper mapper)
        {
            _iCustomers = iCustomers;
            _mapper = mapper;
        }

        [HttpGet(ApiRoutes.Customers.GetAll)]
        public async Task<IActionResult> GetStudent()
        {
            return Ok(await _iCustomers.GetCustomersAsync());
        }

        [HttpPost(ApiRoutes.Customers.Create)]
        public async Task<IActionResult> CreateStudent([FromBody] CustomerRequest customerRequest)
        {

            var customer = new Customers
            {
                Name = customerRequest.Name,
                LastName = customerRequest.LastName,
                Age = customerRequest.Age,
                Email = customerRequest.Email,
                PhoneNumber = customerRequest.PhoneNumber,
                Address = customerRequest.Address
            };

            await _iCustomers.CreateCustomerAsync(customer);

            var baseURL = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
            var locationURI = baseURL + "/" + ApiRoutes.Customers.Get.Replace("{customerId}", customer.CustomerId.ToString());

            var response = _mapper.Map<CustomerResponse>(customer);

            return Created(locationURI, response);
        }

        [HttpPost(ApiRoutes.Customers.Delete)]
        public async Task<IActionResult> DeleteCustomer([FromRoute] int customerId)
        {
            var customer = await _iCustomers.GetCustomerByIdAsync(customerId);
            if(customer != null)
            {
                var deleted = await _iCustomers.DeleteCustomerAsync(customerId);

                if (deleted)
                {
                    return Ok();
                }
            }
           
            return NotFound();
           
        }

        [HttpPost(ApiRoutes.Customers.Update)]
        public async Task<IActionResult> UpdateCustomer([FromRoute]int customerId,[FromBody] CustomerRequest customerRequest)
        {
            var customer = await _iCustomers.GetCustomerByIdAsync(customerId);
            if(customer != null)
            {
                customer.Name = customerRequest.Name;
                customer.LastName = customerRequest.LastName;
                customer.Age = customerRequest.Age;
                customer.Email = customerRequest.Email;
                customer.PhoneNumber = customerRequest.PhoneNumber;
                customer.Address = customerRequest.Address;

                var updated = await _iCustomers.UpdateCustomerAsync(customer);
                if (updated)
                {
                    return Ok(customer);
                }

            }
           
            return NotFound();

        }
    }
}
