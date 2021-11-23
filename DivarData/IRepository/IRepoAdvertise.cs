using DivarModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DivarData
{
    public interface IRepoAdvertise
    {
        bool Add(Advertise adv);
        List<Advertise> GetAll();
        bool Delete(int id);
        bool Edit(int id, Advertise adv);
    }
}
