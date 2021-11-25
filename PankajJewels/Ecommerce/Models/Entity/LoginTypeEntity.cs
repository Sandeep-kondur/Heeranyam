using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Models.Entity
{
    public class LoginTypeEntity
    {
        [Key]
        public int LogInTypeID { get; set; }
        public string LoginTypeName { get; set; }

        public int IsDeleted { get; set; }

    }
}
