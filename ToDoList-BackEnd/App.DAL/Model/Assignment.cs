using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.DAL.Model
{
    public class Assignment
    {
        [Key]
        public int Id { get; set; }
        public string? Title { get; set; }
        
        public string? Date { get; set; }
        public bool Status { get; set; }
        public bool Urgently { get; set; }
    }
}
