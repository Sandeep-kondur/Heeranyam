using Ecommerce.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Models.ModelClasses
{
    public class HomeProductsModels
    {
        public List<ProductListDisplay> hotDeals { get; set; }
        public List<ProductListDisplay> featured { get; set; }
        public List<ProductListDisplay> allGold { get; set; }
        public List<ProductListDisplay> newArrivals { get; set; }
        public List<ProductListDisplay> listProducts { get; set; }
        public List<MainMenuDropModel> mainMenus { get; set; }
        public int totalRecords { get; set; } = 0;

        // for filters
        public List<MetalMasterEntity> metalDrop { get; set; }
        public  StaticDropDowns staticDrops { get; set; }
        public  List<DiscountMasterEntity> discDrops { get; set; }

        public List<SubCategoryMasterEntity> subCateDrop { get; set; }
        public List<DetailCategoryMasterEntity> detCatDrops { get; set; }
        public List<CategoryMasterEntity> catDrops { get; set; } 


    }

    public class APIHomeProductsModels
    {
        public List<ProductListDisplay> hotDeals { get; set; }
        public List<ProductListDisplay> featured { get; set; }
        public List<ProductListDisplay> allGold { get; set; }
        public List<ProductListDisplay> newArrivals { get; set; }
        public List<APIProductListDisplay> listProducts { get; set; }
        public List<MainMenuDropModel> mainMenus { get; set; }
        public int totalRecords { get; set; } = 0;

        // for filters
        public List<MetalMasterEntity> metalDrop { get; set; }
        public StaticDropDowns staticDrops { get; set; }
        public List<DiscountMasterEntity> discDrops { get; set; }

        public List<SubCategoryMasterEntity> subCateDrop { get; set; }
        public List<DetailCategoryMasterEntity> detCatDrops { get; set; }
        public List<CategoryMasterEntity> catDrops { get; set; }


    }
}
