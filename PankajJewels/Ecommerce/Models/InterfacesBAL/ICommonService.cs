using Ecommerce.Models.Entity;
using Ecommerce.Models.ModelClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Models.InterfacesBAL
{
    public interface ICommonService
    {
        List<CountryMasterEntity> GetAllCountryies();
        List<StateMasterEntity> GetAllStates(int countryId);

      
        List<CityMasterEntity> GetallCities(int stateId);
        List<UserTypeMasterEnity> GetUserTypeMasters();
        List<MainMenuDropModel> GetMainMenu();
        List<AddressTypesEntity> GetAllAddressTypes();
    }
}
