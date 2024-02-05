using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleProject.ViewModels.Product
{
    public class AddProductViewModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public double? Price { get; set; }
        public int? Count { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public string Mission { get; set; }

    }
}
