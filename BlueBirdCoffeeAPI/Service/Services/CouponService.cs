using AutoMapper;
using Data.AppException;
using Data.DataAccessLayer;
using Data.Entities;
using Data.ViewModels;
using Microsoft.AspNetCore.Rewrite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public interface ICouponService
    {
        List<CouponUseableModel> Useable();
        List<CouponViewModel> Get(string? seachValue);
        Guid Add(CouponAddModel model);
        Guid Update(Guid id, CouponAddModel model);
        Guid Delete(Guid id);
        double CheckCoupon(string coupon, double total);
        double UseCoupon(string coupon, double total);
    }
    public class CouponService : ICouponService
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;

        public CouponService(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public List<CouponUseableModel> Useable()
        {
            var coupons = _dbContext.Coupons
                .Where(f => f.FromDate <= DateTime.UtcNow.AddHours(7) && f.ToDate >= DateTime.UtcNow.AddHours(7))
                .Where(f => f.Limit == null || f.Limit > 0)
                .ToList();

            return _mapper.Map<List<CouponUseableModel>>(coupons);
        }
        public List<CouponViewModel> Get(string? seachValue)
        {
            var coupons = _dbContext.Coupons.Where(f => string.IsNullOrEmpty(seachValue) || f.Description.Contains(seachValue)).OrderByDescending(f => f.DateCreated).ToList();

            return _mapper.Map<List<CouponViewModel>>(coupons);

        }
        public Guid Add(CouponAddModel model)
        {
            var newCoupon = _mapper.Map<Coupon>(model);

            _dbContext.Add(newCoupon);
            _dbContext.SaveChanges();

            return newCoupon.Id;
        }
        public Guid Update(Guid id, CouponAddModel model)
        {
            var coupon = _dbContext.Coupons.FirstOrDefault(f => f.Id == id);
            if (coupon == null) throw new AppException("Invalid id");

            coupon.FromDate = model.FromDate;
            coupon.ToDate = model.ToDate;
            coupon.Limit = model.Limit;
            coupon.Maximum = model.Maximum;
            coupon.Minium = model.Minium;
            coupon.Discount = model.Discount;
            coupon.Default = model.Default;
            coupon.Description = model.Description;
            coupon.DateUpdated = DateTime.UtcNow.AddHours(7);

            _dbContext.Update(coupon);
            _dbContext.SaveChanges();

            return coupon.Id;
        }
        public Guid Delete(Guid id)
        {
            var coupon = _dbContext.Coupons.FirstOrDefault(f => f.Id == id);
            if (coupon == null) throw new AppException("Invalid id");

            coupon.IsDeleted = true;
            coupon.DateUpdated = DateTime.UtcNow.AddHours(7);

            _dbContext.Update(coupon);
            _dbContext.SaveChanges();

            return coupon.Id;
        }
        public double CheckCoupon(string coupon, double total)
        {
            var current = _dbContext.Coupons.FirstOrDefault(f => f.Description == coupon);
            if (current == null) throw new AppException("Invalid coupon");

            if (current.IsDeleted) throw new AppException("Coupon out of date");

            if (current.FromDate >= DateTime.UtcNow.AddHours(7)) throw new AppException("Coupon out of date");
            if (current.ToDate <= DateTime.UtcNow.AddHours(7)) throw new AppException("Coupon out of date");

            if (current.Limit != null && current.Limit == 0) throw new AppException("Coupon out of date");

            var result = total;

            if (current.Discount != null)
            {
                result = (total * current.Discount.Value) / 100;
            }
            else if (current.Maximum != null)
            {
                result = current.Maximum.Value;
            }

            if (current.Maximum != null && result > current.Maximum)
            {
                result = current.Maximum.Value;
            }
            if (current.Minium != null && result < current.Maximum)
            {
                result = current.Minium.Value;
            }
            return result;
        }
        public double UseCoupon(string coupon, double total)
        {
            var current = _dbContext.Coupons.FirstOrDefault(f => f.Description == coupon);
            if (current == null) throw new AppException("Invalid coupon");

            var result = CheckCoupon(coupon, total);

            if (current.Limit != null) current.Limit--;

            _dbContext.Update(current);
            _dbContext.SaveChanges();

            return result;
        }
    }
}
