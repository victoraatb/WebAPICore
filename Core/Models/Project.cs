using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class Project
    {
        public int ProjectId { get; set; }        
        [StringLength(50)]
        public string? Name { get; set; }

        [StringLength(250)]
        public string? ClientName { get; set; }
        public List<Ticket>? Tickets { get; set; }
    }
}
