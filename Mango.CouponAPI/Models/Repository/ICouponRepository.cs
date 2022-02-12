using Mango.CouponAPI.Models.Dto;
using System.Threading.Tasks;

namespace Mango.CouponAPI.Models.Repository
{
    public interface ICouponRepository
    {
        Task<CouponDto> GetCouponByCode(string couponCode);
    }
}