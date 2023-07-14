using Client.Models;

namespace Client.Services
{
    public interface IOrderService
    {
        public Task<List<Product>> CheckoutOrderById(string id);
    }
}
