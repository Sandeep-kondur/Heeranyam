using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Models.Entity
{
    public class CertificateMasterEntity
    {
        [Key]
        public int MasterId { get; set; }
        public string CertifycateName { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
