using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Models.Entity
{
    public class RazorRefundEntity
    {
        [Key]
        public int TRID { get; set; }

        public string Refund_id { get; set; }

        public string Payment_id { get; set; }

        public string entity { get; set; }
        public string currency { get; set; }
        public string order_id { get; set; }
        public string invoice_id { get; set; }


        public bool international { get; set; }
        public string method { get; set; }
        public int amount_refunded { get; set; }
        public string refund_status { get; set; }

        public bool captured { get; set; }
        public string notes { get; set; }
        public string description { get; set; }
        public string card_id { get; set; }

        public string bank { get; set; }


        public string speed_processed { get; set; }
        public string receipt { get; set; }
        public string speed_requested { get; set; }

        public string batch_id { get; set; }


        public int created_at { get; set; }
        public int POID { get; set; }
        public bool IsDeleted { get; set; }



    }
}
