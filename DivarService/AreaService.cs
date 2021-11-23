using DivarModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DivarService
{
    public class AreaService
    {
        private readonly DivarData.Divar_Data _data;

        public AreaService()
        {
            _data = new DivarData.Divar_Data();
        }
        public bool Add(Area ar)
        {
            return _data.AreaRepo.Add(ar);
        }

        public bool Delete(int id)
        {
            return _data.AreaRepo.Delete(id);
        }

        public bool Edit(int id, Area ar)
        {
            return _data.AreaRepo.Edit(id,ar);
        }

        public List<Area> GetAll()
        {
            
            return _data.AreaRepo.GetAll();
        }

        public List<Area> GetByCity(int cityId)
        {
            return _data.AreaRepo.GetByCity(cityId);
        }

        public Area GetById(int id)
        {
            return _data.AreaRepo.GetById(id);
        }
        public Area GetByAreaCheckCity(int areaId, int cityId)
        {
            return _data.AreaRepo.GetByAreaCheckCity(areaId, cityId);
        }
    }
}
