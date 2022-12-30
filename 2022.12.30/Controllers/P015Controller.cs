using _2022._12._30.Models.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Web.UI.WebControls;

namespace _2022._12._30.Controllers
{
    public class P015Controller : Controller
    {
        private AppDbContext db = new AppDbContext();
        // GET: P010
        public ActionResult Index2(int? categoryid, string productName,string price)
        {//將篩選條件放在Viewbag,稍後取回
            ViewBag.Categories = GetCategories2(categoryid);
            ViewBag.ProductName = productName;
            ViewBag.Price = price;
            var data = db.Products.Include(x => x.Category);

            //若有選擇,篩選categoryid
            if (categoryid.HasValue) data = data.Where(p => p.CategoryId == categoryid.Value);
            //若有選擇,篩選productName
            if (string.IsNullOrEmpty(productName) == false) data =
                    data.Where(p => p.Name.Contains(productName));
            if(string.IsNullOrEmpty(price) == false) data =
                    data.Where(p => p.price.Contains(price));
            return View(data.ToList());

        }

        private IEnumerable<SelectListItem> GetCategories2(int? categoryid)
        {
            var items = db.Categories
                 .Select(c => new SelectListItem
                 {
                     Value = c.Id.ToString(),
                     Text = c.Name,
                     Selected = (categoryid.HasValue) && c.Id == categoryid.Value
                 })
                 .ToList()
                 .Prepend(new SelectListItem()//新增一個選項是請選擇 //View post為看不到操作網址,get會顯示操作
                 {
                     Value = string.Empty,
                     Text = "請選擇"
                 });
            return items;
        }
    }
}