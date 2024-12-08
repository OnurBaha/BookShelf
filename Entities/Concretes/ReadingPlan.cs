using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concretes;

public class ReadingPlan:Entity<Guid>
{
    public string UserName { get; set; }
    public ICollection<Book> Books { get; set; }
    public DateTime StartDate { get; set; } 
    public DateTime EndDate { get; set; }
}
