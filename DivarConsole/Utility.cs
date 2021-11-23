using DivarModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DivarConsole
{
    public class Utility
    {
        private DivarService.AdvertiseService _advService { get; set; } = new DivarService.AdvertiseService();
        private DivarService.AreaService _areaService { get; set; } = new DivarService.AreaService();
        private DivarService.CategoryService _catService { get; set; } = new DivarService.CategoryService();
        private DivarService.CityService _cityService { get; set; } = new DivarService.CityService();
        private DivarService.LogService _logService { get; set; } = new DivarService.LogService();

        public string GetValueString(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\n"+msg);
            string retValue = Console.ReadLine();
            Console.ResetColor();
            return retValue;
        }
        public ConsoleKeyInfo Getkey(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\n" + msg);
            var retValue = Console.ReadKey();
            Console.ResetColor();
            return retValue;
        }
        public int GetValueInt(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\n"+msg);
            int retValue = 0;
            try
            {
                retValue = int.Parse(Console.ReadLine());
            }
            catch (Exception ext)
            {
                Console.Clear();
                ShowMessage(ext.Message + "\nPlease Enter Number !\n\nPress Any key To Go First Menu . . .", EnumsList.messageType.error);
                retValue = 909;
            }
            Console.ResetColor();
            return retValue;
        }
        public void ShowMessage(string msg , EnumsList.messageType type)
        {
            switch (type)
            {
                case EnumsList.messageType.success:
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(msg);
                    Console.ResetColor();
                    break;
                case EnumsList.messageType.error:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(msg);
                    Console.ResetColor();
                    break;
                case EnumsList.messageType.info:
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine(msg);
                    Console.ResetColor();
                    break;
            }
            Console.ReadKey();
        }
        public void ShowHeader(string title , string header)
        {
            Console.Clear();
            if(title != null)
            {
                Console.Title = title;
            }
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine($"===== {header} ===== \n");
            Console.ResetColor();
        }

        public void ShowAds(List<Advertise> advList , List<Category> catList , List<Area> areaList , List<City> cityList)
        {
            foreach (var item in advList)
            {
                var ar = areaList.Where(x => x.Id == item.Area_Id).SingleOrDefault();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"------( {item.Id} )------");
                Console.ResetColor();
                Console.WriteLine($"City : {cityList.Where(x => x.Id == ar.City_Id).SingleOrDefault().CityName}");
                Console.WriteLine($"Area : {ar.AreaName}");
                Console.WriteLine($"-------------------------");
                Console.WriteLine($"Category : {catList.Where(x => x.Id == item.Catgory_Id).SingleOrDefault().CategoryName}");
                Console.WriteLine($"Subject : {item.Subject}");
                Console.WriteLine($"Price : {item.Price}");
                Console.WriteLine($"Information : {item.Information}");
                Console.WriteLine($"Published Time : {DateTime.Now - item.AddTime}");
            }
        }
        public void ShowAllArea(List<Area> areaList, List<City> cityList,EnumsList.ShowType showType)
        {
            switch (showType)
            {
                case EnumsList.ShowType.admin:
                    if (cityList != null)
                    {
                        foreach (var item in areaList)
                        {
                            Console.WriteLine($"({item.Id}) : {cityList.Where(x => x.Id == item.City_Id).SingleOrDefault().CityName}.{item.AreaName} | {item.AddTime}");
                        }
                    }
                    else
                    {
                        foreach (var item in areaList)
                        {
                            Console.WriteLine($"({item.Id}) : {item.AreaName} | {item.AddTime}");
                        }
                    }
                    break;
                case EnumsList.ShowType.user:
                    if (cityList != null)
                    {
                        foreach (var item in areaList)
                        {
                            Console.WriteLine($"({item.Id}) : {cityList.Where(x => x.Id == item.City_Id).SingleOrDefault().CityName}.{item.AreaName}");
                        }
                    }
                    else
                    {
                        foreach (var item in areaList)
                        {
                            Console.WriteLine($"({item.Id}) : {item.AreaName}");
                        }
                    }
                    break;
                default:
                    break;
            }
            
            
        }
        public void ShowCitys(List<City> cityList,EnumsList.ShowType showType)
        {
            switch (showType)
            {
                case EnumsList.ShowType.admin:
                    foreach (var item in cityList)
                    {
                        Console.WriteLine($"({item.Id}) : {item.CityName} | {item.Add}");
                    }
                    break;
                case EnumsList.ShowType.user:
                    foreach (var item in cityList)
                    {
                        Console.WriteLine($"({item.Id}) : {item.CityName}");
                    }
                    break;
                default:
                    break;
            }
            
        }
        public void ShowCategory(List<Category> catList,EnumsList.ShowType showType)
        {
            switch (showType)
            {
                case EnumsList.ShowType.admin:
                    foreach (var item in catList)
                    {
                        Console.WriteLine($"({item.Id}) : {item.CategoryName} | {item.AddTime}");
                    }
                    break;
                case EnumsList.ShowType.user:
                    foreach (var item in catList)
                    {
                        Console.WriteLine($"({item.Id}) : {item.CategoryName}");
                    }
                    break;
                default:
                    break;
            }
            
        }
        public void ShowLogs(List<Log> loges)
        {
            ShowHeader("All Loges","All Loges Count");
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.WriteLine($"Errors Count : {loges.Where(x => x.Type == Enums.LogType.error).Count()}");
            Console.ResetColor();
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine($"Adds Count : {loges.Where(x => x.Type == Enums.LogType.add).Count()}");
            Console.ResetColor();
            Console.BackgroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine($"Show Count : {loges.Where(x => x.Type == Enums.LogType.show).Count()}");
            Console.ResetColor();
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine($"Edit Count : {loges.Where(x => x.Type == Enums.LogType.edit).Count()}");
            Console.ResetColor();
            Console.BackgroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine($"Delete Count : {loges.Where(x => x.Type == Enums.LogType.delete).Count()}");
            Console.ResetColor();
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.WriteLine($"search Count : {loges.Where(x => x.Type == Enums.LogType.search).Count()} \n");
            Console.ResetColor();

            ShowHeader(null,"All Records");

            foreach (var item in loges.OrderBy(x => x.Type))
            {
                Console.WriteLine();
                switch (item.Type)
                {
                    case Enums.LogType.error:
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.Write($"Location : {item.LogLocation} | Message : {item.LogMessage} | Time : {item.time}");
                        Console.ResetColor();
                        break;
                    case Enums.LogType.add:
                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                        Console.Write($"Location : {item.LogLocation} | Message : {item.LogMessage} | Time : {item.time}");
                        Console.ResetColor();
                        break;
                    case Enums.LogType.show:
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.Write($"Location : {item.LogLocation} | Message : {item.LogMessage} | Time : {item.time}");
                        Console.ResetColor();
                        break;
                    case Enums.LogType.edit:
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.Write($"Location : {item.LogLocation} | Message : {item.LogMessage} | Time : {item.time}");
                        Console.ResetColor();
                        break;
                    case Enums.LogType.delete:
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        Console.Write($"Location : {item.LogLocation} | Message : {item.LogMessage} | Time : {item.time}");
                        Console.ResetColor();
                        break;
                    case Enums.LogType.search:
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.Write($"Location : {item.LogLocation} | Message : {item.LogMessage} | Time : {item.time} ");
                        Console.ResetColor();
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
