using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.DAL.Model
{
    //it's optional but I anyway leave it here
    public static class StatusTypeClass
    {
        public const string ToDo = "To Do";

        public const string InProgress = "In Progress";
        public const string Done = "Done";

    }
    public class Assignment
    {
        public Assignment() {
            Status = StatusTypeClass.ToDo;
        }

        [Key]
        public int Id { get; set; }
        public string? Title { get; set; }
        
        public string? Date { get; set; }

        public string Status { get; set; }
        public bool Urgently { get; set; }
    }



}
