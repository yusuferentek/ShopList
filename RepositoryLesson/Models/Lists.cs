using System.ComponentModel.DataAnnotations;

namespace RepositoryLesson.Models
{
    public class Lists : BaseEntity
    {

        public int UserId { get; set; }

        public string? ListName { get; set; }

        public byte? ListStatus { get; set; }

        public virtual Users User { get; set; } = null!;
        public virtual ICollection<ShopListProductMapping> ShoplistProductMappings { get; set; } = new List<ShopListProductMapping>();

    }
}
