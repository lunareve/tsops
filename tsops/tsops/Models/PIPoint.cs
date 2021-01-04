using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace tsops.Models
{
    public class PIPoint
    {
        [Key]
        public string Id { get; set; }
        public string Name { get; set; }
        public double Value { get; set; }
        public DateTime Timestamp { get; set; }

    }
}
