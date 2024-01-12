using FreeBilling.Data.Entities;
using FreeBilling.Web.Data;
using Microsoft.AspNetCore.Mvc;

namespace FreeBilling.Web.Controllers
{
	[Route("/api/[controller]")]
	public class CustomersController : ControllerBase
	{
		private readonly ILogger<CustomersController> _logger;
		private readonly IBillingRepository _repository;

		public CustomersController(ILogger<CustomersController> logger, IBillingRepository repository)
		{
			_logger = logger;
			_repository = repository;
		}

		[HttpGet("")]
		public async Task<ActionResult<IEnumerable<Customer>>> Get(bool withAddresses = false)
		{
			IEnumerable<Customer> results;

			if (withAddresses)
			{
				results = await _repository.GetCustomersWithAddresses();

			}
			else
			{
				results = await _repository.GetCustomers();
			}

			return Ok(results);
		}

		[HttpGet("{id:int}")]
		public async Task<ActionResult<Customer?>> GetOne(int id)
		{
			try
			{
				var result = await _repository.GetCustomer(id);

				if (result == null)
				{
					return NotFound();
				}
				else
				{
					return Ok(result);
				}
			}
			catch (Exception ex)
			{
				_logger.LogError("Exception thrown while reading customer");

				return Problem($"Exception thrown: {ex.Message}");
			}
		}
	}
}
