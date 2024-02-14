using System.ComponentModel.DataAnnotations;

namespace SampleProject.Entities
{
    public class Category
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public int? ParentId { get; set; }
        public bool? IsDeleted { get; set; }
        public virtual Category Parent { get; set; }
        public virtual ICollection<Category> Children { get; set; }

    }
}
