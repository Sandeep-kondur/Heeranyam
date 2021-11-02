using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace Ecommerce.Models.Entity
{
    public class PerlPerPrdDetailsEntity
    {
        [Key]
        public int PPPDId { get; set; }
        public int? PPPId { get; set; }
        public int? NoofStones { get; set; }
        public int? ShapeId { get; set; }
        public decimal? Size { get; set; }
        public int? SettingId { get; set; }
        public bool? IsDeleted { get; set; }
    }

    public class PerlPerPrdDetailsEntity_Web
    {
        
        public int PPPDId { get; set; }
        public int? PPPId { get; set; }
        public int? NoofStones { get; set; }
        public int? ShapeId { get; set; }

        public string ShapeId_Name { get; set; }
        public decimal? Size { get; set; }
        public int? SettingId { get; set; }
        public string SettingId_Name { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
