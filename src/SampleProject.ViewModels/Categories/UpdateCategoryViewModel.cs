
namespace SampleProject.ViewModels.Categories
{
    public class UpdateCategoryViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int? ParentId { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
