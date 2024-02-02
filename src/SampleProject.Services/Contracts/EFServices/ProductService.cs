using Microsoft.EntityFrameworkCore;
using SampleProject.DataLayer.Context;
using SampleProject.Entities;
using SampleProject.ViewModels.Product;

namespace SampleProject.Services.Contracts.EFServices
{
    public class ProductService : IProductService
    {
        private readonly SampleProjectDbContext _dbContext;
        private readonly DbSet<Product> _product;
        public ProductService(SampleProjectDbContext dbContext)
        {
            _dbContext = dbContext;
            _product = dbContext.Set<Product>();
        }

        // Get All Product Base on UpdateProductViewModel 
        public List<ViewProductViewModel> GetAll()
        {
            var product = _dbContext.Products.Select(s => new ViewProductViewModel
            {
                Id = s.Id,
                Title = s.Title,
                Description = s.Description,
                Color = s.Color,
                Price = s.Price,
                Model = s.Model,
                Mission = s.Mission,
                Count=s.Count,  

            }).ToList();
            return product;
        }


        //Get ProductInfo Base on Selected Id 
        public ViewProductViewModel GetById(int id)
        {
            var product = _dbContext.Products.Where(w => w.Id == id).Select(s => new ViewProductViewModel
            {
                Id = s.Id,
                Title = s.Title,
                Description = s.Description,
                Color = s.Color,
                Price = s.Price,
                Model = s.Model,
                Mission = s.Mission,
                Count = s.Count,
            }).SingleOrDefault();

            if (product != null)
            {
                return product;
            }
            return null;

        }

        // Add Product To Database
        public void Add(ViewProductViewModel product)
        {
            _product.Add(new Entities.Product()
            {
                Title = product.Title,
                Description = product.Description,
                Count = product.Count,
                Price = product.Price,
                Color = product.Color,
                Model = product.Model,
                Mission = product.Mission,

            });
            _dbContext.SaveChanges();

        }

        // Delete Product From Database
        public void Delete(int id)
        {
            var product = _dbContext.Products.FirstOrDefault(p => p.Id == id);
            if (product != null)
            {
                _dbContext.Products.Remove(product);
                _dbContext.SaveChanges();


            }
        }

        // Update Product On Database
        public void Update(Product productInfo)
        {
            var product = _dbContext.Products.Where(p => p.Id == productInfo.Id).SingleOrDefault();
            if (product != null)
            {
                product.Title = productInfo.Title;
                product.Description = productInfo.Description;
                product.Count = productInfo.Count;
                product.Price = productInfo.Price;
                product.Color = productInfo.Color;
                product.Model = productInfo.Model;
                product.Mission = productInfo.Mission;

                _dbContext.SaveChanges();

            }


        }


    }


}
