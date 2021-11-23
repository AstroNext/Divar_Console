using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DivarModel;

namespace DivarData
{
    public class CategoryRep : IRepoCategory
    {
        List<Category> Categorys = new List<Category>();
        public bool Add(Category cat)
        {
            bool flag = false;
            if(cat != null)
            {
                if (Categorys.Count == 0)
                {
                    cat.Id = 1;
                }
                else
                {
                    cat.Id = Categorys.Last().Id + 1;
                }

                Categorys.Add(cat);
                flag = true;
            }
            return flag;
        }

        public bool Delete(int id)
        {
            if(id > 0)
            {
                var found = Categorys.Where(x => x.Id.Equals(id)).SingleOrDefault();

                if (found != null)
                {
                    if (found.IsVisuble == Enums.IsVisuble.Show)
                    {
                        found.IsVisuble = Enums.IsVisuble.Delete;
                        return true;
                    }
                    else
                    {
                        found.IsVisuble = Enums.IsVisuble.Show;
                        return true;
                    }
                }
                return false;
            }
            return false;
        }

        public bool Edit(int id, Category cat)
        {
            if (id > 0 && cat != null)
            {
                var found = Categorys.Where(x => x.Id.Equals(id) && x.IsVisuble == Enums.IsVisuble.Show).SingleOrDefault();

                if (found != null)
                {
                    found.CategoryName = cat.CategoryName;
                    found.IsVisuble = cat.IsVisuble;
                    return true;
                }
                return false;
            }
            return false;
        }

        public List<Category> GetAll()
        {
             return Categorys.Where(x => x.IsVisuble == Enums.IsVisuble.Show).ToList();
        }

        public Category GetById(int id)
        {
            return Categorys.Where(x => x.Id.Equals(id) && x.IsVisuble == Enums.IsVisuble.Show).SingleOrDefault();
        }
    }
}
