namespace RepositoryLesson.Models
{
    public class ShopListProductMapping : BaseEntity
    {
        public int? ProductId { get; set; }

        public int? ShopListId { get; set; }

        public string? Description { get; set; }

        public virtual Products? Product { get; set; }

        public virtual Lists? ShopList { get; set; }
    }
}
