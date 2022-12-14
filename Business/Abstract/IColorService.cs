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
    public interface IColorService
    {

        IResult Add(Color color);
        IResult Update(Color color);
        IResult Delete(Color color);

        IDataResult<List<Color>> GetColorById(int id);
        IDataResult<List<Color>> GetColorByName(string name);

    }
}
