using Microsoft.AspNetCore.Mvc;
using SampleProject.DataLayer.Context;
using SampleProject.Services.Contracts;
using SampleProject.ViewModels.Product;
using SampleProject.Web.Models;
using System.Diagnostics;


namespace SampleProject.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductService _productService;
        private readonly SampleProjectDbContext _dbcontext;
        public HomeController(ILogger<HomeController> logger, IProductService productService ,SampleProjectDbContext dbcontext)
        {
            _logger = logger;
            _productService = productService;
            _dbcontext = dbcontext;
        }
       
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}