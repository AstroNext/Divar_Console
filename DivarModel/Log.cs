using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DivarModel
{
    public class Log
    {
        public int Id { get; set; }
        public string LogMessage { get; set; }
        public string LogLocation { get; set; }
        public Enums.LogType Type { get; set; }
        public DateTime time { get; set; }
    }
}
