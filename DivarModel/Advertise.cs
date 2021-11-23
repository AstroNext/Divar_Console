using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DivarModel
{
    public class Advertise
    {
        public int Id { get; set; }
        public int Catgory_Id { get; set; }
        public int Area_Id { get; set; }
        public decimal Price { get; set; }
        public Enums.AdvertizeType AdvType { get; set; }
        public string Subject { get; set; }
        public string Information { get; set; }
        public Enums.IsVisuble IsVisuble { get; set; }
        public DateTime AddTime { get; set; }
    }
}
