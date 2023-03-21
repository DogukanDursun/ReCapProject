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
    public class EfCarDal : EfEntityRepositoryBase<Car, CarsContext>, ICarDal
    {
        public List<CarDetailDTO> GetCarDetails()
        {
            using (CarsContext context = new CarsContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands
                             on c.BrandId equals b.Id
                             join co in context.Colors
                             on c.ColorId equals co.ColorId
                             select new CarDetailDTO 
                             {
                                 Id=c.Id,
                                 BrandId=b.Id,
                                 ColorId=co.ColorId,
                                 BrandName=b.BrandName,
                                 ColorName=co.ColorName,
                                 Description=c.Description,
                                 DailyPrice=c.DailyPrice
                             };
                return result.ToList();
            }
        }
        //public List<CarDetailDTO> GetCarDetailss()
        //{
        //    using (CarsContext context = new CarsContext())
        //    {
        //        var result = from car in context.Cars
        //                     join brand in context.Brands
        //                         on car.BrandId equals brand.Id
        //                     join color in context.Colors
        //                         on car.ColorId equals color.ColorId

        //                     select new CarDetailDTO
        //                     {
        //                         Id = car.Id,
        //                         BrandId = brand.Id,
        //                         ColorId = color.ColorId,

        //                         Description = car.Description,
        //                         BrandName = brand.BrandName,
        //                         ColorName = color.ColorName,

        //                         ModelYear = car.ModelYear,
        //                         DailyPrice = car.DailyPrice,
                           
                                
        //                     };
        //        return result.ToList();
        //    }
        
        }
    }




