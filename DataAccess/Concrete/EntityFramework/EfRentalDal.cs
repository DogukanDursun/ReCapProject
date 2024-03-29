﻿using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rentals, CarsContext>, IRentalsDal
    {

        public List<RentalDetailDto> GetRentalDetails()
        {
            using (CarsContext context = new CarsContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands
                             on c.BrandId equals b.Id
                             join r in context.Rentals
                             on c.Id equals r.CarId
                             join color in context.Colors
                             on c.ColorId equals color.ColorId
                             join cust in context.Customers
                             on r.CustomerId equals cust.Id
                             join user in context.Users
                             on cust.UserId equals user.Id

                             select new RentalDetailDto
                             {
                                 RentalId = r.Id,
                                 BrandId = b.Id,
                                 CarId = c.Id,
                                 ColorId = color.ColorId,
                                 ColorName = color.ColorName,
                                 BrandName = b.BrandName,
                                 ModelName = c.Model,
                                 UserName = user.FirstName + " " + user.LastName,
                                 RentDate = r.RentDate,
                                 ReturnDate = r.ReturnDate
                             };
                return result.ToList();
            }
        }
    }
}