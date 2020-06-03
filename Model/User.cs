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
    /// Заказчик
    /// </summary>
    [DataContract]
    public class User
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string FIO { get; set; }
        [DataMember]
        public string CompanyName { get; set; }
        [DataMember]
        public string Login { get; set; }
        [DataMember]
        public string Password { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public string PhoneNumber { get; set; }
        [DataMember]
        public string Role { get; set; }
        [ForeignKey("UserId")]
        public virtual List<Request> Requests { get; set; }

    }
}
