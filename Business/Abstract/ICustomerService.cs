using Core2.Utilities.Results.DataResults;
using Core2.Utilities.Results.Results;
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
        IResult Add(Customer customer);
        IResult Update(Customer customer);
        IResult Delete(Customer customer);

        IDataResult<List<Customer>> GetCustomerById(int id);

        IDataResult<List<Customer>> GetAll();
        IDataResult<List<Customer>> GetCustomerByName(string name);



    }
}
