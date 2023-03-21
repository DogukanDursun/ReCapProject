using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IRentalsService
    {
        IDataResult<List<Rentals>> GetRentalByCarId(int CarId);
  
        IDataResult<Rentals> GetByRentalId(int rentalId);
        IDataResult<Rentals> GetByCarId(int carId);

        IResult Add(Rentals rentals);
        IResult Update(Rentals rentals);
        IDataResult<List<RentalDetailDto>> GetRentalDetails();
        IResult Delete(Rentals rentals);
        IDataResult<List<Rentals>> GetAll();
      
    }
}
