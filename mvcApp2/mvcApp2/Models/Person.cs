using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace mvcApp2.Models
{
    public class Person
    {
        [DisplayName("First name")]
        [Required]
        public string? FirstName { get; set; }

        [DisplayName("Last name")]
        [Required]
        public string? LastName { get; set; }
    }
}
