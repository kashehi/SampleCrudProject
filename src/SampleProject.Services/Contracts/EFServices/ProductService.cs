using Microsoft.EntityFrameworkCore;
using SampleProject.DataLayer.Context;
using SampleProject.Entities;
using SampleProject.ViewModels.Product;

namespace SampleProject.Services.Contracts.EFServices
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _uow;

        private readonly DbSet<Product> _product;

        public ProductService(IUnitOfWork uow)
        {
            _uow = uow;
            _product = uow.Set<Product>();
        }

        // Get All Product Base on UpdateProductViewModel 
        public List<ShowProductViewModel> GetAll()
        {
            var product = _product.Select(s => new ShowProductViewModel
            {
                Id = s.Id,
                Title = s.Title,
                Description = s.Description,
                Color = s.Color,
                Price = s.Price,
                Model = s.Model,
                Mission = s.Mission,
                Count = s.Count,

            }).ToList();
            return product;

        }


        //Get ProductInfo Base on Selected Id 
        public UpdateProductViewModel GetById(int id)
        {
            var product = _product.Where(w => w.Id == id).Select(s => new UpdateProductViewModel
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
        public void Add(AddProductViewModel product)
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
            _uow.SaveChanges();

        }

        // Delete Product From Database
        public void Delete(int id)
        {
            var product = _product.SingleOrDefault(p => p.Id == id);
            if (product != null)
            {
                _product.Remove(product);
                _uow.SaveChanges();


            }
        }

        // Update Product On Database
        public void Update(UpdateProductViewModel productInfo)
        {
            var product = _product.Where(p => p.Id == productInfo.Id).SingleOrDefault();
            if (product != null)
            {
                product.Title = productInfo.Title;
                product.Description = productInfo.Description;
                product.Count = productInfo.Count;
                product.Price = productInfo.Price;
                product.Color = productInfo.Color;
                product.Model = productInfo.Model;
                product.Mission = productInfo.Mission;

                _uow.SaveChanges();

            }


        }


    }


}
