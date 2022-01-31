using Mango.Web.Enums;
using Mango.Web.Models;
using Mango.Web.Services.IServices;
using System.Net.Http;
using System.Threading.Tasks;

namespace Mango.Web.Services
{
    public class CouponService : BaseService, ICouponService
    {
        private readonly IHttpClientFactory _client;

        public CouponService(IHttpClientFactory client) : base(client)
        {
            _client = client;
        }

        public async Task<T> GetCoupon<T>(string couponCode, string token = null)
        {
            return await SendAsync<T>(new ApiRequest()
            {
                ApiType = ApiType.GET,
                Url = SD.CouponAPIBase + "/api/Coupon/" + couponCode,
                AccessToken = token
            });
        }
    }
}
