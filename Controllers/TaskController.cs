using System;
using System.Collections.Generic;
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

        [ResponseType(typeof(IEnumerable<Task>))]
        [HttpGet]
        public IHttpActionResult GetTask()
        {
            //Load data from database
            IEnumerable<Task> tasks = dbContext.Tasks;

            //Selecting data that we want to return to UI
            IEnumerable<TaskDto> TasksDtos = tasks.Select(task => new TaskDto()
            {
                TaskID = task.TaskID,
                Title = task.Title,
                EstimatedHours = task.EstimatedHours,
                SpendedHours = task.SpendedHours,
                RemainingHours = task.RemainingHours,
                DueDate = task.DueDate,
                PlanedDate =task.PlanedDate,
                Note = task.Note
            });

            return Ok(TasksDtos);
        }

        // GET: api/Task/2
        [ResponseType(typeof(Task))]
        [HttpGet]
        public IHttpActionResult GetTask(int id)
        {
            //Find the Data
            Task Task = dbContext.Tasks.Find(id);
            //if not found, return 404 status code.
            if (Task == null)
            {
                return NotFound();
            }

            //putting into a 'friendly object format'
            TaskDto tasksDto = new TaskDto
            {
                TaskID = Task.TaskID,
                Title = Task.Title,
                EstimatedHours = Task.EstimatedHours,
                SpendedHours = Task.SpendedHours,
                RemainingHours = Task.RemainingHours,
                DueDate = Task.DueDate,
                Note = Task.Note

            };
            //pass along data as 200 status code OK response
            return Ok(tasksDto);
        }

    }
}
