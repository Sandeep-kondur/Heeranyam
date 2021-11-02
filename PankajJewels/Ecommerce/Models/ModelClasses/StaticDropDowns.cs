using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Models.ModelClasses
{
    public class StaticDropDowns
    {
        public List<PriceDrop> priceDrop = new List<PriceDrop>();
        public List<GenderDrop> genderDrop = new List<GenderDrop>();
        public StaticDropDowns()
        {
            this.priceDrop.Add(new PriceDrop
            {
                key = "-1",
                value = "Select Price"
            });
            this.priceDrop.Add(new PriceDrop
            {
                key = "10000",
                value = "< 10000"
            });
            this.priceDrop.Add(new PriceDrop
            {
                key = "20000",
                value = "< 20000"
            });
            this.priceDrop.Add(new PriceDrop
            {
                key = "30000",
                value = "< 30000"
            });
            this.priceDrop.Add(new PriceDrop
            {
                key = "50000",
                value = "< 50000"
            });
            this.priceDrop.Add(new PriceDrop
            {
                key = "10000000",
                value = "> 50000"
            });

            this.genderDrop.Add(new GenderDrop
            {
                value = "Ideal For",
                key = "-1"
            });
            this.genderDrop.Add(new GenderDrop
            {
                value = "For All",
                key = "For All"
            });
            this.genderDrop.Add(new GenderDrop
            {
                value = "Male",
                key = "Male"
            });
            this.genderDrop.Add(new GenderDrop
            {
                value = "Female",
                key = "Female"
            });
            this.genderDrop.Add(new GenderDrop
            {
                value = "Kids",
                key = "Kids"
            });
        }
    }

    public class GenderDrop
    {
        public string key { get; set; }
        public string value { get; set; }
    }
    public class PriceDrop
    {
        public string key { get; set; }
        public string value { get; set; }
    }

}
