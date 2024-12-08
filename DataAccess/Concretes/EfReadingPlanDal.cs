using Core.DataAccess.Repositories;
using DataAccess.Abstracts;
using DataAccess.Contexts;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concretes
{
    public class EfReadingPlanDal : EfRepositoryBase<ReadingPlan, Guid, BookShelfContext>, IReadingPlanDal
    {
        public EfReadingPlanDal(BookShelfContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Book>> GetBooksByIdsAsync(IEnumerable<Guid> bookIds)
        {
            return await Context.Books 
                .Where(book => bookIds.Contains(book.Id))
                .ToListAsync();
        }
    }
}
