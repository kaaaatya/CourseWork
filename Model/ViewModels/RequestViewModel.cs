using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.ViewModels
{
    public class RequestViewModel
    {
        
        public int Id { get; set; }        
        public DateTime? Date { get; set; }        
        public string Address { get; set; }        
        public string Feedback { get; set; }        
        public bool ReceiptMark { get; set; }        
        public int UserId { get; set; }
    }
}
