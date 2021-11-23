using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DivarData;
using DivarModel;

namespace DivarService
{
    public class CityService
    {
        private readonly Divar_Data _Data;

        public CityService()
        {
            _Data = new Divar_Data();
        }
        public bool Add(City ct)
        {
            return _Data.CityRepo.Add(ct);
        }

        public bool Delete(int id)
        {
            return _Data.CityRepo.Delete(id);
        }

        public bool Edit(int id, City ct)
        {
            return _Data.CityRepo.Edit(id, ct);
        }

        public List<City> GetAll()
        {
            return _Data.CityRepo.GetAll();
        }

        public City GetById(int id)
        {
            return _Data.CityRepo.GetById(id);
        }
    }
}
