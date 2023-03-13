using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Helpers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class CarImageManager : ICarImagesService
    {
        ICarImagesDal _carImagesDal;

        public CarImageManager(ICarImagesDal carImagesDal)
        {
            _carImagesDal = carImagesDal;
            
        }
        [SecuredOperation("product.add,admin")]
        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(IFormFile file, CarImages carImage)
        {
            IResult result = BusinessRules.Run(CheckIfImageLimitExceeded(carImage.CarId));
            if (result != null)
            {
                return result;
            }
            carImage.ImagePath = FileHelper.Add(file);
            carImage.Date = DateTime.Now;
            _carImagesDal.Add(carImage);
            return new SuccessResult(Messages.CarImagesAdded);
        }

        public IResult Delete(CarImages carImage)
        {
            IResult result = BusinessRules.Run(CarImagesDelete(carImage));
            if (result != null)
            {
                return result;
            }
            _carImagesDal.Delete(carImage);
            return new SuccessResult();
        }

        public IDataResult<List<CarImages>> GetAll()
        {
            return new SuccessDataResult<List<CarImages>>(_carImagesDal.GetAll());
        }

        public IDataResult<List<CarImages>> GetByCarId(int carId)
        {
            return new SuccessDataResult<List<CarImages>>(_carImagesDal.GetAll(c => c.CarId == carId));
        }

        public IDataResult<CarImages> GetByImageId(int id)
        {
            throw new NotImplementedException();
        }

        public IResult Update(IFormFile file, CarImages carImages)
        {
            IResult result = BusinessRules.Run(CheckIfImageLimitExceeded(carImages.CarId));
            if (result != null)
            {
                return result;
            }
            
          carImages.Date = DateTime.Now;
            string oldPath = GetByImageId(carImages.Id).Data.ImagePath;
            carImages.ImagePath = FileHelper.Update(oldPath, file);
            return new SuccessResult();
        }
        private IResult CheckIfImageLimitExceeded(int carId)
        {
            var carImageCount = _carImagesDal.GetAll(c => c.CarId == carId).Count;
            if (carImageCount >5)
            {
                return new ErrorResult();
            }
            return new SuccessResult();
        }
        private IResult CarImagesDelete(CarImages carImage)
        {
            try
            {
                File.Delete(carImage.ImagePath);
            }
            catch (Exception exception)
            {

                return new ErrorResult(exception.Message);
            }

            return new SuccessResult();
        }
        private List<CarImages> CheckIfCarImageNull(int carId)
        {
            string path = @"DefaultLogo.png";
            var result = _carImagesDal.GetAll(c => c.CarId == carId).Any();
            if (!result)
            {
                return new List<CarImages> { new CarImages { CarId = carId, ImagePath = path, Date = DateTime.Now } };
            }
            return _carImagesDal.GetAll(c => c.CarId == carId);
        }
    }
}
