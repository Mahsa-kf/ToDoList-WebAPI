using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace ToDoList.Models
{
    public class ToDoListDataContext : DbContext
    {
        public ToDoListDataContext() : base("name=ToDoListDataContext")
        {
        }

        //Instruction to set the models as tables in our database.
        public DbSet<Task> Tasks { get; set; }
        public DbSet<Category> Categories { get; set; }

    }
}