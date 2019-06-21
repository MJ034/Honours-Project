using PT.DTO;
using PT.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using System.Web.Routing;

namespace PT.Controllers
{
    public class TaskController : ApiController
    {
        //private GanttContext db  = new GanttContext();

        // GET api/Task
        public IEnumerable<TaskDto> Get()
        {
            using (var dc = new Entities())
            {
                return dc.Tasks
                .ToList()
                .Select(t => (TaskDto)t);
            }
                
        }

        // GET api/Task/5
        [System.Web.Http.HttpGet]
        public TaskDto Get(int id)
        {
            using (var dc = new Entities())
            {
                return (TaskDto)dc
               .Tasks
               .Find(id);
            }
               
        }

        // PUT api/Task/5
        [System.Web.Http.HttpPut]
        public IHttpActionResult EditTask(int id, TaskDto taskDto)
        {
            using (var dc = new Entities())
            {
                var updatedTask = (Task)taskDto;
                updatedTask.Id = id;
                dc.Entry(updatedTask).State = EntityState.Modified;
                dc.SaveChanges();

                return Ok(new
                {
                    action = "updated"
                });
            }
        }

        // POST api/Task
        [System.Web.Http.HttpPost]
        public IHttpActionResult CreateTask(TaskDto taskDto)
        {
            using (var dc = new Entities())
            {
                var newTask = (Task)taskDto;

                dc.Tasks.Add(newTask);
                dc.SaveChanges();

                return Ok(new
                {
                    tid = newTask.Id,
                    action = "inserted"
                });
            }
                
        }

        // DELETE api/Task/5
        [System.Web.Http.HttpDelete]
        public IHttpActionResult DeleteTask(int id)
        {
            using (var dc = new Entities())
            {
                var task = dc.Tasks.Find(id);
                if (task != null)
                {
                    dc.Tasks.Remove(task);
                    dc.SaveChanges();
                }

                return Ok(new
                {
                    action = "deleted"
                });
            }

               
        }

        protected override void Dispose(bool disposing)
        {
            using (var dc = new Entities())
            {
                if (disposing)
                {
                    dc.Dispose();
                }
                base.Dispose(disposing);
            }

               
        }
    }
}
