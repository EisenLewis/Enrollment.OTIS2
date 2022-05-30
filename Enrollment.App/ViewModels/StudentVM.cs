using System.ComponentModel.DataAnnotations;

namespace Enrollment.App.ViewModels
{
    public class StudentVM
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string Lastname { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string Firstname { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime AdmissionDate { get; set; }
    }
}
