using System.ComponentModel.DataAnnotations;

namespace StudentPortal.Models.Entities
{
    public class Student
    {
        [Key]
        [Required]
        public Guid StudentId { get; set; }
        [Required]
        public string StudentName { get; set; }

        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        [Required]
        public bool Subscribed { get; set; }
    }
}
