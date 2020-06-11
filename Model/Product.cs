using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Model
{
    /// <summary>
    /// Товар
    /// </summary>
    [DataContract]
    public class Product
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string ProductName { get; set; }
        [ForeignKey("ProductId")]
        public virtual List<ProviderProduct> ProviderProducts { get; set; }

        [ForeignKey("ProductId")]
        public virtual List<RequestProduct> RequestProducts { get; set; }

    }
}
