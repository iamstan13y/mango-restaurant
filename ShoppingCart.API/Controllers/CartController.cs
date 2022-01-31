using Mango.MessageBus;
using Microsoft.AspNetCore.Mvc;
using ShoppingCart.API.Models.Dto;
using ShoppingCart.API.Models.Messages;
using ShoppingCart.API.Models.Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShoppingCart.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartRepository _cartRepository;
        private readonly ICouponRepository _couponRepository;
        private readonly IMessageBus _messageBus;
        protected ResponseDto _response;

        public CartController(ICartRepository cartRepository, ICouponRepository couponRepository, IMessageBus messageBus)
        {
            _couponRepository = couponRepository;
            _cartRepository = cartRepository;
            _messageBus = messageBus;
            _response = new();
        }

        [HttpGet("GetCart/{userId}")]
        public async Task<object> GetCart(string userId)
        {
            try
            {
                CartDto cartDto = await _cartRepository.GetCartByUserId(userId);
                _response.Result = cartDto;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [HttpPost("AddCart")]
        public async Task<object> AddCart(CartDto cartDto)
        {
            try
            {
                var result = await _cartRepository.CreateUpdateCart(cartDto);
                _response.Result = result;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.ToString() };
            }
            return _response;
        }

        [HttpPost("UpdateCart")]
        public async Task<object> UpdateCart(CartDto cartDto)
        {
            try
            {
                var result = await _cartRepository.CreateUpdateCart(cartDto);
                _response.Result = result;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.ToString() };
            }
            return _response;
        }

        [HttpDelete("RemoveCart/{cartId}")]
        public async Task<object> RemoveCart([FromRoute] int cartId)
        {
            try
            {
                bool isSuccess = await _cartRepository.RemoveFromCart(cartId);
                _response.Result = isSuccess;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.ToString() };
            }
            return _response;
        }

        [HttpPost("ApplyCoupon")]
        public async Task<object> ApplyCoupon([FromBody] CartDto cartDto)
        {
            try
            {
                var result = await _cartRepository.ApplyCoupon(cartDto.CartHeader.UserId, cartDto.CartHeader.CouponCode);
                _response.Result = result;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.ToString() };
            }
            return _response;
        }

        [HttpDelete("RemoveCoupon/{userId}")]
        public async Task<object> RemoveCoupon([FromRoute] string userId)
        {
            try
            {
                var result = await _cartRepository.RemoveCoupon(userId);
                _response.Result = result;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.ToString() };
            }
            return _response;
        }
        
        [HttpPost("Checkout")]
        public async Task<object> Checkout(CheckoutHeaderDto checkoutHeader)
        {
            try
            {
                CartDto cartDto = await _cartRepository.GetCartByUserId(checkoutHeader.UserId);
                
                if (cartDto == null)
                {
                    return BadRequest();
                }

                if (!string.IsNullOrEmpty(checkoutHeader.CouponCode))
                {
                    CouponDto coupon = await _couponRepository.GetCoupon(checkoutHeader.CouponCode);
                    if (checkoutHeader.DiscountTotal != coupon.DiscountAmount)
                    {
                        _response.IsSuccess = false;
                        _response.ErrorMessages = new List<string>() { "Coupon amount has changed, please confirm!" };
                        _response.DisplayMessage = "Invalid Coupon";

                        return _response;
                    }
                }

                checkoutHeader.CartDetails = cartDto.CartDetails;

                await _messageBus.PublishMessage(checkoutHeader, "checkoutmessagetopic");
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.ToString() };
            }

            return _response;
        }
    }
}