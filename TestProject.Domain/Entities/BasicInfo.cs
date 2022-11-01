using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.Domain.Entities
{
    public class BasicInfo
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FatherName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string City { get; set; }
        public DateTime? StartDate { get; set; }
    }
}
