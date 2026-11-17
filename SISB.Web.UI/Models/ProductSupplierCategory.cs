using SISB.Entities;

namespace SISB.Web.UI.Models
{
    public class ProductSupplierCategory
    {
        public List<Product> product {  get; set; }
        public List<Category> category { get; set; }
        public List<Supplier> supplier { get; set; }
    }
}
