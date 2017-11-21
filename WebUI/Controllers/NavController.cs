using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Domain.Abstract;

namespace WebUI.Controllers
{
    public class NavController : Controller
    {
        private IProductRepository repository;

        public NavController(IProductRepository repo)
        {
            this.repository = repo;
        }

        // GET: Nav
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult Menu(string Category = null)
        {
            ViewBag.SelectedCategory = Category;
            IEnumerable<string> categories = repository.Products
                .Select(x => x.Category)
                .Distinct()
                .OrderBy(x => x);
            return PartialView(categories);
        }
    }
}