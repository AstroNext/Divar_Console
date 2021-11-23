using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DivarModel
{
    public class Area
    {
        public int Id { get; set; }
        public int City_Id { get; set; }
        public string AreaName { get; set; }
        public DateTime AddTime { get; set; }
        public Enums.IsVisuble IsVisuble { get; set; }
    }
}
