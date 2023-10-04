using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RepositoryLesson.Models
{
    public class Products : BaseEntity
    {
        public string ProductName { get; set; }

        public int CategoryId { get; set; }

        public bool? IsPurchased { get; set; }

        public byte[]? Photo { get; set; }
        public virtual Categories Category { get; set; } = null!;

        public virtual ICollection<ShopListProductMapping> ShoplistProductMappings { get; set; } = new List<ShopListProductMapping>();


    }
}
