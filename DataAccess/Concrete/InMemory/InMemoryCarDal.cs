using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal:ICarDal
    {
        List<Car> _car;
        public InMemoryCarDal()
        {
            _car = new List<Car> {
                new Car{Id=1,BrandId=1,ColorId=1,DailyPrice=1000,Description="BMW 520d",ModelYear=2012},
                new Car{Id=2,BrandId=1,ColorId=3,DailyPrice=2500,Description="BMW 520i",ModelYear=2016},
                new Car{Id=3,BrandId=2,ColorId=2,DailyPrice=1500,Description="Honda Civic",ModelYear=2017},
                new Car{Id=4,BrandId=3,ColorId=1,DailyPrice=3000,Description="Audi A3",ModelYear=2022},
                new Car{Id=5,BrandId=3,ColorId=2,DailyPrice=2000,Description="Audi A6",ModelYear=2016},
                new Car{Id=6,BrandId=4,ColorId=3,DailyPrice=5000,Description="Bugatti Chiron",ModelYear=2022}

            };

        }
        public void Add(Car car)
        {
            _car.Add(car);
        }
        public void Delete(Car car)
        {
            Car carToDelete = _car.SingleOrDefault(c => c.Id == car.Id);

            _car.Remove(carToDelete);
        }
        public List<Car> GetAll()
        {
            return _car;
        }
        public void Update(Car car)
        {
            Car carToUpate = _car.SingleOrDefault(c => c.BrandId == car.BrandId);
            carToUpate.BrandId = car.BrandId;
            carToUpate.ColorId = car.ColorId;
            carToUpate.DailyPrice = car.DailyPrice;
            carToUpate.Description = car.Description;
            carToUpate.ModelYear = car.ModelYear;
            
        }
        public List<Car> GetByld(int brandId)
        {
            return _car.Where(c => c.BrandId == brandId).ToList();
        }

    }
}
