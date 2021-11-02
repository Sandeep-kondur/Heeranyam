using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Models.ModelClasses
{
    public class DaimondsPerPrdDisplayModel
    {
        public int DPPDId { get; set; }
        public int NoofDaimonds { get; set; }
        public decimal LineWaight { get; set; }
        public string ColorName { get; set; }
        public string ShapeName { get; set; }
        public string SettingName { get; set; }
        public string ClarityName { get; set; }

    }
    public class PerlPerPrdDisplayModel
    {
        public int PPPId { get; set; }
        public int NoofStones { get; set; }
        public decimal Size { get; set; }
        public string ShapeName { get; set; }
        public string SettingName { get; set; }

    }

    public class SolPerPrdDisplayModel
    {
        public int SPPDId { get; set; }
        public int NoofSolitaire { get; set; }
        public decimal TotalWaight { get; set; }
        public string ClarityName { get; set; }
        public string ColorName { get; set; }
        public string ShapeName { get; set; }
        public string SymmetryName { get; set; }
        public string FluorescenceName { get; set; }
    }

    public class SRubyPerPrdDisplayModel
    {
        public int SRPPId { get; set; }
        public int NoofStones { get; set; }
        public string ShapeName { get; set; }
        public string SettingName { get; set; }
    }
}
