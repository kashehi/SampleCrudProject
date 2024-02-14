using SampleProject.ViewModels.Categories;

namespace SampleProject.Services.Contracts
{
    public interface ICategoryService
    {
        List<ShowCategoryViewModel> GetAll();
        UpdateCategoryViewModel GetById(int id);
        void Add(AddCategoryViewModel category);
        void Update(UpdateCategoryViewModel category);
        void Delete(int id);

    }
}
