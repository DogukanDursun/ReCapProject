using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        IDataResult<List<CarDetailDTO>> GetCarDetailsByColor(int colorId);
        IDataResult<List<Car>> GetAll();
        IDataResult<List<CarDetailDTO>> GetCarsByBrandId(int id);
        IDataResult<List<Car>> GetCarsByColorId(int id);
        IDataResult<List<CarDetailDTO>> GetCarDetails();
    }
}
