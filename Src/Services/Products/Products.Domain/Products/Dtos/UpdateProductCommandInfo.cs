namespace Products.Domain.Products.Dtos
{
    public class UpdateProductCommandInfo:AddProductCommandInfo
    {
        public long Id { get; set; }
    }
}
