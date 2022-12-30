using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using X.PagedList;
using _2022._12._30.Models.VM;

namespace _2022._12._30.Controllers
{
    public class P100_2Controller : Controller
    {
        // GET: P100_2
        public ActionResult Index(int pageNumber=1)
        {
            pageNumber = pageNumber > 0 ? pageNumber : 1;
            IPagedList<Product> pageData = GetpagedProducts(pageNumber);
            return View(pageData);
        }

        private IPagedList<Product> GetpagedProducts(int pageNumber)
        {
            var db=new AppDbContext();
            int pagesize = 3;
            var query = db.Products.Include(x => x.Category)
                .OrderBy(x => x.Category.DisplayOrder);

            return query.ToPagedList(pageNumber,pagesize);
        }
    }
}