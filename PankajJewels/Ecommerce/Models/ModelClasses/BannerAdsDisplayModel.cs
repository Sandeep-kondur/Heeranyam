using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Ecommerce.Models.Entity;
using Microsoft.AspNetCore.Http;

namespace Ecommerce.Models.ModelClasses
{
    public class BannerAdsDisplayModel
    {
        public IFormFile ImageUploaded { get; set; }
        public int BannerId { get; set; }
        public string BannerUrl { get; set; }
        public string BannerType { get; set; }
        public string BannerPage { get; set; }
        public string BannerSection { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime? PostedOn { get; set; }

        
        public int? PostedBy { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? StartDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? EndDate { get; set; }
        public int? Duration { get; set; }
        public string CurrentStatus { get; set; }
        public string BannerWebSite { get; set; }
        public string BannerTextShort { get; set; }
        public string BannerTextBig { get; set; }

    }

    public class BannerAdsDisplayModelBase
    {
        public List<BannerAdsDisplayModel> myAds { get; set; }

        public List<BannerPageMaster> pageDrop { get; set; }
        public List<BannerPageSection> sectionDrop { get; set; }
    }
}
