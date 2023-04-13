using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
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
        public IResult RulesForAdding(Rentals entity)
        {
            var result = BusinessRules.Run(
                CheckIfThisCarIsAlreadyRentedInSelectedDateRange(entity),
                CheckIfReturnDateIsBeforeRentDate(entity.ReturnDate, entity.RentDate)
                );
            if (result != null)
            {
                return result;
            }


            return new SuccessResult("Ödeme Sayfasına Yönlendiriliyorsunuz.");

        }
        private IResult CheckIfThisCarIsAlreadyRentedInSelectedDateRange(Rentals entity)
        {
            var result = _rentals.Get(r =>
            r.CarId == entity.CarId
            && (r.RentDate.Date == entity.RentDate.Date
            || (r.RentDate.Date < entity.RentDate.Date
            && (r.ReturnDate == null
            || ((DateTime)r.ReturnDate).Date > entity.RentDate.Date))));

            if (result != null)
            {
                return new ErrorResult(Messages.ThisCarIsAlreadyRentedInSelectedDateRange);
            }
            return new SuccessResult();
        }

        private IResult CheckIfThisCarHasBeenReturned(Rentals entity)
        {
            var result = _rentals.Get(r => r.CarId == entity.CarId && r.ReturnDate == null);

            if (result != null)
            {
                if (entity.ReturnDate == null || entity.ReturnDate > result.RentDate)
                {
                    return new ErrorResult(Messages.ThisCarIsAlreadyRentedInSelectedDateRange);
                }
            }
            return new SuccessResult();
        }
        private IResult CheckIfReturnDateIsBeforeRentDate(DateTime? returnDate, DateTime rentDate)
        {
            if (returnDate != null)
                if (returnDate < rentDate)
                {
                    return new ErrorResult(Messages.ThisCarIsAlreadyRentedInSelectedDateRange);
                }
            return new SuccessResult();
        }
    }
}
