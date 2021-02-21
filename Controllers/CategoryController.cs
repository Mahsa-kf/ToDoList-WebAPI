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
    public class CategoryController : ApiController
    {

        //This variable is our database access point
        private ToDoListDataContext dbContext = new ToDoListDataContext();

        // GET: api/Task/GetTasks
        [ResponseType(typeof(IEnumerable<Category>))]
        [HttpGet]       
        public IHttpActionResult GetCategories()
        {
            //Load data from database
            IEnumerable<Category> categories = dbContext.Categories;

            //Selecting data that we want to return to UI
            IEnumerable<CategoryDto> CategoryDtos = categories.Select(category => new CategoryDto()
            {
                CategoryID = category.CategoryID,
                CategoryTitle = category.CategoryTitle,
                Color = category.Color              
            });

            return Ok(CategoryDtos);
        }

        // GET: api/Task/GetTask/3
        [ResponseType(typeof(Category))]
        [HttpGet]
        public IHttpActionResult GetCategory(int id)
        {
            //Find the Data
            Category category = dbContext.Categories.Find(id);
            //if not found, return 404 status code.
            if (category == null)
            {
                return NotFound();
            }

            //putting into a 'friendly object format'
            CategoryDto CategoriesDto = new CategoryDto
            {
                CategoryID = category.CategoryID,
                CategoryTitle = category.CategoryTitle,
                Color = category.Color
            };
            //pass along data as 200 status code OK response
            return Ok(CategoriesDto);
        }

        //Post: api/category/AddCategory
        //FORM DATA: category JSON Object
        [ResponseType(typeof(Category))]
        [HttpPost]
        public IHttpActionResult AddCategory([FromBody] Category category)
        {
            //Will Validate according to data annotations specified on model
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            dbContext.Categories.Add(category);
            dbContext.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = category.CategoryID }, category);
        }

        // POST: api/Category/UpdateCategory/4
        // FORM DATA: Category JSON Object
        [ResponseType(typeof(void))]
        [HttpPost]
        public IHttpActionResult UpdateCategory(int id, [FromBody] Category category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != category.CategoryID)
            {
                return BadRequest();
            }

            dbContext.Entry(category).State = EntityState.Modified;

            try
            {
                dbContext.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoryExists(id))
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

        private bool CategoryExists(int id)
        {
            return dbContext.Categories.Any(c => c.CategoryID == id); 
        }

        // POST: api/Category/DeleteCategory/5
        [HttpPost]
        public IHttpActionResult DeleteCategory(int id)
        {
            Category category = dbContext.Categories.Find(id);
            if (category == null)
            {
                return NotFound();
            }

            dbContext.Categories.Remove(category);
            dbContext.SaveChanges();

            return Ok();
        }

    }
}
