using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.ViewModels
{
    public class ProviderProductViewModel
    {
        
        public int Id { get; set; }        
        public int ProviderId { get; set; }        
        public int ProductId { get; set; }        
        public decimal Price { get; set; }        
        public int InStockAmount { get; set; }
    }
}
