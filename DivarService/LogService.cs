using DivarModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DivarService
{
    public class LogService
    {
        private readonly DivarData.Divar_Data _data;

        public LogService()
        {
            _data = new DivarData.Divar_Data();
        }
        public bool Add(Log lo)
        {
            return _data.LogRepo.Add(lo);
        }
        public List<Log> GetAll()
        {
            return _data.LogRepo.GetAll();
        }
    }
}
