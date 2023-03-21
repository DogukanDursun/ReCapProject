using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class RentalsManager : IRentalsService
    {
        IRentalsDal _rentals;
        public RentalsManager(IRentalsDal rentals)
        {
            _rentals = rentals;
        }

        public IResult Add(Rentals rentals)
        {
            if (!(rentals.ReturnDate == null))
            {
                return new ErrorResult(Messages.RentalNotAdded);
            }
            else
            {
                _rentals.Add(rentals);
                return new SuccessResult(Messages.RentalAdded);

            }
        }

        public IResult Delete(Rentals rentals)
        {
            _rentals.Delete(rentals);
            return new SuccessResult(Messages.RentalDeleted);
        }

        public IDataResult<List<Rentals>> GetAll()
        {
            return new SuccessDataResult<List<Rentals>>(_rentals.GetAll());
        }

        public IDataResult<Rentals> GetByCarId(int carId)
        {
            return new SuccessDataResult<Rentals>(_rentals.Get(r => r.CarId == carId));
        }

       

        public IDataResult<Rentals> GetByRentalId(int rentalId)
        {
            return new SuccessDataResult<Rentals>(_rentals.Get(r => r.Id == rentalId));
        }

        public IDataResult<List<Rentals>> GetRentalByCarId(int CarId)
        {
            return new SuccessDataResult<List<Rentals>>(_rentals.GetAll(r => r.CarId == CarId));
        }

        public IDataResult<List<RentalDetailDto>> GetRentalDetails()
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentals.GetRentalDetails());
        }

        public IResult Update(Rentals rentals)
        {
            _rentals.Update(rentals);
            return new SuccessResult(Messages.RentalUpdated);
        }
    }
}
