using DivarModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DivarData
{
    public interface IRepoLog
    {
        bool Add(Log lo);
        List<Log> GetAll();
    }
}
