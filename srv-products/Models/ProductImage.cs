namespace srv_products.Models
{
    public class ProductImage
    {
        public int Id { get; set; }
        public string Content { get; set; }
        //relations
        public int ProductId {  get; set; }
        public Product Product { get; set; }

    }
}
