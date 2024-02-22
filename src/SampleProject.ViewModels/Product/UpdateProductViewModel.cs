
using System.ComponentModel.DataAnnotations;

namespace SampleProject.ViewModels.Product
{
    public class UpdateProductViewModel
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        [Display(Name = "عنوان محصول")]
        public string? Title { get; set; }

        [Display(Name = "توضیحات")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        [Display(Name = "قیمت")]
        public double? Price { get; set; }

        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        [Display(Name = "تعداد")]
        public int? Count { get; set; }

        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        [Display(Name = "مدل")]
        public string? Model { get; set; }

        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        [Display(Name = "رنگ")]
        public string? Color { get; set; }

        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        [Display(Name = "ابعاد")]
        public string? Mission { get; set; }
    }
}
