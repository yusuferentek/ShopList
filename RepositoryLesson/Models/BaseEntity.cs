using System.ComponentModel.DataAnnotations;

namespace RepositoryLesson.Models
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
