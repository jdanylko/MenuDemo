using System.Web.Mvc;
using MenuDemo.Models;
using MenuDemo.Repository;

namespace MenuDemo.Controllers
{
    public class HomeController : Controller
    {
        private IRepository<MenuItem> MenuRepository { get; set; }

        public HomeController()
        {
            MenuRepository = new MenuRepository();
        }

        public ActionResult Index()
        {
            var menuModel = new MenuViewModel
            {
                MenuItems = MenuRepository.GetAll()
            };

            return View(menuModel);
        }
    }
}