﻿using Core.DataAccess.Repositories;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstracts
{
    public interface IReadingPlanDal : IRepository<ReadingPlan, Guid>, IAsyncRepository<ReadingPlan, Guid>
    {
        Task<IEnumerable<Book>> GetBooksByIdsAsync(IEnumerable<Guid> bookIds);

    }
}
