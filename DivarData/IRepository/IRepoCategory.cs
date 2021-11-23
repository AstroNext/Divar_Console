using DivarModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DivarData
{
    public interface IRepoCategory
    {
        bool Add(Category cat);
        bool Delete(int id);
        bool Edit(int id, Category cat);
        List<Category> GetAll();
        Category GetById(int id);
    }
}
