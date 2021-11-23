using DivarModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DivarService
{
    public class CategoryService
    {
        private readonly DivarData.Divar_Data _Data;
        public CategoryService()
        {
            _Data = new DivarData.Divar_Data();
        }

        public bool Add(Category cat)
        {
            return _Data.CategoryRepo.Add(cat);
        }
        public bool Edit(int id , Category cat)
        {
            return _Data.CategoryRepo.Edit(id, cat);
        }
        public bool Delete(int id)
        {
            return _Data.CategoryRepo.Delete(id);
        }
        public List<Category> GetAll()
        {
            return _Data.CategoryRepo.GetAll();
        }
        public Category GetById(int id)
        {
            return _Data.CategoryRepo.GetById(id);
        }
    }
}
