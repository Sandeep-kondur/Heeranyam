using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace Ecommerce.Models.Entity
{
    public class DaimondsPerPrdDetailsEntity
    {
        [Key]
        public int DPPDId { get; set; }
        public int? DPPId { get; set; }
        public int? NoofDaimonds { get; set; }
        public int? ClarityId { get; set; }
        public int? ColorId { get; set; }
        public int? ShapeId { get; set; }
        public int? SettingTypeId { get; set; }
        public bool? IsDeleted { get; set; }
        public decimal? TotalWaight { get; set; }

        public int? DaimondTypeId { get; set; }
    }

    public class DaimondsPerPrdDetailsEntity_Web
    {
        
        public int DPPDId { get; set; }
        public int? DPPId { get; set; }
        public int? NoofDaimonds { get; set; }
        public int? ClarityId { get; set; }
        public string ClarityId_Name { get; set; }
        public int? ColorId { get; set; }
        public string ColorId_Name { get; set; }
        public int? ShapeId { get; set; }
        public string ShapeId_Name { get; set; }
        public int? SettingTypeId { get; set; }
        public string SettingTypeId_Name { get; set; }
        public bool? IsDeleted { get; set; }
        public decimal? TotalWaight { get; set; }
        public string DaimondTypeId_Name { get; set; }

        public int? DaimondTypeId { get; set; }
    }

}
