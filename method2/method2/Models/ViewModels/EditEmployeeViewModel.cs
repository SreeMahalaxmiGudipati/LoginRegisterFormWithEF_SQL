using System.ComponentModel.DataAnnotations;

namespace method2.Models.ViewModels
{
    public class EditEmployeeViewModel
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? PhoneNo { get; set; }

        public string? Password { get; set; }

    }
}
