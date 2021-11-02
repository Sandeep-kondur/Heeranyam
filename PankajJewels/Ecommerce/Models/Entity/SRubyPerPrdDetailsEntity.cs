using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace Ecommerce.Models.Entity
{
    public class SRubyPerPrdDetailsEntity
    {
        [Key]
        public int SRPPDId { get; set; }
        public int? SRPPId { get; set; }
        public int? NoofStones { get; set; }
        public int? ShapeId { get; set; }
        public string Size { get; set; }
        public int? SettingId { get; set; }
        public bool? IsDeleted { get; set; }
    }
    public class SRubyPerPrdDetailsEntity_Web
    {
        public int SRPPDId { get; set; }
        public int? SRPPId { get; set; }
        public int? NoofStones { get; set; }
        public int? ShapeId { get; set; }
        public string ShapeId_Name { get; set; }
        public string Size { get; set; }
        public int? SettingId { get; set; }
        public string SettingId_Name { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
