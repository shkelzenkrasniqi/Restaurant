using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Parameters
{
    public class FoodItemParameters : Parameters
    {
        public string Name { get; set; }
        public decimal? MaximumPrice { get; set; }
    }
}
