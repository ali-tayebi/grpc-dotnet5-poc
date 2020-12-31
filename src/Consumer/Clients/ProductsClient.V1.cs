using System.Threading.Tasks;
using Ecommerce.V1;

namespace Consumer.Clients
{
    public class ProductsClientV1
    {
        Products.ProductsClient _client;
        public ProductsClientV1(Products.ProductsClient client)
        {
            _client = client;
        }

        public async Task<Product> GetProductByIdAsync(ProductId id) =>
         await _client.GetProductAsync(id);
    } 
}
