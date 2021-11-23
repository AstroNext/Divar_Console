using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DivarData
{
    public class Divar_Data
    {
        public IRepoAdvertise AdvertiseRepo { get; set; } = new AdvertiseRep();
        public IRepoCategory CategoryRepo { get; set; } = new CategoryRep();
        public IRepoCity CityRepo { get; set; } = new CityRep();
        public IRepoArea AreaRepo { get; set; } = new AreaRepo();
        public IRepoLog LogRepo { get; set; } = new LogRepo();
    }
}
