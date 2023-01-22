using System.ComponentModel.DataAnnotations;

namespace ToDoList_BackEnd.Model
{
    public class Assignment
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public bool Status { get; set; }

    }
}
