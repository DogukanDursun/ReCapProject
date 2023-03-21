using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICustomerService
    {
        IResult Add(Customers customer);
        IResult Delete(Customers customer);
        IResult Update(Customers customer);
        IDataResult<List<Customers>> GetAll();
        IDataResult<Customers> GetByCustomerId(int customerId);
    }
}
