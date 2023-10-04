using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RepositoryLesson.Models
{
    public class Users : BaseEntity
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Role {  get; set; }
        public virtual ICollection<Lists> Lists { get; set; } = new List<Lists>();

    }
}
