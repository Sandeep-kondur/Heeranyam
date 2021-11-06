using System;
using System.Collections.Generic;

namespace Ecommerce.Models.Utilities
{
    public class Category
    {
        
         
        public int Id { get; set; }

        public string Name { get; set; }

         
        public int ParentMenuId { get; set; }

        public virtual List<SubCategory> SubCategory { get; set; }

        public string ControllerName { get; set; }

        public string ActionName { get; set; }

      
        public bool Permitted { get; set; }

        public string Image { get; set; }

    }
    public class Categories {
        public List<Category> Category { get; set; }
    }

    public class SubCategory
    {
        public int Id { get; set; }

        public string Name { get; set; }


        public int ParentMenuId { get; set; }

        public string ControllerName { get; set; }

        public string ActionName { get; set; }


        public bool Permitted { get; set; }

        public string Image { get; set; }
        public List<SubCategory> SubCategories{ get; set; }
    }

    
}
