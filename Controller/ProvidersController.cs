using Model;
using Model.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    public class ProvidersController
    {
        private CourseWorkDbContext context;
        public ProvidersController(CourseWorkDbContext context)
        {
            this.context = context;
        }
        public List<ProviderViewModel> GetList()
        {
            List<ProviderViewModel> result = context.Providers.Select(rec => new
           ProviderViewModel
            {
                Id = rec.Id,
                CompanyName = rec.CompanyName,
                Rating = rec.Rating,
                Address = rec.Address,
                Email = rec.Email,
                PhoneNumber = rec.PhoneNumber

            })
            .ToList();
            return result;

        }

        public Provider getById(int providerId)
        {
            Provider element = context.Providers.FirstOrDefault(rec => rec.Id == providerId);
            return element;
        }

        public string ProviderNameById(int providerId)
        {
            Provider element = context.Providers.FirstOrDefault(rec => rec.Id == providerId);
            string name = element.CompanyName;
            return name;
        }

        public void rateProvider(int providerId, decimal rate)
        {
            Provider element = getById(providerId);
            element.Rating = (element.Rating + rate) / 2;
            context.SaveChanges();

        }
    }
}
