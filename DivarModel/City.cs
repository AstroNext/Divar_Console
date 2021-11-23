using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DivarModel
{
    public class City
    {
        public int Id { get; set; }
        public string CityName { get; set; }
        public DateTime Add { get; set; }
        public Enums.IsVisuble IsVisuble { get; set; }
    }
}
