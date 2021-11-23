using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DivarModel;

namespace DivarData
{
    public class LogRepo : IRepoLog
    {
        private List<Log> Loges = new List<Log>();
        public bool Add(Log lo)
        {
            bool flag = false;
            if(lo != null)
            {
                if(Loges.Count == 0)
                {
                    lo.Id = 1;
                }
                else
                {
                    lo.Id = Loges.Last().Id + 1;
                }
                Loges.Add(lo);
                flag = true;
            }
            return flag;
        }

        public List<Log> GetAll()
        {
            return Loges;
        }
    }
}
