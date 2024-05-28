using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using ProcesioWebApi.DTOs.Customers;

namespace ProcesioWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomersController(ICustomerService customerService, IMapper mapper) : ControllerBase
    {
        private readonly ICustomerService _customerService = customerService;
        private readonly IMapper _mapper = mapper;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ViewCustomerDto>>> GetCustomers()
        {
            var customers = await _customerService.GetCustomersAsync();
            var customerDtos = _mapper.Map<IEnumerable<ViewCustomerDto>>(customers);
            return Ok(customerDtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ViewCustomerDto>> GetCustomer(int id)
        {
            var customer = await _customerService.GetCustomerByIdAsync(id);

            if (customer == null)
            {
                return NotFound();
            }

            var customerDto = _mapper.Map<ViewCustomerDto>(customer);
            return Ok(customerDto);
        }

        [HttpPost]
        public async Task<ActionResult<ViewCustomerDto>> PostCustomer(CreateCustomerDto customerDto)
        {
            var customer = _mapper.Map<Customer>(customerDto);
            var createdCustomer = await _customerService.AddCustomerAsync(customer);
            var createdCustomerDto = _mapper.Map<ViewCustomerDto>(createdCustomer);
            return CreatedAtAction(nameof(GetCustomer), new { id = createdCustomerDto.Id }, createdCustomerDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomer(int id, UpdateCustomerDto customerDto)
        {
            if (id != customerDto.CustomerId)
            {
                return BadRequest();
            }

            var customer = _mapper.Map<Customer>(customerDto);
            var updateSuccessful = await _customerService.UpdateCustomerAsync(customer);

            if (!updateSuccessful)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            var deleteSuccessful = await _customerService.DeleteCustomerAsync(id);

            if (!deleteSuccessful)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
