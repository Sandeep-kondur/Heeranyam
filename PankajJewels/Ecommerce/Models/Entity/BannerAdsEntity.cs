using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Models.Entity
{
    public class BannerAdsEntity
    {
        [Key]
        public int BannerId { get; set; }
        public string BannerUrl { get; set; }
        public string BannerType { get; set; }
        public string BannerPage { get; set; }
        public string BannerSection { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime? PostedOn { get; set; }
        public int? PostedBy { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? Duration { get; set; }
        public string CurrentStatus { get; set; }
        public string BannerWebSite { get; set; }
        public string BannerTextShort { get; set; }
        public string BannerTextBig { get; set; }
    }
}
