using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// Товары в заказе
    /// </summary>
    [DataContract]
    public class RequestProduct
    {
        [DataMember]
        public int RequestId { get; set; }
        [DataMember]
        public int ProductId { get; set; }
        [DataMember]
        public int ProviderId { get; set; }
        [DataMember]
        public string Status { get; set; }
        [DataMember]
        public int Amount { get; set; }
        public virtual Request Request { get; set; }
        public virtual Product Product { get; set; }
        public virtual Provider Provider { get; set; }

    }
}
