using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DivarConsole
{
    public class EnumsList
    {
        public enum messageType
        {
            success,
            error,
            info
        }
        public enum Menus
        {
            showAll = 1 ,
            addNewAdv = 2,
            search = 3,
            myAdvertise = 4,
            admin = 5
        }
        public enum AdminMenu
        {
            addcat,
            addcity,
            addarea,
            showalladv,
            showallcity,
            showallarea,
                
        }
        public enum ShowType
        {
            admin,
            user
        }

    }
}
