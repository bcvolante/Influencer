using InfluencerAPI.Models.OrdersDTO;
using InfuencerAPI.Models.MasterDTO;
using InfuencerAPI.Models.OrdersDTO;
using Microsoft.AspNetCore.Mvc;

namespace InfluencerAPI.Services
{
    public interface IOrderService
    {
        Task<MainResponse> CreateOrder(CreateOrderRequest _CreateOrderRequest);
        Task<MainResponse> CreateDetail(List<CreateDetailRequest> _CreateDetailRequest);
        Task<MainResponse> CreateTarget(List<CreateTargetRequest> _CreateTargetRequest);
        Task<MainResponse> CheckoutOrderById(Guid id);
        Task<MainResponse> GetUserById(Guid id);
		Task<MainResponse> GetOrderById(Guid id);
        Task<MainResponse> GetOrderByInfluencerId(Guid id);
        Task<MainResponse> ViewOrder(Guid id);
        Task<MainResponse> ViewOrderDetail(Guid id);
        Task<MainResponse> ViewOrderTarget(Guid id);
        Task<MainResponse> UpdateOrder(UpdateOrderRequest updateOrderRequest);
    }
}
