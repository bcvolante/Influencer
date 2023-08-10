using InfluencerAPI.Services;
using InfuencerAPI.Data;
using InfuencerAPI.Models.MasterDTO;
using InfuencerAPI.Models.OrdersDTO;
using InfuencerAPI.Models.UsersDTO;
using Microsoft.AspNetCore.Mvc;
using Stripe.Checkout;
using System.Collections.Generic;

namespace InfluencerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : Controller
    {
        private readonly InfluencerDbContext dbContext;

        private readonly IOrderService OrderService;

        public OrderController(InfluencerDbContext dbContext, IOrderService orderService)
        {
            this.dbContext = dbContext;
            OrderService = orderService;
        }

        [HttpPost("CreateOrder")]
        public async Task<IActionResult> CreateOrder([FromBody] CreateOrderRequest _CreateOrderRequest)
        {
            try
            {
                var response = await OrderService.CreateOrder(_CreateOrderRequest);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return ErrorResponse.ReturnErrorResponse(ex.Message);
            }

        }

        [HttpPost("CreateDetail")]
        public async Task<IActionResult> CreateDetail(List<CreateDetailRequest> _CreateDetailRequest)
        {
            try
            {
                var response = await OrderService.CreateDetail( _CreateDetailRequest);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return ErrorResponse.ReturnErrorResponse(ex.Message);
            }

        }

        [HttpPost("CreateTarget")]
        public async Task<IActionResult> CreateTarget(List<CreateTargetRequest> _CreateTargetRequest)
        {
            try
            {
                var response = await OrderService.CreateTarget(_CreateTargetRequest);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return ErrorResponse.ReturnErrorResponse(ex.Message);
            }

        }

        // GET RECORD BY ID
        [HttpGet("GetUserById/{id:guid}")]
		public async Task<IActionResult> GetUserById([FromRoute] Guid id)
		{
			try
			{
				var response = await OrderService.GetUserById(id);
				return Ok(response);
			}
			catch (Exception ex)
			{
				return ErrorResponse.ReturnErrorResponse(ex.Message);
			}
        }


        // GET RECORD BY ID
        [HttpGet("GetOrderById/{id:guid}")]
        public async Task<IActionResult> GetOrderById([FromRoute] Guid id)
        {
            try
            {
                var response = await OrderService.GetOrderById(id);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return ErrorResponse.ReturnErrorResponse(ex.Message);
            }
        }
        // GET RECORD BY ID
        [HttpGet("GetOrderByInfluencerId/{id:guid}")]
        public async Task<IActionResult> GetOrderByInfluencerId([FromRoute] Guid id)
        {
            try
            {
                var response = await OrderService.GetOrderByInfluencerId(id);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return ErrorResponse.ReturnErrorResponse(ex.Message);
            }
        }

        // GET RECORD BY ID
        [HttpGet("CheckoutOrderById/{id:guid}")]
        public async Task<IActionResult> CheckoutOrderById([FromRoute] Guid id)
        {
            try
            {
                var response = await OrderService.CheckoutOrderById(id);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return ErrorResponse.ReturnErrorResponse(ex.Message);
            }
        }


        // GET RECORD BY ID
        [HttpGet("ViewOrder/{id:guid}")]
        public async Task<IActionResult> ViewOrder([FromRoute] Guid id)
        {
            try
            {
                var response = await OrderService.ViewOrder(id);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return ErrorResponse.ReturnErrorResponse(ex.Message);
            }
        }

        // GET RECORD BY ID
        [HttpGet("ViewOrderDetail/{id:guid}")]
        public async Task<IActionResult> ViewOrderDetail([FromRoute] Guid id)
        {
            try
            {
                var response = await OrderService.ViewOrderDetail(id);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return ErrorResponse.ReturnErrorResponse(ex.Message);
            }
        }

        // GET RECORD BY ID
        [HttpGet("ViewOrderTarget/{id:guid}")]
        public async Task<IActionResult> ViewOrderTarget([FromRoute] Guid id)
        {
            try
            {
                var response = await OrderService.ViewOrderTarget(id);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return ErrorResponse.ReturnErrorResponse(ex.Message);
            }
        }

        [HttpPut("UpdateOrder")]
        public async Task<IActionResult> UpdateOrder([FromBody] UpdateOrderRequest updateOrderRequest)
        {
            try
            {
                var response = await OrderService.UpdateOrder(updateOrderRequest);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return ErrorResponse.ReturnErrorResponse(ex.Message);
            }

        }
    }
}
