using PT.DTO;
using PT.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PT.Controllers
{
    public class LinkController : ApiController
    {
        private GanttContext db = new GanttContext();

        // GET api/Link
        [System.Web.Http.HttpGet]
        public IEnumerable<LinkDto> Get()
        {
            using (var dc = new Entities())
            {
                return dc
                .Links
                .ToList()
                .Select(l => (LinkDto)l);
            }
                
        }

        // GET api/Link/5
        [System.Web.Http.HttpGet]
        public LinkDto Get(int id)
        {
            using (var dc = new Entities())
            {
                return (LinkDto)dc
               .Links
               .Find(id);
            }
               
        }

        // POST api/Link
        [System.Web.Http.HttpPost]
        public IHttpActionResult CreateLink(LinkDto linkDto)
        {
            using (var dc = new Entities())
            {
             
                var newLink = (Link)linkDto;
                dc.Links.Add(newLink);
                dc.SaveChanges();

                return Ok(new
                {
                    tid = newLink.Id,
                    action = "inserted"
                });
            }
                
        }

        // PUT api/Link/5
        [System.Web.Http.HttpPut]
        public IHttpActionResult EditLink(int id, LinkDto linkDto)
        {
            using (var dc = new Entities())
            {
                var clientLink = (Link)linkDto;
                clientLink.Id = id;

                dc.Entry(clientLink).State = EntityState.Modified;
                dc.SaveChanges();

                return Ok(new
                {
                    action = "updated"
                });
            }
                
        }

        // DELETE api/Link/5
        [System.Web.Http.HttpDelete]
        public IHttpActionResult DeleteLink(int id)
        {
            var link = db.Links.Find(id);
            if (link != null)
            {
                db.Links.Remove(link);
                db.SaveChanges();
            }
            return Ok(new
            {
                action = "deleted"
            });
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

    }
}
