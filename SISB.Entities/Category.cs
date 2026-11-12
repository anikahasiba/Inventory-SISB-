using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SISB.Entities
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        [Required, StringLength(100)]
        public string Name { get; set; } = string.Empty;

        public int? ParentCategoryId { get; set; }

        [ForeignKey(nameof(ParentCategoryId))]
        public virtual Category? ParentCategory { get; set; }

        public virtual ICollection<Category> SubCategories { get; set; } = new List<Category>();
        public virtual ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
