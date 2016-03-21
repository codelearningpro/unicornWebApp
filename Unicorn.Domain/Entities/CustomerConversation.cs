using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Unicorn.Domain.Entities
{
    public class CustomerConversation : Auditable
    {
        [Key]
        public int ID { get; set; }
        public int ChannelID { get; set; }
        public int CustomerID { get; set; }
        public string Message { get; set; }
    }
}
