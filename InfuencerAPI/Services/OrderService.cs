using InfuencerAPI.Data;
using InfuencerAPI.Models.MasterDTO;
using InfuencerAPI.Models.OrdersDTO;
using InfuencerAPI.Models.Users;
using InfuencerAPI.Models.Orders;
using Microsoft.EntityFrameworkCore;
using InfluencerAPI.Models.OrdersDTO;
using Microsoft.AspNetCore.Mvc;
using InfluencerAPI.Models.Stripe;
using Microsoft.AspNetCore.Hosting.Server.Features;
using Microsoft.AspNetCore.Hosting.Server;
using Stripe.Checkout;
using InfuencerAPI.Models.UsersDTO;

namespace InfluencerAPI.Services
{
    public class OrderService: IOrderService
    {
        private readonly InfluencerDbContext dbContext;
        private readonly IConfiguration _configuration;

        public OrderService(InfluencerDbContext dbContext, IConfiguration configuration)
        {
            this.dbContext = dbContext;
            _configuration = configuration;
        }

        public async Task<MainResponse> CreateOrder(CreateOrderRequest _CreateOrderRequest)
        {
            var response = new MainResponse();
            try
            {
                var newId = Guid.NewGuid();
                var _Order = new Orders()
                {
                    Id = newId,
                    UserId = _CreateOrderRequest.UserId,
                    InfluencerId = _CreateOrderRequest.InfluencerId,
                    IsApproved = false,
                    Status = "Order Received"
                };

                await dbContext.Order.AddAsync(_Order);
                await dbContext.SaveChangesAsync();

                var _Calendar = new Calendar()
                {
                    OrderId = newId,
                    Date = _CreateOrderRequest.Date,
                    TimeId = _CreateOrderRequest.TimeId
                };

                await dbContext.OrderCalendars.AddAsync(_Calendar);
                await dbContext.SaveChangesAsync();
                response.Content = newId.ToString();
            }
            catch (Exception ex)
            {
                response.ErrorMessage = ex.Message;
                response.IsSuccess = false;
            }

            return response;
        }
        public async Task<MainResponse> CreateDetail(List<CreateDetailRequest> _CreateDetailRequest)
        {
            var response = new MainResponse();
            try
            {
                foreach (var item in _CreateDetailRequest)
                {
                    var _Detail = new Detail()
                    {
                        OrderId = item.Id,
                        TypeId = item.TypeId,
                        ServiceTypeId = item.ServiceTypeId,
                        Amount = item.Amount
                    };
                    await dbContext.OrderDetails.AddAsync(_Detail);
                    await dbContext.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                response.ErrorMessage = ex.Message;
                response.IsSuccess = false;
            }

            return response;
        }

        public async Task<MainResponse> CreateTarget(List<CreateTargetRequest> _CreateTargetRequest)
        {
            var response = new MainResponse();
            try
            {
                foreach (var item in _CreateTargetRequest)
                {
                    var _Target = new Target()
                    {
                        OrderId = item.Id,
                        FilePath = item.FilePath,
                        Description = item.Description
                    };
                    await dbContext.OrderTargets.AddAsync(_Target);
                    await dbContext.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                response.ErrorMessage = ex.Message;
                response.IsSuccess = false;
            }

            return response;
        }

        //public async Task<CheckoutOrderResponse> OrderCheckout(List<Product> product, [FromServices] IServiceProvider sp)
        //{
        //    var response = new MainResponse();
        //    try
        //    {
        //        var server = sp.GetRequiredService<IServer>();

        //        var serverAddressesFeature = server.Features.Get<IServerAddressesFeature>();

        //        string? thisApiUrl = string.Empty;

        //        if (serverAddressesFeature is not null)
        //        {
        //            thisApiUrl = serverAddressesFeature.Addresses.FirstOrDefault();
        //        }

        //        if (thisApiUrl is not null)
        //        {
        //            var sessionId = await CheckOut(product, thisApiUrl);
        //            var pubKey = _configuration["Stripe:PubKey"];

        //            var checkoutOrderResponse = new CheckoutOrderResponse()
        //            {
        //                SessionId = sessionId,
        //                PubKey = pubKey
        //            };

        //            return Ok(checkoutOrderResponse);
        //        }
        //        else
        //        {
        //            return StatusCode(500);
        //        }



        //        foreach (var item in _CreateDetailRequest)
        //        {
        //            var _Detail = new Detail()
        //            {
        //                OrderId = item.Id,
        //                TypeId = item.TypeId,
        //                ServiceTypeId = item.ServiceTypeId,
        //                Amount = item.Amount
        //            };
        //            await dbContext.OrderDetails.AddAsync(_Detail);
        //            await dbContext.SaveChangesAsync();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        response.ErrorMessage = ex.Message;
        //        response.IsSuccess = false;
        //    }

        //    return response;
        //}
        //public async Task<string> CheckOut(List<Product> product, string thisApiUrl)
        //{
        //    var _LineItems = new List<SessionLineItemOptions>();

        //    foreach (var item in product)
        //    {
        //        var _LineItem = new SessionLineItemOptions()
        //        {
        //            PriceData = new SessionLineItemPriceDataOptions
        //            {
        //                UnitAmount = item.Price, // Price is in USD cents.
        //                Currency = "USD",
        //                ProductData = new SessionLineItemPriceDataProductDataOptions
        //                {
        //                    Name = item.Title,
        //                    Description = item.Description,
        //                    Images = new List<string> { item.ImageUrl }
        //                },
        //            },
        //            Quantity = 1,
        //        };
        //        _LineItems.Add(_LineItem);
        //    }

        //        // Create a payment flow from the items in the cart.
        //        // Gets sent to Stripe API.
        //    var options = new SessionCreateOptions
        //    {
        //        // Stripe calls the URLs below when certain checkout events happen such as success and failure.
        //        SuccessUrl = $"{thisApiUrl}/checkout/success?sessionId=" + "{CHECKOUT_SESSION_ID}", // Customer paid.
        //                                                                                            //CancelUrl = s_wasmClientURL + "failed",  // Checkout cancelled.
        //        PaymentMethodTypes = new List<string> // Only card available in test mode?
        //        {
        //            "card"
        //        },
        //        LineItems = _LineItems,
        //        Mode = "payment" // One-time payment. Stripe supports recurring 'subscription' payments.
        //    };

        //    var service = new SessionService();
        //    var session = await service.CreateAsync(options);

        //    return session.Id;
        //}

        public async Task<MainResponse> GetUserById(Guid id)
		{
			var response = new MainResponse();
			try
			{
				response.Content =
					await (
					from b in dbContext.Order
					join c in dbContext.Users on b.UserId equals c.Id
					join v in dbContext.Settings on c.IndustryId equals v.Id
					select new
					{
						b.Id,
						b.UserId,
						b.InfluencerId,
						b.Status,
						b.IsActive,
						b.IsApproved,
						b.DateCreated,
						c.Name,
						c.ImagePath,
						c.IndustryId,
						Industry = v.Name
					})
					.Where(b => b.InfluencerId == id)
					.OrderByDescending(b => b.DateCreated)
					.ToListAsync();

				response.IsSuccess = true;
			}
			catch (Exception ex)
			{
				response.ErrorMessage = ex.Message;
				response.IsSuccess = false;
			}
			return response;
        }
        public async Task<MainResponse> GetOrderById(Guid id)
        {
            var response = new MainResponse();
            try
            {
                response.Content =
                    await (
                    from b in dbContext.Order
                    join c in dbContext.Influencer on b.InfluencerId equals c.Id
                    join v in dbContext.Settings on c.IndustryId equals v.Id
                    select new
                    {
                        b.Id,
                        b.UserId,
                        b.InfluencerId,
                        b.Status,
                        b.IsActive,
                        b.IsApproved,
                        b.DateCreated,
                        c.Name,
                        c.ImagePath,
                        c.IndustryId,
                        Industry = v.Name
                    })
                    .Where(b => b.UserId == id)
                    .OrderByDescending(b => b.DateCreated)
                    .ToListAsync();

                response.IsSuccess = true;
            }
            catch (Exception ex)
            {
                response.ErrorMessage = ex.Message;
                response.IsSuccess = false;
            }
            return response;
        }
        public async Task<MainResponse> GetOrderByInfluencerId(Guid id)
        {
            var response = new MainResponse();
            try
            {
                response.Content =
                    await (
                    from b in dbContext.Order
					join c in dbContext.Influencer on b.InfluencerId equals c.Id
					join bc in dbContext.Users on b.UserId equals bc.Id
					join v in dbContext.Settings on c.IndustryId equals v.Id
                    select new
                    {
                        b.Id,
                        UserId = b.InfluencerId,
                        InfluencerId = b.UserId,
                        b.Status,
                        b.IsActive,
                        b.IsApproved,
                        b.DateCreated,
                        bc.Name,
                        bc.ImagePath,
                        bc.IndustryId,
                        Industry = v.Name
                    })
                    .Where(b => b.UserId == id)
                    .OrderByDescending(b => b.DateCreated)
                    .ToListAsync();

                response.IsSuccess = true;
            }
            catch (Exception ex)
            {
                response.ErrorMessage = ex.Message;
                response.IsSuccess = false;
            }
            return response;
        }
        public async Task<MainResponse> CheckoutOrderById(Guid id)
        {
            var response = new MainResponse();
            try
            {
                response.Content =
                    await (
                    from b in dbContext.Order
                    join bc in dbContext.OrderDetails on b.Id equals bc.OrderId
                    join c in dbContext.Influencer on b.InfluencerId equals c.Id
                    join v in dbContext.Settings on bc.ServiceTypeId equals v.Id
                    select new
                    {
                        OrderId = b.Id,
                        Title = c.Name + " - " + v.Name,
                        Description = "Collaboration : " + c.Name + " - " + v.Name,
                        ImageUrl = c.ImagePath,
                        Price = bc.Amount
                    })
                    .Where(b => b.OrderId == id)
                    .ToListAsync();

                response.IsSuccess = true;
            }
            catch (Exception ex)
            {
                response.ErrorMessage = ex.Message;
                response.IsSuccess = false;
            }
            return response;
        }
        public async Task<MainResponse> ViewOrderDetail(Guid id)
        {
            var response = new MainResponse();
            try
            {
                response.Content =
                    await dbContext.OrderDetails
                    .Where(b => b.OrderId == id)
                    .OrderByDescending(b => b.DateCreated)
                    .ToListAsync();

                response.IsSuccess = true;
            }
            catch (Exception ex)
            {
                response.ErrorMessage = ex.Message;
                response.IsSuccess = false;
            }
            return response;
        }
        public async Task<MainResponse> ViewOrderTarget(Guid id)
        {
            var response = new MainResponse();
            try
            {
                response.Content =
                    await dbContext.OrderTargets
                    .Where(b => b.OrderId == id)
                    .OrderByDescending(b => b.DateCreated)
                    .ToListAsync();

                response.IsSuccess = true;
            }
            catch (Exception ex)
            {
                response.ErrorMessage = ex.Message;
                response.IsSuccess = false;
            }
            return response;
        }
        public async Task<MainResponse> ViewOrder(Guid id)
        {
            var response = new MainResponse();
            try
            {
                response.Content =
                    await (
                    from b in dbContext.Order
                    join c in dbContext.OrderCalendars on b.Id equals c.OrderId
                    select new
                    {
                        b.Id,
                        b.UserId,
                        b.InfluencerId,
                        c.Date,
                        c.TimeId,
                        b.DateCreated,
                        b.IsActive,
                        b.IsApproved,
                        b.Status,
                        b.Remarks
                    })
                    .Where(b => b.Id == id)
                    .OrderByDescending(b => b.DateCreated)
                    .FirstOrDefaultAsync();

                response.IsSuccess = true;
            }
            catch (Exception ex)
            {
                response.ErrorMessage = ex.Message;
                response.IsSuccess = false;
            }
            return response;
        }

        public async Task<MainResponse> UpdateOrder(UpdateOrderRequest updateOrderRequest)
        {
            var response = new MainResponse();
            try
            {
                var Order = dbContext.Order.Where(b =>
                    b.Id == updateOrderRequest.Id && b.InfluencerId == updateOrderRequest.InfluencerId).FirstOrDefault();

                if (Order != null)
                {
                    Order.IsApproved = updateOrderRequest.IsApproved;
                    Order.Status = updateOrderRequest.Status;
                    Order.Remarks = updateOrderRequest.Remarks;
                    await dbContext.SaveChangesAsync();

                    response.IsSuccess = true;
                    response.Content = "Record successfully updated.";
                }
                else
                {
                    response.IsSuccess = false;
                    response.Content = "Record update failed.";
                }

            }
            catch (Exception ex)
            {
                response.ErrorMessage = ex.Message;
                response.IsSuccess = false;
            }

            return response;
        }
    }
}
