using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace resource_dashboard.DataModels
{
    public class Tags
    {
        public int id { get; set; }
        public int Resources_Id { get; set; }
        public string TagName { get; set; }
    }
}