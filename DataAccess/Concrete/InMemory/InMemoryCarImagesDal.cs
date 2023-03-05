using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarImagesDal : ICarImagesDal
    {
        public void Add(CarImages entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(CarImages entity)
        {
            throw new NotImplementedException();
        }

        public CarImages Get(Expression<Func<CarImages, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<CarImages> GetAll(Expression<Func<CarImages, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public void Update(CarImages entity)
        {
            throw new NotImplementedException();
        }
    }
}
