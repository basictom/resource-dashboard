using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace resource_dashboard.DataModels
{
    public class Resources
    {
        public int id { get; set; }
        public virtual string Category { get; set; }
        public string ResourceName { get; set; }
        public string Description { get; set; }
        public string ResourceUrl { get; set; }
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        public virtual List<Tags> Tags { get; set; }
    }
}