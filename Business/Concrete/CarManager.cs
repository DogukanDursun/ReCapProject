using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }
        [SecuredOperation("product.add,admin")]
        [ValidationAspect(typeof(CarValidator))]
      
        public IResult Add(Car car)
        {
            IResult result = BusinessRules.Run(CheckIfProductCountOfCategoryCorrect(car.BrandId),
                              CheckIfProductNameExists(car.Description));

            if (result != null)
            {
                return result;
            }

            _carDal.Add(car);

            return new SuccessResult(Messages.CarAdded);


        }
        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("IProductService.Get")]
        public IResult Update(Car car)
        {

            _carDal.Update(car);
            return new SuccessResult(Messages.CarUpdated);


        }
        public  List<Car> GetByDailyPrice(decimal min, decimal max)
        {
            return _carDal.GetAll(c => c.DailyPrice >= min && c.DailyPrice <= max);
        }
        public IDataResult <List<Car>> GetAll()
        {
            if (DateTime.Now.Hour == 22)
            {
                return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);
            }
           
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.CarsListed);
        }
        public IDataResult <List<Car>> GetCarsByBrandId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.BrandId == id));
        }

        public IDataResult<List<Car>> GetCarsByColorId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ColorId == id));
        }

        public IDataResult<List<CarDetailDTO>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDTO>>(_carDal.GetCarDetails());
        }
        private IResult CheckIfProductCountOfCategoryCorrect(int categoryId)
        {
            var result = _carDal.GetAll(c => c.BrandId == categoryId).Count;
            if (result >= 100)
            {
                return new ErrorResult(Messages.CarCountOfCategoryError);
            }
            return new SuccessResult();
        }
        
      
        private IResult CheckIfProductNameExists(string productName)
        {
            var result = _carDal.GetAll(c => c.Description == productName).Any();
            if (result)
            {
                return new ErrorResult(Messages.CarNameAlreadyExists);
            }
            return new SuccessResult();
        }

        [TransactionScopeAspect]
        public IResult AddTransactional(Car product)
        {
            _carDal.Delete(product);
            return new SuccessResult(Messages.CarUpdated);
        }
    }
}
