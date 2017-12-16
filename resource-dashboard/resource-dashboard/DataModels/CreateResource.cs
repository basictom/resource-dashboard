using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace resource_dashboard.DataModels
{
    public class CreateResource
    {
        public string Category { get; set; }
        public string ResourceName { get; set; }
        public string Description { get; set; }
        public string ResourceUrl { get; set; }

        public List<string> TagNames { get; set; }
    }
}