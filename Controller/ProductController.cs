using Model;
using Model.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    public class ProductController
    {
        private CourseWorkDbContext context;
        public ProductController(CourseWorkDbContext context)
        {
            this.context = context;
        }
        public List<ProductViewModel> GetList()
        {
            List<ProductViewModel> result = context.Products.Select(rec => new
           ProductViewModel
            {
                Id = rec.Id,
                ProductName = rec.ProductName
            })
            .ToList();
            return result;

        }

        public int findIdByName(string ProdName)
        {
            Product element = context.Products.FirstOrDefault(rec => rec.ProductName == ProdName);
            int result = element.Id;
            return result;
        }

        public string ProductNameById(int productId)
        {
            Product element = context.Products.FirstOrDefault(rec => rec.Id == productId);
            string name = element.ProductName;
            return name;
        }
    }
}
