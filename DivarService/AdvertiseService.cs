using DivarData;
using DivarModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DivarService
{
    public class AdvertiseService
    {
        private readonly Divar_Data _data;

        public AdvertiseService()
        {
            _data = new Divar_Data();
        }
        public bool Add(Advertise adv)
        {
            return _data.AdvertiseRepo.Add(adv);
        }

        public bool Delete(int id)
        {
            return _data.AdvertiseRepo.Delete(id);
        }

        public bool Edit(int id, Advertise adv)
        {
            return _data.AdvertiseRepo.Edit(id, adv);
        }

        public List<Advertise> GetAll()
        {
            return _data.AdvertiseRepo.GetAll();
        }
    }
}
