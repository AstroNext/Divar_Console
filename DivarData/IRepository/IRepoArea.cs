using DivarModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DivarData
{
    public interface IRepoArea
    {
        bool Add(Area ar);
        bool Edit(int id, Area ar);
        bool Delete(int id);
        List<Area> GetAll();
        Area GetById(int id);
        List<Area> GetByCity(int cityId);
        Area GetByAreaCheckCity(int areaId , int cityId);
        
    }
}
