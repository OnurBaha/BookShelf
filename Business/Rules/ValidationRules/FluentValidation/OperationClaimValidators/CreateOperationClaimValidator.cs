using Business.Dtos.Requests.OperationClaimRequests;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Rules.ValidationRules.FluentValidation.OperationClaimValidators
{
    public class CreateOperationClaimValidator : AbstractValidator<CreateOperationClaimRequest>
    {
        public CreateOperationClaimValidator()
        {
            RuleFor(op => op.Name).NotEmpty();

        }
    }
} 
