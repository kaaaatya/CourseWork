using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

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
