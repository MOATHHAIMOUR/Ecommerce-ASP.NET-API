namespace Ecommerce.Domain.Entites
{
    public class Image
    {
        public int ImageId { get; set; }
        public int ProductId { get; set; }
        public byte[] ImageData { get; set; }

        public Product Product { get; set; }
    }
}
