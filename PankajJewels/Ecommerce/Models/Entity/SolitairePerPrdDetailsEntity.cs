using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace Ecommerce.Models.Entity
{
    public class SolitairePerPrdDetailsEntity
    {
        [Key]
        public int SPPDId { get; set; }
        public int? SPPId { get; set; }
        public int? NoofSolitaire { get; set; }
        public int? ClarityId { get; set; }
        public int? ColorId { get; set; }
        public int? ShapeId { get; set; }
        public int? Symmetry { get; set; }
        public int? FluorescenceId { get; set; }
        public bool? IsDeleted { get; set; }
        public decimal? TotalWaight { get; set; }
        public int? CertificationId { get; set; }
    }
    public class SolitairePerPrdDetailsEntity_Web
    {
        
        public int SPPDId { get; set; }
        public int? SPPId { get; set; }
        public int? NoofSolitaire { get; set; }
        public int? ClarityId { get; set; }
        public string ClarityId_Nme { get; set; }
        public int? ColorId { get; set; }
        public string ColorId_Name { get; set; }
        public int? ShapeId { get; set; }
        public string ShapeId_Name { get; set; }
        public int? Symmetry { get; set; }
        public string Symmetry_Name { get; set; }
        public int? FluorescenceId { get; set; }

        public string FluorescenceId_Name { get; set; }
        public bool? IsDeleted { get; set; }
        public decimal? TotalWaight { get; set; }
        public int? CertificationId { get; set; }
        public string CertificationId_Name { get; set; }
    }
}
