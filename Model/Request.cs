﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Model
{
    /// <summary>
    /// Заказ
    /// </summary>
    [DataContract]
    public class Request
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public DateTime? Date { get; set; }
        [DataMember]
        public string Address { get; set; }
        [DataMember]
        public bool ReceiptMark { get; set; }
        [DataMember]
        public DateTime? DateReception { get; set; }
        [DataMember]
        public int Prioritet { get; set; }
        [DataMember]
        public int UserId { get; set; }
        public virtual User User { get; set; }
        [ForeignKey("RequestId")]
        public virtual List<RequestProduct> RequestProducts { get; set; }
    }
}
