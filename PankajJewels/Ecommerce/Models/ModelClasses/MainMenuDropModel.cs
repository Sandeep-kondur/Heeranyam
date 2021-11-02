using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Models.ModelClasses
{
    public class MainMenuDropModel
    {
        public int CatId { get; set; }
        public string CatName { get; set; }
        public List<SubCatDrop> subCats { get; set; }
    }
    public class SubCatDrop
    {
        public int SubCatId { get; set; }
        public string SubCatName { get; set; }
        public List<DetCatDrop> detCats { get; set; }
    }
    public class DetCatDrop
    {
        public int DetCatId { get; set; }
        public string DetCatName { get; set; }
    }
}
