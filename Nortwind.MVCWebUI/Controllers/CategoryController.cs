using Northwind.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Nortwind.MVCWebUI.Controllers
{
    public class CategoryController : Controller
    {
        //
        // GET: /Category/
        private ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        public PartialViewResult List(int category=0)//url e bakıp kategoriyi bulacak
        {
            //hangi kategoride olduğumuz
            ViewBag.CurrentCategory = category;
            return PartialView(_categoryService.GetAll());
        }

    }
}
