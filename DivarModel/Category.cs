using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DivarModel
{
    public class Category
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public DateTime AddTime { get; set; }
        public Enums.IsVisuble IsVisuble { get; set; }
    }
}
