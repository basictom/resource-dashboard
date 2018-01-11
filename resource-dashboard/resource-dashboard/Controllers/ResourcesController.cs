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
        [HttpGet]
        [Route("api/resources")]
        public IEnumerable<Resources> GetReources()
        {
            return db.Resources.ToList<Resources>();
        }
        //GET resources/bytagname
        [HttpGet]
        [Route("api/resources/bytagname")]
        public IQueryable<Resources> GetByTagName(string tags)
        {
            var query = tags.Split(',');

            var resources = from r in db.Resources
                            join t in db.Tags on r.id equals t.Resources.id
                            where query.Contains(t.TagName)
                            select r;

            return resources;
            
        }
        //GET resources/tags
        [HttpGet]
        [Route("api/resources/tags")]
        public IQueryable<string> GetTags(string query)
        {

            var resource = db.Tags.Where(q => q.TagName.Contains(query)).Select(r => r.TagName).Distinct();

            //.Select(r => r.TagName).Distinct();
            //db.Tags.Where(q => q.TagName.Contains(query));
            return resource;
        }
        [HttpGet]
        [Route("api/resources/category")]
        public IQueryable<Resources> GetResourcesByCategory(string category)
        {
            var cat = from r in db.Resources
                      where category.Contains(r.Category)
                      select r;
            return cat;
        }
        
        //POST resources
        [HttpPost]
        [Route("api/resources")]
        public HttpResponseMessage Post(CreateResource value)
        {
            var resource = new Resources();

            resource.Category = value.Category;
            resource.Description = value.Description;
            resource.ResourceName = value.ResourceName;
            resource.ResourceUrl = value.ResourceUrl;
            resource.Date = value.Date;
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
