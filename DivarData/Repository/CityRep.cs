using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DivarModel;

namespace DivarData
{
    public class CityRep : IRepoCity
    {
        private List<City> Cityes = new List<City>();
        public bool Add(City ct)
        {
            bool flag = false;
            if(ct != null)
            {
                if(Cityes.Count == 0)
                {
                    ct.Id = 1;
                }
                else
                {
                    ct.Id = Cityes.Last().Id + 1;
                }
                
                Cityes.Add(ct);
                flag = true;
            }
            return flag;
        }

        public bool Delete(int id)
        {
            if(id > 0)
            {
                var found = Cityes.Where(x => x.Id.Equals(id)).SingleOrDefault();
                if (found != null)
                {
                    if (found.IsVisuble == Enums.IsVisuble.Show)
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
            }
            return false;
        }

        public bool Edit(int id, City ct)
        {
            if(id > 0 && ct != null)
            {
                var found = Cityes.Where(x => x.Id.Equals(id) && x.IsVisuble == Enums.IsVisuble.Show).SingleOrDefault();
                if(found != null)
                {
                    found.CityName = ct.CityName;
                    found.IsVisuble = ct.IsVisuble;
                    return true;
                }
                return false;
            }
            return false;
        }

        public List<City> GetAll()
        {
            return Cityes.Where(x => x.IsVisuble == Enums.IsVisuble.Show).ToList();
        }

        public City GetById(int id)
        {
            return Cityes.Where(x => x.IsVisuble == Enums.IsVisuble.Show && x.Id.Equals(id)).SingleOrDefault();
        }
    }
}
