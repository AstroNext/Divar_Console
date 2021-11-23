using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DivarModel;

namespace DivarData
{
    public class AreaRepo : IRepoArea
    {
        private List<Area> Areaes = new List<Area>();
        public bool Add(Area ar)
        {
            bool flag = false;
            if (ar != null)
            {
                if (Areaes.Count == 0)
                {
                    ar.Id = 1;
                }
                else
                {
                    ar.Id = Areaes.Last().Id + 1;
                }
            
                Areaes.Add(ar);
                flag = true;
            }
            return flag;
        }

        public bool Delete(int id)
        {
            if(id > 0 && id < ++Areaes.Last().Id)
            {
                var found = Areaes.Where(x => x.Id.Equals(id)).SingleOrDefault();

                if(found != null)
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
                return false;
            }
            return false;
        }

        public bool Edit(int id, Area ar)
        {
            if (id > 0 && id < ++Areaes.Last().Id && ar != null)
            {
                var found = Areaes.Where(x => x.Id.Equals(id)).SingleOrDefault();

                if (found != null)
                {
                    found.AreaName = ar.AreaName;
                    found.City_Id = ar.City_Id;
                    return true;
                }
                return false;
            }
            return false;
        }

        public List<Area> GetAll()
        {
            return Areaes.Where(x => x.IsVisuble == Enums.IsVisuble.Show).ToList();
         
        }

        public Area GetByAreaCheckCity(int areaId, int cityId)
        {
            Area ar = null;
            if (areaId > 0 && cityId > 0)
            {
                var found = Areaes.Where(x => x.Id.Equals(areaId) && x.City_Id.Equals(cityId)).SingleOrDefault();

                if (found != null)
                {
                    ar = found;
                }
            }
            return ar;
        }

        public List<Area> GetByCity(int cityId)
        {
            if (cityId > 0)
            {
                var found = Areaes.Where(x => x.City_Id.Equals(cityId)).ToList();

                if (found != null)
                {
                    return found;
                }
                return null;
            }
            return null;
        }

        public Area GetById(int id)
        {
            Area ar = null;
            if (id > 0)
            {
                var found = Areaes.Where(x => x.Id.Equals(id)).SingleOrDefault();

                if (found != null)
                {
                    ar = found;
                }
            }
            return ar;
        }
    }
}
