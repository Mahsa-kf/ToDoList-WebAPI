using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ToDoList.Models
{
    public class Category
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CategoryID { get; set; }
        public string CategoryTitle { get; set; }
        public string Color { get; set; }

        //each category can have multiple tasks
        [JsonIgnore]
        public ICollection<Task> Tasks { get; set; }
    }
    public class CategoryDto
    {
        public int CategoryID { get; set; }
        public string CategoryTitle { get; set; }
        public string Color { get; set; }
    }
}