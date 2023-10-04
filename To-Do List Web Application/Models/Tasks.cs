using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace To_Do_List_Web_Application.Models
{
    public class Tasks
    {
        [Key]
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public bool IsCompleted { get; set; }
        [ForeignKey("User")]
        public string? User_Name { get; set; }
        public virtual Users? User { get; set; }

    }
}
