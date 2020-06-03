using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// Товары, поставляемые поставщиком
    /// </summary>
    [DataContract]
    public class ProviderProduct
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int ProviderId { get; set; }
        [DataMember]
        public int ProductId { get; set; }
        [DataMember]
        public decimal Price { get; set; }
        [DataMember]
        public int InStockAmount { get; set; }
        public virtual Product Product { get; set; }
        public virtual Provider Provider { get; set; }


    }
}
