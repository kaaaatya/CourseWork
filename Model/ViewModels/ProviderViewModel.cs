using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.ViewModels
{
    public class ProviderViewModel
    {
        
        public int Id { get; set; }        
        public string CompanyName { get; set; }        
        public decimal Rating { get; set; }        
        public string Address { get; set; }        
        public string Email { get; set; }        
        public string PhoneNumber { get; set; }
    }
}
