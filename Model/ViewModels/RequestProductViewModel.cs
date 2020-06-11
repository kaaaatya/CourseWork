namespace Model.ViewModels
{
    public class RequestProductViewModel
    {
        
        public int Id { get; set; }        
        public int RequestId { get; set; }        
        public int ProductId { get; set; }        
        public int ProviderId { get; set; }        
        public string Status { get; set; }        
        public int Amount { get; set; }
    }
}
