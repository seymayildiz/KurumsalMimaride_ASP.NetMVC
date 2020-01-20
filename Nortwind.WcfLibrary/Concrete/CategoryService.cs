using Northwind.Interfaces;
using Nortwind.Dal.Concrete.EntityFramework;
using Nortwind.Bll.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nortwind.WcfLibrary.Concrete
{
    public class CategoryService :ICategoryService
    {
        CategoryManager _categoryManager = new CategoryManager(new EfCategoryDal());//manager iş katmanı 
        public List<Entities.Category> GetAll()
        {
            return _categoryManager.GetAll();
        }
    }
}
