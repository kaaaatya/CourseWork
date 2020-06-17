using System;

namespace Model.ViewModels
{
    public class RequestViewModel
    {
        
        public int Id { get; set; }        
        public DateTime? Date { get; set; }        
        public string Address { get; set; }               
        public bool ReceiptMark { get; set; }
        public DateTime? DateReception { get; set; }
        public int Prioritet { get; set; }
        public int UserId { get; set; }
    }
}
