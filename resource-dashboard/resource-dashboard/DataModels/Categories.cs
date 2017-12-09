using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace resource_dashboard.DataModels
{
    public class Categories
    {
        public int id { get; set; }
        public virtual int TagId { get; set; }
        public string CategoryName { get; set; }
        public virtual List<Resources> Resources { get; set; }
    }
}