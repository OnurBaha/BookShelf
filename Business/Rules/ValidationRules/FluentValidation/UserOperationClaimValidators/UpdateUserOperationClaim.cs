using Business.Dtos.Requests.UserOperationClaimRequests;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Rules.ValidationRules.FluentValidation.UserOperationClaimValidators
{
    public class UpdateUserOperationClaimValidator : AbstractValidator<UpdateUserOperationClaimRequest>
    {
        public UpdateUserOperationClaimValidator()
        {

        }
    }
} 
