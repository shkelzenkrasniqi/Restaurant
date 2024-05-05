using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Parameters
{
    public abstract class Parameters
    {
        public string SortBy { get; set; }
        public string SearchQuery { get; set; }

    }
}
