using System;
using System.Threading.Tasks;
using Grpc.Net.Client;

namespace Consumer
{
    class Program
    {
        static async Task Main(string[] args)
        {
            using var channel = GrpcChannel.ForAddress("http://localhost:5000");

            var clientv1 =  new Ecommerce.V1.Products.ProductsClient(channel);
            var productv1 = await clientv1.GetProductAsync(new Ecommerce.V1.ProductId{ Value = "1001"});
            Console.WriteLine($"- [*]: Product: Id= {productv1.Id},   Name={productv1.Name},   Description={productv1.Description}");
                       

            var clientv2 =  new Ecommerce.V2.Products.ProductsClient(channel);
            var productv2 = await clientv2.GetProductAsync(new Ecommerce.V2.ProductId{ Value = 1001 });
            Console.WriteLine($"- [*]: Product: Id= {productv2.Id},   Name={productv2.Name},   Description={productv2.Description}");
                       
            
            Console.WriteLine("Press any key to exit...");


            Console.ReadKey();
        }
    }
}
