using Microsoft.AspNetCore.Mvc;
using SampleProject.Services.Contracts;
using SampleProject.ViewModels.Categories;

namespace SampleProject.Web.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ILogger<CategoryController> _logger;
        private readonly ICategoryService _categoryService;

        public CategoryController(ILogger<CategoryController> logger, ICategoryService categoryService)
        {
            _logger = logger;
            _categoryService = categoryService;

        }


        [HttpGet]
        public IActionResult Index()
        {
            var category = _categoryService.GetAll();
            return View(category);
        }

        [HttpPost]
        public IActionResult Add(AddCategoryViewModel category)
        {
            _categoryService.Add(category);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var category = _categoryService.GetById(id);
            if (category != null)
            {

                return View("Update", category);

            }

            return RedirectToAction("Index");

        }

        [HttpPost]
        public IActionResult Update(UpdateCategoryViewModel category)
        {
            _categoryService.Update(category);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            _categoryService.Delete(id);
            return RedirectToAction("Index");
        }


    }
}
