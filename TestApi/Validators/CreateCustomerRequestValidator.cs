using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestApi.Contracts.Request;

namespace TestApi.Validators
{
    public class CreateCustomerRequestValidator : AbstractValidator<CustomerRequest>
    {
        public CreateCustomerRequestValidator()
        {
            RuleFor(x => x.Email).NotEmpty().EmailAddress();
        }
    }
}
