using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Models.ModelClasses
{
    public class CODPaymentUpdateModel
    {

        public int POId { get; set; }

        [Required(ErrorMessage = "Date is required")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? PaidDate { get; set; }
        [Required(ErrorMessage = "Amount is required")]
        public decimal PaidAmount { get; set; }

        public decimal Charges { get; set; }

        [Required(ErrorMessage = "Remarks are required")]
        public string Remarks { get; set; }
    }
}
