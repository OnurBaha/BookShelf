using Core.DataAccess.Repositories;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstracts
{
    public interface IOperationClaimDal : IRepository<OperationClaim, Guid>, IAsyncRepository<OperationClaim, Guid>
    {
    }
}