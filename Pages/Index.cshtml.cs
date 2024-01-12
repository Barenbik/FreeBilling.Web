using FreeBilling.Data.Entities;
using FreeBilling.Web.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace FreeBilling.Web.Pages
{
    public class IndexModel : PageModel
    {
		private readonly IBillingRepository _repository;

		public IndexModel(IBillingRepository repository)
        {
			_repository = repository;
		}

        public IEnumerable<Customer>? Customers { get; set; }

        public async Task OnGetAsync()
        {
            Customers = await _repository.GetCustomers();
        }
    }
}
