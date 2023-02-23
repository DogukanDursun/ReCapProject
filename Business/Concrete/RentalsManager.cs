using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
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
            throw new NotImplementedException();
        }

        public IDataResult<Rentals> GetById(int rentalsId)
        {
            throw new NotImplementedException();
        }

        public IResult Update(Rentals rentals)
        {
            _rentals.Update(rentals);
            return new SuccessResult(Messages.RentalUpdated);
        }
    }
}
