
namespace InventoryManagement.Entity.Master
{
    public class ProductEntity : BaseEntity<Guid>
    {

        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public string ProductCateogry { get; set; }
    }
}
