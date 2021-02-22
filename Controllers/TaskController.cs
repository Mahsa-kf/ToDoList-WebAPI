using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using ToDoList.Models;

namespace ToDoList.Controllers
{
    public class TaskController : ApiController
    {

        //This variable is our database access point
        private ToDoListDataContext dbContext = new ToDoListDataContext();

        // GET: api/Task/GetTasks
        [ResponseType(typeof(IEnumerable<Task>))]
        [HttpGet]
        public IHttpActionResult GetTasks()
        {
            //Load data from database
            IEnumerable<Task> tasks = dbContext.Tasks.ToList();
            return Ok(tasks);
        }

        // GET: api/Task/GetTask/2
        [ResponseType(typeof(Task))]
        [HttpGet]
        public IHttpActionResult GetTask(int id)
        {
            //Find the Data
            Task task = dbContext.Tasks.Find(id);
            //if not found, return 404 status code.
            if (task == null)
            {
                return NotFound();
            }

            //putting into a 'friendly object format'
            TaskDto tasksDto = new TaskDto
            {
                TaskID = task.TaskID,
                Title = task.Title,
                EstimatedHours = task.EstimatedHours,
                SpendedHours = task.SpendedHours,
                RemainingHours = task.RemainingHours,
                DueDate = task.DueDate,
                Note = task.Note,
                CategoryID = task.CategoryID

            };
            //pass along data as 200 status code OK response
            return Ok(tasksDto);
        }

        //Post: api/Task/AddTask
        // FORM DATA: category JSON Object
        [ResponseType(typeof(Task))]
        [HttpPost]
        public IHttpActionResult AddTask([FromBody] Task task)
        {
            //Will Validate according to data annotations specified on model
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            dbContext.Tasks.Add(task);
            dbContext.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = task.TaskID }, task);
        }

        // POST: api/Task/UpdateTask/4
        // FORM DATA: Task JSON Object
        [ResponseType(typeof(void))]
        [HttpPost]
        public IHttpActionResult UpdateTask(int id, [FromBody] Task task)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != task.TaskID)
            {
                return BadRequest();
            }

            dbContext.Entry(task).State = EntityState.Modified;

            try
            {
                dbContext.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TaskExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        private bool TaskExists(int id)
        {
            return dbContext.Tasks.Any(c => c.TaskID == id);
        }

        // POST: api/Task/DeleteTask/5
        [HttpPost]
        public IHttpActionResult DeleteTask(int id)
        {
            Task Task = dbContext.Tasks.Find(id);
            if (Task == null)
            {
                return NotFound();
            }

            dbContext.Tasks.Remove(Task);
            dbContext.SaveChanges();

            return Ok();
        }

    }
}
    

