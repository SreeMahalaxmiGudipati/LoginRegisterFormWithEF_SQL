using System.ComponentModel.DataAnnotations;

namespace method2.Models.Domain
{
    public class Employee
    {
        [Key]
        public int Id { get; set; } 
        public string? Name { get; set; }
        public string? PhoneNo { get; set; }

        public string? Password { get; set; }


    }
}
