using Ecommerce.Models.Entity;
using Ecommerce.Models.ModelClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Models.InterfacesBAL
{
    public interface IOrderMgmtService
    {

        List<APIPOMasterModel> APIOpenOrders(int userId, int orderid, string url,string source = "Self");
        ProcessResponse SaveRefund(RazorRefundEntity request);
        List<APIPOMasterModel> APIGetAllOrders(int userId, string url,string source = "Self");
        List<POMasterModel> GetAllOpenOrders(int userId, string source = "Self");
        List<POMasterModel> GetAllClosedOrders(int userId, string source = "Self");
        List<POMasterModel> GetAllCancelledOrders(int userId, string source = "Self");

        List<POMasterModel> GetAllRetunedOrders(int userId, string source = "Self");

        ProcessResponse UpdatePOMasterStatus(POMasterEntity request);
        ProcessResponse UpdatePODetailStatus(PODetailsEntity request);

        POMasterEntity GetPoMasterbyId(int id);
        List<PODetailsEntity> GetAllPODetailsByPoId(int id);
        PODetailsEntity GetAllPODetailsById(int id);
        List<CustomizedOrderModel> GetCustomizedOrders();
        ProcessResponse UpdateCustomizedOrder(CustomizeOrderEntity request);

        CustomizeOrderEntity GetCustomizedOrderById(int id);
    }
}
