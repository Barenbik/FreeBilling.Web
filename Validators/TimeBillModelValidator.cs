using FluentValidation;
using FreeBilling.Web.Models;

namespace FreeBilling.Web.Validators
{
	public class TimeBillModelValidator : AbstractValidator<TimeBillModel>
	{
		public TimeBillModelValidator() 
		{
			RuleFor(m => m.CustomerId)
				.NotEmpty();

            RuleFor(m => m.EmployeeId)
				.NotEmpty();

			RuleFor(m => m.BillingRate)
				.InclusiveBetween(50.0, 300.0);

			RuleFor(m => m.Hours)
				.InclusiveBetween(.1, 12.0);

			RuleFor(m => m.WorkPerformed)
				.NotEmpty()
				.MinimumLength(15);
        }
	}
}
