using DivarModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DivarConsole
{
    class Program
    {
        private static Utility _utility = new Utility();
        private static Menus _menus = new Menus();
        private static DivarService.AdvertiseService _advService { get; set; } = new DivarService.AdvertiseService();
        private static DivarService.AreaService _areaService { get; set; } = new DivarService.AreaService();
        private static DivarService.CategoryService _catService { get; set; } = new DivarService.CategoryService();
        private static DivarService.CityService _cityService { get; set; } = new DivarService.CityService();
        private static DivarService.LogService _logServ { get; set; } = new DivarService.LogService();
        static void Main(string[] args)
        {
            _menus.StartApp();
                
            City ct = new City()
            {
                CityName = "shiraz",
                IsVisuble = Enums.IsVisuble.Show,
                Add = DateTime.Now
            };
            var resAddCity = _cityService.Add(ct);
            Area ar = new Area()
            {
                City_Id = 1,
                AreaName = "marvdasht",
                AddTime = DateTime.Now,
                IsVisuble = Enums.IsVisuble.Show
            };
            var resAddArea = _areaService.Add(ar);
            Category cat = new Category()
            {
                IsVisuble = Enums.IsVisuble.Show,
                AddTime = DateTime.Now,
                CategoryName = "car"
            };
            var resAddCat = _catService.Add(cat);
            Advertise adv = new Advertise()
            {
                AdvType = Enums.AdvertizeType.Sell,
                AddTime = DateTime.Now,
                Area_Id = 1,
                Catgory_Id = 1,
                Information ="peride",
                IsVisuble = Enums.IsVisuble.Show,
                Price = 2500,
                Subject = "2500 karkard",
            };
            var resAdd = _advService.Add(adv);

            var Exit = true;
            startApp:
            while (Exit)
            {
                var userChoice = _menus.BaseMenu();
                switch (userChoice.Key)
                {
                    case ConsoleKey.NumPad1:
                        _utility.ShowHeader(null, "Show All Advertise");
                        if (_advService.GetAll().Count != 0)
                        {
                            _utility.ShowAds(_advService.GetAll(), _catService.GetAll(), _areaService.GetAll(), _cityService.GetAll());
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.WriteLine("Empty List Please Add Adveretise First");
                            Console.ReadKey();
                        }
                        goto startApp;
                    case ConsoleKey.NumPad2:
                        _utility.ShowHeader(null, "Add New Advertise");
                        AddNewAdv();
                        Console.ReadKey();
                        goto startApp;
                    case ConsoleKey.NumPad3:
                        _utility.ShowHeader(null, "Search");
                        Console.ReadKey();
                        goto startApp;
                    case ConsoleKey.NumPad4:
                        _utility.ShowHeader(null, "My Advertises");
                        Console.ReadKey();
                        goto startApp;
                    case ConsoleKey.F1:
                        var res = _menus.AdminLogin();
                        if (res)
                        {
                            while (true)
                            {
                                adminBack:
                                var adminChoice = _menus.AdminMenu();
                                switch (adminChoice.Key)
                                {
                                    case ConsoleKey.NumPad1:
                                        AddNewCat();
                                        goto adminBack;
                                    case ConsoleKey.NumPad2:
                                        AddNewCity();
                                        goto adminBack;
                                    case ConsoleKey.NumPad3:
                                        AddNewArea();
                                        goto adminBack;
                                    case ConsoleKey.NumPad4:
                                        _utility.ShowHeader(null, "Show All Category");
                                        if (_catService.GetAll().Count != 0)
                                        {
                                            _utility.ShowCategory(_catService.GetAll(),EnumsList.ShowType.admin);
                                            Console.ReadKey();
                                        }
                                        else
                                        {
                                            _utility.ShowMessage("Empty List Please Add Category First", EnumsList.messageType.error);
                                        }
                                        goto adminBack;
                                    case ConsoleKey.NumPad5:
                                        _utility.ShowHeader(null, "Show All City");
                                        if (_cityService.GetAll().Count != 0)
                                        {
                                            _utility.ShowCitys(_cityService.GetAll(),EnumsList.ShowType.admin);
                                            Console.ReadKey();
                                        }
                                        else
                                        {
                                            _utility.ShowMessage("Empty List Please Add City First", EnumsList.messageType.error);
                                        }
                                        goto adminBack;
                                    case ConsoleKey.NumPad6:
                                        _utility.ShowHeader(null, "Show All Area");
                                        if (_areaService.GetAll().Count != 0)
                                        {
                                            _utility.ShowAllArea(_areaService.GetAll(), _cityService.GetAll(),EnumsList.ShowType.admin);
                                            Console.ReadKey();
                                        }
                                        else
                                        {
                                            _utility.ShowMessage("Empty List Please Add Area First", EnumsList.messageType.error);
                                        }
                                        goto adminBack;
                                    case ConsoleKey.NumPad7:
                                        _utility.ShowHeader(null, "Show All Advertise");
                                        if (_advService.GetAll().Count != 0)
                                        {
                                            _utility.ShowAds(_advService.GetAll(), _catService.GetAll(), _areaService.GetAll(), _cityService.GetAll());
                                            Console.ReadKey();
                                        }
                                        else
                                        {
                                            _utility.ShowMessage("Empty List Please Add Advertise First", EnumsList.messageType.error);
                                        }
                                        goto adminBack;
                                    case ConsoleKey.Backspace:
                                        Console.Clear();
                                        goto startApp;
                                    default:
                                        _utility.ShowMessage("\nWrong choice", EnumsList.messageType.error);
                                        break;
                                }
                            }
                            
                        }
                        Console.ReadKey();
                        goto startApp;
                    case ConsoleKey.Escape:
                        Console.Clear();
                        _utility.ShowMessage("Thank you for using this app (press any key for close)", EnumsList.messageType.info);
                        Exit = false;
                        break;
                        default:
                        _utility.ShowMessage("\nWrong choice", EnumsList.messageType.error);
                        break;
                }
            }
        }

        private static void AddNewArea()
        {
            _utility.ShowHeader("Add New Area", "Select City");
            _utility.ShowCitys(_cityService.GetAll(), EnumsList.ShowType.user);
            var cityId = _utility.GetValueInt("Please Enter City Id : ");
            var cityFound = _cityService.GetAll().Where(x => x.Id == cityId).SingleOrDefault();
            if (cityFound == null)
            {
                _utility.ShowMessage("Please Enter City Id From Above List !", EnumsList.messageType.error);
                return;
            }
            _utility.ShowHeader("Add New Area", "Add Area");
            Console.WriteLine("----------------");
            Console.WriteLine($"City Name : {cityFound.CityName}");
            Console.WriteLine("----------------");
            var areaName = _utility.GetValueString("Enter Area Name :");
            if(string.IsNullOrEmpty(areaName))
            {
                _utility.ShowMessage("Please Enter Name of Area !", EnumsList.messageType.error);
                return;
            }
            Area ar = new Area()
            {
                AddTime = DateTime.Now,
                AreaName = areaName,
                City_Id = cityFound.Id,
                IsVisuble = Enums.IsVisuble.Show
            };
            _utility.ShowMessage("Press Any key for save area !", EnumsList.messageType.info);
            var result = _areaService.Add(ar);

            if (result)
            {
                _utility.ShowMessage("Save successfully !", EnumsList.messageType.success);
            }
            else
            {
                _utility.ShowMessage("Save not successfully !", EnumsList.messageType.error);
            }
        }

        private static void AddNewCity()
        {
            _utility.ShowHeader("Add New City", "Add City");
            var cityName = _utility.GetValueString("Enter City Name :");

            if (string.IsNullOrEmpty(cityName))
            {
                _utility.ShowMessage("Please Enter Name of City !", EnumsList.messageType.error);
                return;
            }

            City ct = new City()
            {
                Add = DateTime.Now,
                CityName = cityName,
                IsVisuble = Enums.IsVisuble.Show,
            };

            _utility.ShowMessage("Press Any key for save category !", EnumsList.messageType.info);

            var result = _cityService.Add(ct);

            if (result)
            {
                _utility.ShowMessage("Save successfully !", EnumsList.messageType.success);
            }
            else
            {
                _utility.ShowMessage("Save not successfully !", EnumsList.messageType.error);
            }
        }

        private static void AddNewCat()
        {
            _utility.ShowHeader("Add New Category", "Add Category");
            var catName = _utility.GetValueString("Enter Category Name :");

            if(string.IsNullOrEmpty(catName))
            {
                _utility.ShowMessage("Please Enter Name of Category !", EnumsList.messageType.error);
                return;
            }

            Category cat = new Category()
            {
                AddTime = DateTime.Now,
                CategoryName = catName,
                IsVisuble = Enums.IsVisuble.Show,
            };

            _utility.ShowMessage("Press Any key for save category !", EnumsList.messageType.info);

            var result = _catService.Add(cat);
            if (result)
            {
                _utility.ShowMessage("Save successfully !", EnumsList.messageType.success);
            }
            else
            {
                _utility.ShowMessage("Save not successfully !", EnumsList.messageType.error);
            }
        }

        public static void AddNewAdv()
        {
            _utility.ShowHeader("Add New Advertise", "Citys");
            _utility.ShowCitys(_cityService.GetAll(),EnumsList.ShowType.user);
            var cityId = _utility.GetValueInt("Please Enter City Id : ");
            var cityFound = _cityService.GetAll().Where(x => x.Id == cityId).SingleOrDefault();
            if(cityFound == null)
            {
                _utility.ShowMessage("Please Enter City Id From Above List !", EnumsList.messageType.error);
                return;
            }
            _utility.ShowHeader(null, "Areas");
            _utility.ShowAllArea(_areaService.GetByCity(cityId),null,EnumsList.ShowType.user);
            var areaId = _utility.GetValueInt("Please Enter Area Id : ");
            var areaFound = _areaService.GetById(areaId);
            if(!areaFound.City_Id.Equals(cityFound.Id) || areaFound == null)
            {
                _utility.ShowMessage("Please Enter Area Id From Above List !", EnumsList.messageType.error);
                return;
            }
            _utility.ShowHeader(null, "Category");
            _utility.ShowHeader("Add New Advertise", "Categorys");
            _utility.ShowCategory(_catService.GetAll(),EnumsList.ShowType.user);
            var catId = _utility.GetValueInt("Enter Category Id : ");
            var catFound = _catService.GetById(catId);
            if (catFound == null)
            {
                _utility.ShowMessage("Please Enter Category Id From Above List !", EnumsList.messageType.error);
                return;
            }
            _utility.ShowHeader(null, "Part 2");
            Console.WriteLine("--------------------");
            Console.WriteLine($"City : {cityFound.CityName}");
            Console.WriteLine($"Area : {areaFound.AreaName}");
            Console.WriteLine($"Category : {catFound.CategoryName}");
            Console.WriteLine("--------------------");
            var changeRes = decimal.TryParse(_utility.GetValueString("Enter Your Price : ") ,out decimal price);
            if(!changeRes)
            {
                _utility.ShowMessage("Wrong Input! (Prices Are Contains Numbers)", EnumsList.messageType.error);
                return;
            }
            var subj = _utility.GetValueString("Enter Advertise Subject : ");
            var info = _utility.GetValueString("Enter Advertise Infomation : ");
            Enums.AdvertizeType advType;

            var wantRes = _utility.GetValueString("For Sell Enter (s) For Request Enter (r)");
            if(wantRes.ToLower() == "s" )
            {
                advType = Enums.AdvertizeType.Sell;
            }
            else if(wantRes.ToLower() == "r")
            {
                advType = Enums.AdvertizeType.Need;
            }
            else
            {
                _utility.ShowMessage("Please Enter ( s / r) !", EnumsList.messageType.error);
                return;
            }

            Advertise adv = new Advertise()
            {
                AddTime = DateTime.Now,
                AdvType = advType,
                Area_Id = areaFound.Id,
                Catgory_Id = catFound.Id,
                Information = info,
                IsVisuble = Enums.IsVisuble.Show,
                Price = price,
                Subject = subj
            };

            _utility.ShowMessage("Press Any key for save advertise !", EnumsList.messageType.info);

            var result = _advService.Add(adv);
            if(result)
            {
                _utility.ShowMessage("Save successfully !", EnumsList.messageType.success);
            }
            else
            {
                _utility.ShowMessage("Save not successfully !", EnumsList.messageType.error);
            }
        }
    }
}
