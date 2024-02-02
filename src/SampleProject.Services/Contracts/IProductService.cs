using SampleProject.Entities;
using SampleProject.ViewModels.Product;

namespace SampleProject.Services.Contracts;

public interface IProductService

{
    List<ViewProductViewModel> GetAll();
    ViewProductViewModel GetById(int id);
    void Add(ViewProductViewModel product);
    void Update(Product product);
    void Delete(int id);

}

