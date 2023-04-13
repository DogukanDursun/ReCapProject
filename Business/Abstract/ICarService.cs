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
        
        IResult Update(Car entity);
        IResult Delete(Car entity);
        IResult Add ( Car entity );
        IDataResult<List<CarDetailDTO>> GetCarDetailsById(int id);
        IDataResult<List<CarDetailDTO>> GetCarDetailsByColor(int colorId);
        IDataResult<List<CarDetailDTO>> GetByCarDetailId(int Id);
        IDataResult<List<CarDetailDTO>> GetCarDetailsByColorAndBrand(int brandId, int colorId);
        IDataResult<List<Car>> GetAll();
        IDataResult<List<CarDetailDTO>> GetCarsByBrandId(int id);
        IDataResult<List<Car>> GetCarsByColorId(int id);
        IDataResult<List<CarDetailDTO>> GetCarDetails();
    }
}
