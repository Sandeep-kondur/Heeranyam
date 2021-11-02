using Ecommerce.Models.Entity;
using Ecommerce.Models.InterfacesBAL;
using Ecommerce.Models.ModelClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Models.BAL
{
    public class CommonService : ICommonService
    {
        private readonly MyDbContext context;
        public CommonService(MyDbContext context)
        {
            this.context = context;
        }

        public List<CountryMasterEntity> GetAllCountryies()
        {
            return context.countryMasterEntities.Where(a => a.IsDeleted == false).OrderBy(b => b.CountryName).ToList();
        }
        public List<AddressTypesEntity> GetAllAddressTypes()
        {
            return context.addressTypesEntities.Where(a => a.IsDeleted == false).ToList();
        }
        public List<StateMasterEntity> GetAllStates(int countryId)
        {
            return context.stateMasterEntities
                .Where(a => a.IsDeleted == false && a.CountryId == countryId)
                .OrderBy(a => a.StateName)
                .ToList();
        }

        //public List<StateMasterEntity> GetAllStates(int cid)
        //{
        //    return context.stateMasterEntities
        //        .Where(a => a.IsDeleted == false && a.CountryId == cid)
        //        .OrderBy(a => a.StateName)
        //        .ToList();
        //}
        public List<CityMasterEntity> GetallCities(int stateId)
        {
            return context.cityMasterEntities
                .Where(a => a.IsDeleted == false && a.StateId == stateId)
                .OrderBy(a => a.CityName).ToList();
        }

        public List<UserTypeMasterEnity> GetUserTypeMasters()
        {
            return context.userTypeMasters.Where(a => a.IsDeleted == false).ToList();
        }

        public List<MainMenuDropModel> GetMainMenu()
        {
            List<MainMenuDropModel> myList = new List<MainMenuDropModel>();
            myList = context.categoryMasterEntities.Where(a => a.IsDeleted == false).Select(b => new MainMenuDropModel
            {
                CatId = b.CategoryId,
                CatName = b.CategoryName
            }).ToList();
            if(myList.Count > 0)
            {
                for (int i = 0; i < myList.Count; i++)
                {
                    int currentId = myList[i].CatId;
                    List<SubCatDrop> sbList = new List<SubCatDrop>();
                    sbList = context.subCategoryMasters.Where(a => a.IsDeleted == false && a.CategoryId == currentId)
                        .Select(b => new SubCatDrop{
                            SubCatId = b.SubCategoryId,
                             SubCatName = b.SubCategoryName
                        })
                        .ToList();
                   if(sbList.Count> 0)
                    {
                        for(int j=0; j < sbList.Count; j++)
                        {
                            int currentSbId = sbList[j].SubCatId;
                            List<DetCatDrop> dList = context.detailCategoryMasters.Where(a => a.IsDeleted == false && a.SubCategoryId == currentSbId)
                                .Select(b => new DetCatDrop
                                {
                                    DetCatId = b.DetailCategoryId,
                                    DetCatName = b.DetailCategoryName
                                }).ToList();

                            sbList[j].detCats = dList;
                        }
                    }
                    myList[i].subCats = sbList;
                }
            }
            return myList;
        }

    }
}
