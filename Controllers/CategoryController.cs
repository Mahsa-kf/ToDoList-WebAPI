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
    public class CategoryController : ApiController
    {

        //This variable is our database access point
        private ToDoListDataContext dbContext = new ToDoListDataContext();

        [ResponseType(typeof(IEnumerable<Category>))]
        [HttpGet]       

       
        public IHttpActionResult GetCategory()
        {
            //Load data from database
            IEnumerable<Category> Categories = dbContext.Categories;

            //Selecting data that we want to return to UI
            IEnumerable<CategoryDto> CategoryDtos = Categories.Select(Category => new CategoryDto()
            {
                CategoryID = Category.CategoryID,
                CategoryTitle = Category.CategoryTitle,
                Color = Category.Color              
            });

            return Ok(CategoryDtos);
        }

        // GET: api/Category/2
        [ResponseType(typeof(Category))]
        [HttpGet]
        public IHttpActionResult GetCategory(int id)
        {
            //Find the Data
            Category Category = dbContext.Categories.Find(id);
            //if not found, return 404 status code.
            if (Category == null)
            {
                return NotFound();
            }

            //putting into a 'friendly object format'
            CategoryDto CategoriesDto = new CategoryDto
            {
                CategoryID = Category.CategoryID,
                CategoryTitle = Category.CategoryTitle,
                Color = Category.Color
            };
            //pass along data as 200 status code OK response
            return Ok(CategoriesDto);
        }

    }
}
