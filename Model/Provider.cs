using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Model
{
    /// <summary>
    /// Поставщик товаров
    /// </summary>
    [DataContract]
    public class Provider
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string CompanyName { get; set; }
        [DataMember]
        public decimal Rating { get; set; }
        [DataMember]
        public string Address { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public string PhoneNumber { get; set; }

        [ForeignKey("ProviderId")]
        public virtual List<ProviderProduct> ProviderProducts { get; set; }

        [ForeignKey("ProviderId")]
        public virtual List<RequestProduct> RequestProducts { get; set; }
    }
}
