using System.ComponentModel.DataAnnotations;

namespace RepositoryLesson.Models
{
    public class Categories : BaseEntity
    {
        
        public string CategoryName { get; set; }

        public virtual ICollection<Products> Products { get; set; } = new List<Products>();
    }
}
