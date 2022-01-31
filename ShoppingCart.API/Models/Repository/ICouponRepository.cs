using ShoppingCart.API.Models.Dto;
using System.Threading.Tasks;

namespace ShoppingCart.API.Models.Repository
{
    public interface ICouponRepository
    {
        Task<CouponDto> GetCoupon(string couponName);
    }
}
