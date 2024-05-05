using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Parameters
{
    public class RestaurantParameters : Parameters
    {
        public string Name { get; set; }
        public string City { get; set; }
        public string Category { get; set; }
        public bool? HasDelivery { get; set; }
    }
}
