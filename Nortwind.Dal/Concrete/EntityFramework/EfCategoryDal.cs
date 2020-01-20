using Nortwind.Dal.Abstract;
using Nortwind.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nortwind.Dal.Concrete.EntityFramework
{
    public class EfCategoryDal :ICategoryDal
    {
        NortwindContext _context = new NortwindContext();
        public List<Category> GetAll()
        {
            return _context.Categories.ToList();
        }

    }
}
