using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;
using System.Xml.Serialization;

namespace ToDoList.Models
{
    //This class describe a task
    //It is used for generating a database table
    public class Task
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TaskID { get; set; }
        public string Title { get; set; }
        public decimal? EstimatedHours { get; set; }
        public decimal? SpendedHours { get; set; }
        public decimal? RemainingHours { get; set; }
        public DateTime? DueDate { get; set; }
        public DateTime? PlanedDate { get; set; }
        public string Note { get; set; }

        [ForeignKey("Category")]
        public int? CategoryID { get; set; }

        [XmlIgnore]
        public virtual Category Category { get; set; }
    }

    public class TaskDto
    {
        public int TaskID { get; set; }
        public string Title { get; set; }
        public decimal? EstimatedHours { get; set; }
        public decimal? SpendedHours { get; set; }
        public decimal? RemainingHours { get; set; }
        public DateTime? DueDate { get; set; }
        public DateTime? PlanedDate { get; set; }
        public string Note { get; set; }
        // public int CategoryID { get; set; }
    }
}