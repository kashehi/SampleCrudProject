
using Microsoft.EntityFrameworkCore;
using SampleProject.DataLayer.Context;
using SampleProject.Entities;
using SampleProject.ViewModels.Categories;

namespace SampleProject.Services.Contracts.EFServices
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _uow;

        private readonly DbSet<Category> _category;

        public CategoryService(IUnitOfWork uow)
        {
            _uow = uow;
            _category = uow.Set<Category>();
        }

        public void Add(AddCategoryViewModel category)
        {
            _category.Add(new Entities.Category()
            {
                Title = category.Title,
                ParentId = category.ParentId,
                IsDeleted = false,

            });
            _uow.SaveChanges();
        }

        public void Delete(int id)
        {
            var category = _category.SingleOrDefault(c => c.Id == id);
            if (category != null)
            {
                category.IsDeleted = true;
                _uow.SaveChanges();
            }


        }

        public List<ShowCategoryViewModel> GetAll()
        {
            var category = _category.Select(s => new ShowCategoryViewModel
            {
                Id = s.Id,
                Title = s.Title,
                ParentId = s.ParentId,

            }).ToList();
            return category;
        }

        public UpdateCategoryViewModel GetById(int id)
        {
            var category = _category.Where(w => w.Id == id).Select(s => new UpdateCategoryViewModel
            {
                Id = s.Id,
                Title = s.Title,
                ParentId = s.ParentId,


            }).SingleOrDefault();

            if (category != null)
            {
                return category;
            }
            return null;
        }

        public void Update(UpdateCategoryViewModel categoryInfo)
        {
            var category = _category.Where(p => p.Id == categoryInfo.Id).SingleOrDefault();
            if (category != null)
            {
                category.Title = categoryInfo.Title;
                category.ParentId = categoryInfo.ParentId;

                _uow.SaveChanges();

            }

        }
    }
}
