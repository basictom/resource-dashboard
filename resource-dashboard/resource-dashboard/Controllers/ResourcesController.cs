using resource_dashboard.DataModels;
using resource_dashboard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace resource_dashboard.Controllers
{
    //[Authorize]
    public partial class ResourcesController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        //GET resources
        public IEnumerable<Resources> Get()
        {
            return db.Resources.ToList<Resources>();
        }
        //GET resources/name/id
        public IEnumerable<Resources> Get(int? id)
        {
            var resource = from r in db.Resources where r.id == id select r;
            return resource;
        }
        //POST resources
        public HttpResponseMessage Post(CreateResource value)
        {
            var resource = new Resources();

            resource.Category = value.Category;
            resource.Description = value.Description;
            resource.ResourceName = value.ResourceName;
            resource.ResourceUrl = value.ResourceUrl;
            resource.Tags = new List<Tags>();

            foreach (var t in value.TagNames)
            {
                resource.Tags.Add(new Tags { TagName = t });
            };

            try
            {
                if (value == null)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Incorrect Model");
                }
                else
                {
                    db.Resources.Add(resource);
                    db.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.OK);
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        //PUT resources
        //public putResource Put(string name, string description, string category, int category_id)
        //{

        //}
    }
}
