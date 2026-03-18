using System.ComponentModel.DataAnnotations;

namespace Tasks.Models
{
    public class TaskItem
    {
        [Key]
        public int TaskId { get; set; }
        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime DueDate { get; set; }
        public string Status { get; set; }

        public int CreatedBy { get; set; }
    }
}
