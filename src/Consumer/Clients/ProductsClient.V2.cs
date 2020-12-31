using System.Threading.Tasks;
using Ecommerce.V2;

namespace Consumer.Clients
{
    public class ProductsClientV2
    {
        Products.ProductsClient _client;
        public ProductsClientV2(Products.ProductsClient client)
        {
            _client = client;
        }

        public async Task<Product> GetProductByIdAsync(ProductId id) =>
         await _client.GetProductAsync(id);
    } 
}
