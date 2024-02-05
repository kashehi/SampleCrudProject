using Microsoft.AspNetCore.Mvc;
using SampleProject.Entities;
using SampleProject.Services.Contracts;
using SampleProject.ViewModels.Product;

namespace SampleProject.Web.Controllers;

public class ProductController : Controller
{
    private readonly ILogger<ProductController> _logger;
    private readonly IProductService _productService;

    public ProductController(ILogger<ProductController> logger, IProductService productService)
    {
        _logger = logger;
        _productService = productService;

    }

    //Get ListOf Product
    public ActionResult Index()
    {
        var product = _productService.GetAll();

        return View(product);
    }


    //Show Selected Product Form

    [HttpGet]
    public IActionResult Add()
    {
        return View();
    }


    //Add Product To Database After Submit Form

    [HttpPost]

    public ActionResult Add(AddProductViewModel product)
    {
        _productService.Add(product);
        return RedirectToAction("Index");
    }


    //Show ProductInfo Form Base On Selected Id

    [HttpGet]
    public IActionResult Update(int id)
    {
        var product = _productService.GetById(id);
        if (product != null)
        {

            return View("Update", product);

        }

        return RedirectToAction("Index");



    }


    //Update ProductInfo On Database After Submit Form

    [HttpPost]
    public IActionResult Update(UpdateProductViewModel product)
    {

        _productService.Update(product);

        return RedirectToAction("Index");
    }


    // Delete Product On Database

    [HttpGet]
    public IActionResult Delete(int id)
    {
        _productService.Delete(id);

        return RedirectToAction("Index");


    }
}

