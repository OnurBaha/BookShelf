using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Dtos.Requests.ReadingPlanRequests
{
    public class UpdateReadingPlanRequest
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public List<Book>? Books { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
