using System.ComponentModel.DataAnnotations;

namespace SmartSchools.Models
{
    public class TeachersTest
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
