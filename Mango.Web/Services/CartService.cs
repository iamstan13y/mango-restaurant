using Mango.Web.Enums;
using Mango.Web.Models;
using Mango.Web.Services.IServices;
using System.Net.Http;
using System.Threading.Tasks;

namespace Mango.Web.Services
{
    public class CartService : BaseService, ICartService
    {
        public CartService(IHttpClientFactory clientFactory) : base(clientFactory)
        {
        }

        public async Task<T> AddToCartAsync<T>(CartDto cartDto, string token = null)
        {
            return await SendAsync<T>(new ApiRequest()
            {
                ApiType = ApiType.POST,
                Data = cartDto,
                Url = SD.ShoppingCartAPIBase + "/api/cart/AddCart",
                AccessToken = token
            });
        }

        public async Task<T> ApplyCouponAsync<T>(CartDto cartDto, string token = null)
        {
            return await SendAsync<T>(new ApiRequest()
            {
                ApiType = ApiType.POST,
                Data = cartDto,
                Url = SD.ShoppingCartAPIBase + "/api/cart/ApplyCoupon/",
                AccessToken = token
            });
        }

        public async Task<T> CheckoutAsync<T>(CartHeaderDto cartHeader, string token = null)
        {
            return await SendAsync<T>(new ApiRequest()
            {
                ApiType = ApiType.POST,
                Data = cartHeader,
                Url = SD.ShoppingCartAPIBase + "/api/cart/checkout/",
                AccessToken = token
            });
        }

        public async Task<T> GetCartByUserIdAsync<T>(string userId, string token = null)
        {
            return await SendAsync<T>(new ApiRequest()
            {
                ApiType = ApiType.GET,
                Url = SD.ShoppingCartAPIBase + "/api/cart/GetCart/" + userId,
                AccessToken = token
            });
        }

        public async Task<T> RemoveCouponAsync<T>(string userId, string token = null)
        {
            return await SendAsync<T>(new ApiRequest()
            {
                ApiType = ApiType.DELETE,
                Url = SD.ShoppingCartAPIBase + "/api/cart/RemoveCoupon/" + userId,
                AccessToken = token
            });
        }

        public async Task<T> RemoveFromCartAsync<T>(int cartId, string token = null)
        {
            return await SendAsync<T>(new ApiRequest()
            {
                ApiType = ApiType.DELETE,
                Url = SD.ShoppingCartAPIBase + "/api/cart/RemoveCart/" + cartId,
                AccessToken = token
            });
        }

        public async Task<T> UpdateToCartAsync<T>(CartDto cartDto, string token = null)
        {
            return await SendAsync<T>(new ApiRequest()
            {
                ApiType = ApiType.POST,
                Data = cartDto,
                Url = SD.ProductAPIBase + "/api/cart/UpdateCart",
                AccessToken = token
            });
        }
    }
}