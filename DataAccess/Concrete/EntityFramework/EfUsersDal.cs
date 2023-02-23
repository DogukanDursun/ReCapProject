using Core.DataAccess.EntityFramework;
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
    public class EfUsersDal : EfEntityRepositoryBase<Users, CarsContext>, IUsersDal
    {
        public List<UsersDetailDTO> GetUsersDetails()
        {
            using (CarsContext context = new CarsContext())
            {
                var result = from u in context.Users
                             join cu in context.Customers on u.Id equals cu.UserId

                             select new UsersDetailDTO
                             {

                                 Id = u.Id,
                                 UserId =cu.UserId,
                             };
                return result.ToList();
            }
        }
    }


}

