using SampleProject.Entities;
using SampleProject.ViewModels.Product;

namespace SampleProject.Services.Contracts;

public interface IProductService

{
    List<ShowProductViewModel> GetAll();
    UpdateProductViewModel GetById(int id);
    void Add(AddProductViewModel product);
    void Update(UpdateProductViewModel product);
    void Delete(int id);

}

