using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using a2p3.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace a2p3.Controllers
{
    [Route("api/[controller]")]
    public class TaskListsController : Controller
    {
        //Db Connection
        DbModel db;
        
        public TaskListsController(DbModel db)
        {
            this.db = db;
        }

        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<TaskList> Get()
        {
            return db.TaskLists.ToList();
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var taskList = db.TaskLists.SingleOrDefault(t => t.TaskID == id);

            if(taskList == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(taskList);
            }
        }

        // POST api/<controller>
        [HttpPost]
        public ActionResult Post([FromBody]TaskList taskList)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            else
            {
                db.TaskLists.Add(taskList);
                db.SaveChanges();
                return CreatedAtAction("Post", new { id = taskList.TaskID }, taskList);
            }
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody]TaskList taskList)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            else
            {
                db.Entry(taskList).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();
                return AcceptedAtAction("Put", new { id = taskList.TaskID }, taskList);
            }
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var taskList = db.TaskLists.SingleOrDefault(t => t.TaskID == id);

            if(taskList == null)
            {
                return NotFound();
            }
            else
            {
                db.TaskLists.Remove(taskList);
                db.SaveChanges();
                return Ok();
            }
        }
    }
}
