﻿using System.Runtime.Serialization;

namespace Model
{
    /// <summary>
    /// Товары в заказе
    /// </summary>
    [DataContract]
    public class RequestProduct
    {
        [DataMember]
        public int Id { get; set; }
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
