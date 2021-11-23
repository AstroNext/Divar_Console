using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DivarModel;

namespace DivarData
{
    public class AdvertiseRep : IRepoAdvertise
    {
        List<Advertise> Advertises = new List<Advertise>();
        public bool Add(Advertise adv)
        {
            bool flag = false;
            if(adv != null)
            {
                if (Advertises.Count == 0)
                {
                    adv.Id = 1;
                }
                else
                {
                    adv.Id = Advertises.Last().Id + 1;
                }

                Advertises.Add(adv);
                flag = true;
            }
            
            return flag;
        }

        public bool Delete(int id)
        {
            if(id != 0)
            {
                var found = Advertises.Where(x => x.Id == id).SingleOrDefault();
                if(found.IsVisuble == Enums.IsVisuble.Show)
                {
                    found.IsVisuble = Enums.IsVisuble.Delete;
                    return true;
                }
                else
                {
                    found.IsVisuble = Enums.IsVisuble.Show;
                    return true;
                }
                
            }
            return false;
        }

        public bool Edit(int id, Advertise adv)
        {
            if(id > 0 && adv != null)
            {
                var found = Advertises.Where(x => x.Id.Equals(id) && x.IsVisuble == Enums.IsVisuble.Show).SingleOrDefault();

                if(found != null)
                {
                    found.Information = adv.Information;
                    found.IsVisuble = adv.IsVisuble;
                    found.Price = adv.Price;
                    found.Subject = adv.Subject;
                    found.Area_Id = adv.Area_Id;
                    found.Catgory_Id = adv.Catgory_Id;
                    found.AdvType = adv.AdvType;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }

        public List<Advertise> GetAll()
        {
            return Advertises.Where(x => x.IsVisuble == Enums.IsVisuble.Show).ToList();
        }
    }
}
