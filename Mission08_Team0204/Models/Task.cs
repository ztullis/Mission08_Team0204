using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission08_Team0204.Models
{
    public class Task
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TaskId { get; set; }
        [Required(ErrorMessage ="You must enter a Task")]
        public string TaskStr {  get; set; }
        public DateTime? DueDate { get; set; }

        [Required(ErrorMessage = "You must select a Quadrant")]
        public int Quadrant { get; set; }

        [ForeignKey("CategoryId")]
        public int? CategoryId { get; set; }
        public Category? Category { get; set; }
        public bool? IsCompleted { get; set; }
    }
}
