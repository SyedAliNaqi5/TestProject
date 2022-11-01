using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.Domain.ViewModels
{
    public class BasicInfoViewModel
    {
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string FatherName { get; set; }
        [Required]
        public DateTime? DateOfBirth { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public DateTime? StartDate { get; set; }
    }
}
