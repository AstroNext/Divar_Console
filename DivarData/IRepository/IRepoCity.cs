using DivarModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DivarData
{
    public interface IRepoCity
    {
        bool Add(City ct);
        bool Delete(int id);
        bool Edit(int id, City ct);
        List<City> GetAll();
        City GetById(int id);
    }
}
