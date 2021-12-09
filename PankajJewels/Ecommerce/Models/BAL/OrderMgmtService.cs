using Ecommerce.Models.Entity;
using Ecommerce.Models.InterfacesBAL;
using Ecommerce.Models.ModelClasses;
using Ecommerce.Models.Utilities;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Models.BAL
{
    public class OrderMgmtService : IOrderMgmtService
    {
        private readonly MyDbContext context;
        private readonly INotificationService _nService;
        private readonly IConfiguration _config;

        public OrderMgmtService(MyDbContext context, INotificationService nService, IConfiguration config)
        {
            this.context = context;
            _nService = nService;
            _config = config;
        }


        public POMasterEntity APIRefund(int userid, string orderid) {
            POMasterEntity result = new POMasterEntity();
            try
            {
                  result = (from pom in context.pOMasterEntities.Where(x => x.UserId == userid && x.InstrumentDetails == orderid)
                              select pom
                              ).FirstOrDefault();
            }
            catch (Exception)
            {

                return new POMasterEntity();

            }
            return result;
        }


        public List<APIPOMasterModel> APIGetRefundOrders(int userId, string url, string source = "Self")
        {

            List<APIPOMasterModel> myList = new List<APIPOMasterModel>();
            try
            {
                if (source == "Self")
                {
                    myList = (from b in context.pOMasterEntities
                              join rfn in context.RazorRefundEntities on b.InstrumentDetails equals rfn.order_id
                              join u in context.userMasters on b.UserId equals u.UserId


                              where b.UserId == userId && b.IsDeleted == false &&
                   AppSettings.OpenOrderStatus.Contains(b.OrderStatus)
                              select new APIPOMasterModel
                              {
                                  CartId = b.CartId,
                                  UserId = b.UserId,
                                  CreatedOn = b.CreatedOn,
                                  CurrentStatus = b.CurrentStatus,
                                  InstrumentDetails = b.InstrumentDetails,
                                  IsDeleted = b.IsDeleted,
                                  OrderStatus = b.OrderStatus,
                                  PaidAmount = b.PaidAmount,
                                  PaidDate = b.PaidDate,
                                  PaymentMethod = b.PaymentMethod,
                                  POId = b.POId,
                                  PONumber = b.PONumber,
                                  RefundedAmount = b.RefundedAmount,
                                  RefundedOn = b.RefundedOn,
                                  TransactionId = b.TransactionId,
                                  OrderAmount = b.OrderAmount,
                                  BankCharges = b.BankCharges,
                                  BankTaxes = b.BankTaxes,
                                  Taxes = b.Taxes,
                                  // UserAddress = ad.Address1 + ", " + c.CityName + "," + s.StateName + ", " + ad.ZipCode,
                                  UserMobile = u.MobileNumber,
                                  UserName = u.UserName,

                                  Address = context.addressEntities.Where(a => a.UserId == userId && a.IsDeleted == false && a.IsDeliverAddress == "YES")
                      .Select(b => new AddressModel
                      {
                          UserId = b.UserId.GetValueOrDefault(),
                          Address1 = b.Address1,
                          Address2 = b.Address2,
                          AddressTypeId = b.AddressTypeId,
                          CityId = b.CityId != null ? b.CityId : 0,
                          CountryId = b.CountryId != null ? b.CountryId : 0,
                          Id = b.Id,
                          LandMark = b.LandMark,
                          LocationStreet = b.LocationStreet != null ? b.LocationStreet : string.Empty,
                          StateId = b.StateId != null ? b.StateId : 0,
                          ZipCode = b.ZipCode != null ? b.ZipCode : string.Empty,
                          IsDeliverAddress = b.IsDeliverAddress != null ? b.IsDeliverAddress : string.Empty

                      })
                      .FirstOrDefault()
                              }).ToList();
                }
                else
                {
                    myList = (from b in context.pOMasterEntities
                              join rfn in context.RazorRefundEntities on b.InstrumentDetails equals rfn.order_id
                              join u in context.userMasters on b.UserId equals u.UserId
                              join ad in context.addressEntities on u.UserId equals ad.UserId
                              where ad.IsDeliverAddress == "Yes"
                              join c in context.cityMasterEntities on ad.CityId equals c.Id
                              join s in context.stateMasterEntities on ad.StateId equals s.Id
                              where b.IsDeleted == false && AppSettings.OpenOrderStatus.Contains(b.OrderStatus)
                              select new APIPOMasterModel
                              {


                                  CartId = b.CartId,
                                  UserId = b.UserId,
                                  CreatedOn = b.CreatedOn,
                                  CurrentStatus = b.CurrentStatus,
                                  InstrumentDetails = b.InstrumentDetails,
                                  IsDeleted = b.IsDeleted,
                                  OrderStatus = b.OrderStatus,
                                  PaidAmount = b.PaidAmount,
                                  PaidDate = b.PaidDate,
                                  PaymentMethod = b.PaymentMethod,
                                  POId = b.POId,
                                  PONumber = b.PONumber,
                                  RefundedAmount = b.RefundedAmount,
                                  RefundedOn = b.RefundedOn,
                                  TransactionId = b.TransactionId,
                                  OrderAmount = b.OrderAmount,
                                  BankCharges = b.BankCharges,
                                  BankTaxes = b.BankTaxes,
                                  Taxes = b.Taxes,
                                  UserAddress = ad.Address1 + ", " + c.CityName + "," + s.StateName + ", " + ad.ZipCode,
                                  UserMobile = u.MobileNumber,
                                  UserName = u.UserName
                              }).ToList();
                }
                if (myList.Count > 0)
                {
                    for (int i = 0; i < myList.Count; i++)
                    {
                        int currentPOMId = myList[i].POId;
                        List<APIPODetailsModel> pd = new List<APIPODetailsModel>();
                        var result = (from poD in context.pODetails
                                      join pdt in context.productMasterEntities on poD.ProductId equals pdt.ProductId
                                      where poD.POMasterId == currentPOMId && poD.IsDeleted == false
                                      select new APIPODetailsModel
                                      {
                                          AddedOn = poD.AddedOn,
                                          CurrentStatus = poD.CurrentStatus,
                                          IsDeleted = poD.IsDeleted,
                                          DaimondPrice = poD.DaimondPrice,
                                          Discount = poD.Discount,
                                          GoldPrice = poD.GoldPrice,
                                          GoldRate = poD.GoldRate,
                                          GoldWeight = poD.GoldWeight,
                                          GST = poD.GST,
                                          MakingCharges = poD.MakingCharges,
                                          MetalMasterId = poD.MetalMasterId,
                                          MetalMasterId_Name = poD.MetalMasterId_Name,
                                          NumberOfItems = poD.NumberOfItems,
                                          OldPrice = poD.OldPrice,
                                          PODetailId = poD.PODetailId,
                                          ProductDetailId = poD.ProductDetailId,
                                          ProductId = poD.ProductId,
                                          SizeId = poD.SizeId,
                                          SizeName = poD.SizeName,
                                          TotalPrice = poD.TotalPrice,
                                          ProductName = pdt.ProductTitle,
                                          ImageURL = url + context.productImagesEntities.Where(a => a.IsDeleted == false && a.ProductId == pdt.ProductId).Select(b => b.ImageUrl).FirstOrDefault()

                                      }).ToList();
                        myList[i].APIpoDetails = result;
                    }

                }

            }
            catch (Exception ex)
            {

            }
            return myList;

        }

        public List<APIPOMasterModel> APIOpenOrders(int userId, int orderid,string url,string source = "Self")
        {

                  List<APIPOMasterModel> myList = new List<APIPOMasterModel>();
            try
            {
                if (source == "Self")
                {
                    myList =  (from b in context.pOMasterEntities join u in context.userMasters on b.UserId equals u.UserId
                 
                             
                               where                b.UserId == userId && b.IsDeleted == false && b.POId==orderid &&
                    AppSettings.OpenOrderStatus.Contains(b.OrderStatus)
                               select new APIPOMasterModel
                               {
                                   CartId = b.CartId,
                                   UserId = b.UserId,
                                   CreatedOn = b.CreatedOn,
                                   CurrentStatus = b.CurrentStatus,
                                   InstrumentDetails = b.InstrumentDetails,
                                   IsDeleted = b.IsDeleted,
                                   OrderStatus = b.OrderStatus,
                                   PaidAmount = b.PaidAmount,
                                   PaidDate = b.PaidDate,
                                   PaymentMethod = b.PaymentMethod,
                                   POId = b.POId,
                                   PONumber = b.PONumber,
                                   RefundedAmount = b.RefundedAmount,
                                   RefundedOn = b.RefundedOn,
                                   TransactionId = b.TransactionId,
                                   OrderAmount = b.OrderAmount,
                                   BankCharges = b.BankCharges,
                                   BankTaxes = b.BankTaxes,
                                   Taxes = b.Taxes,
                                  // UserAddress = ad.Address1 + ", " + c.CityName + "," + s.StateName + ", " + ad.ZipCode,
                                   UserMobile = u.MobileNumber,
                                   UserName = u.UserName,

                                    Address = context.addressEntities.Where(a => a.UserId == userId && a.IsDeleted == false && a.IsDeliverAddress == "YES")
                       .Select(b => new AddressModel
                       {
                           UserId = b.UserId.GetValueOrDefault(),
                           Address1 = b.Address1,
                           Address2 = b.Address2,
                           AddressTypeId = b.AddressTypeId,
                           CityId = b.CityId != null ? b.CityId : 0,
                           CountryId = b.CountryId != null ? b.CountryId : 0,
                           Id = b.Id,
                           LandMark = b.LandMark,
                           LocationStreet = b.LocationStreet != null ? b.LocationStreet : string.Empty,
                           StateId = b.StateId != null ? b.StateId : 0,
                           ZipCode = b.ZipCode != null ? b.ZipCode : string.Empty,
                           IsDeliverAddress = b.IsDeliverAddress != null ? b.IsDeliverAddress : string.Empty

                       })
                       .FirstOrDefault()
                               }).ToList();
                }
                else
                {
                    myList = (from b in context.pOMasterEntities
                              join u in context.userMasters on b.UserId equals u.UserId
                              join ad in context.addressEntities on u.UserId equals ad.UserId
                              where ad.IsDeliverAddress == "Yes"
                              join c in context.cityMasterEntities on ad.CityId equals c.Id
                              join s in context.stateMasterEntities on ad.StateId equals s.Id
                              where b.IsDeleted == false && AppSettings.OpenOrderStatus.Contains(b.OrderStatus)
                              select new APIPOMasterModel
                              {


                                  CartId = b.CartId,
                                  UserId = b.UserId,
                                  CreatedOn = b.CreatedOn,
                                  CurrentStatus = b.CurrentStatus,
                                  InstrumentDetails = b.InstrumentDetails,
                                  IsDeleted = b.IsDeleted,
                                  OrderStatus = b.OrderStatus,
                                  PaidAmount = b.PaidAmount,
                                  PaidDate = b.PaidDate,
                                  PaymentMethod = b.PaymentMethod,
                                  POId = b.POId,
                                  PONumber = b.PONumber,
                                  RefundedAmount = b.RefundedAmount,
                                  RefundedOn = b.RefundedOn,
                                  TransactionId = b.TransactionId,
                                  OrderAmount = b.OrderAmount,
                                  BankCharges = b.BankCharges,
                                  BankTaxes = b.BankTaxes,
                                  Taxes = b.Taxes,
                                  UserAddress = ad.Address1 + ", " + c.CityName + "," + s.StateName + ", " + ad.ZipCode,
                                  UserMobile = u.MobileNumber,
                                  UserName = u.UserName
                              }).ToList();
                }
                if (myList.Count > 0)
                {
                    for (int i = 0; i < myList.Count; i++)
                    {
                        int currentPOMId = myList[i].POId;
                        List<APIPODetailsModel> pd = new List<APIPODetailsModel>();
                        var result = (from poD in context.pODetails
                                      join pdt in context.productMasterEntities on poD.ProductId equals pdt.ProductId
                                      where poD.POMasterId == currentPOMId && poD.IsDeleted == false
                                      select new APIPODetailsModel
                                      {
                                          AddedOn = poD.AddedOn,
                                          CurrentStatus = poD.CurrentStatus,
                                          IsDeleted = poD.IsDeleted,
                                          DaimondPrice = poD.DaimondPrice,
                                          Discount = poD.Discount,
                                          GoldPrice = poD.GoldPrice,
                                          GoldRate = poD.GoldRate,
                                          GoldWeight = poD.GoldWeight,
                                          GST = poD.GST,
                                          MakingCharges = poD.MakingCharges,
                                          MetalMasterId = poD.MetalMasterId,
                                          MetalMasterId_Name = poD.MetalMasterId_Name,
                                          NumberOfItems = poD.NumberOfItems,
                                          OldPrice = poD.OldPrice,
                                          PODetailId = poD.PODetailId,
                                          ProductDetailId = poD.ProductDetailId,
                                          ProductId = poD.ProductId,
                                          SizeId = poD.SizeId,
                                          SizeName = poD.SizeName,
                                          TotalPrice = poD.TotalPrice,
                                          ProductName = pdt.ProductTitle,
                                          ImageURL = url + context.productImagesEntities.Where(a => a.IsDeleted == false && a.ProductId == pdt.ProductId).Select(b => b.ImageUrl).FirstOrDefault()

                                      }).ToList();
                        myList[i].APIpoDetails = result;
                    }

                }

            }
            catch (Exception ex)
            {

            }
            return myList;

        }

        public List<APIPOMasterModel> APIGetAllOrders(int userId,string url, string source = "Self")
        {
            List<APIPOMasterModel> myList = new List<APIPOMasterModel>();
            try
            {
                if (source == "Self")
                {
                    myList = context.pOMasterEntities.Where(a => a.UserId == userId && a.IsDeleted == false)
                        .Select(b => new APIPOMasterModel
                        {
                            CartId = b.CartId,
                            UserId = b.UserId,
                            CreatedOn = b.CreatedOn,
                            CurrentStatus = b.CurrentStatus,
                            InstrumentDetails = b.InstrumentDetails,
                            IsDeleted = b.IsDeleted,
                            OrderStatus = b.OrderStatus,
                            PaidAmount = b.PaidAmount,
                            PaidDate = b.PaidDate,
                            PaymentMethod = b.PaymentMethod,
                            POId = b.POId,
                            PONumber = b.PONumber,
                            RefundedAmount = b.RefundedAmount,
                            RefundedOn = b.RefundedOn,
                            TransactionId = b.TransactionId,
                            OrderAmount = b.OrderAmount,
                            BankCharges = b.BankCharges,
                            BankTaxes = b.BankTaxes,
                            Taxes = b.Taxes
                        }).ToList();
                }
                else
                {
                    myList = (from b in context.pOMasterEntities
                              join u in context.userMasters on b.UserId equals u.UserId
                              join ad in context.addressEntities on u.UserId equals ad.UserId
                              where ad.IsDeliverAddress == "Yes"
                              join c in context.cityMasterEntities on ad.CityId equals c.Id
                              join s in context.stateMasterEntities on ad.StateId equals s.Id
                              where b.IsDeleted == false && AppSettings.OpenOrderStatus.Contains(b.OrderStatus)
                              select new APIPOMasterModel
                              {


                                  CartId = b.CartId,
                                  UserId = b.UserId,
                                  CreatedOn = b.CreatedOn,
                                  CurrentStatus = b.CurrentStatus,
                                  InstrumentDetails = b.InstrumentDetails,
                                  IsDeleted = b.IsDeleted,
                                  OrderStatus = b.OrderStatus,
                                  PaidAmount = b.PaidAmount,
                                  PaidDate = b.PaidDate,
                                  PaymentMethod = b.PaymentMethod,
                                  POId = b.POId,
                                  PONumber = b.PONumber,
                                  RefundedAmount = b.RefundedAmount,
                                  RefundedOn = b.RefundedOn,
                                  TransactionId = b.TransactionId,
                                  OrderAmount = b.OrderAmount,
                                  BankCharges = b.BankCharges,
                                  BankTaxes = b.BankTaxes,
                                  Taxes = b.Taxes,
                                  UserAddress = ad.Address1 + ", " + c.CityName + "," + s.StateName + ", " + ad.ZipCode,
                                  UserMobile = u.MobileNumber,
                                  UserName = u.UserName
                              }).ToList();
                }
                if (myList.Count > 0)
                {
                    for (int i = 0; i < myList.Count; i++)
                    {
                        int currentPOMId = myList[i].POId;
                        List<APIPODetailsModel> pd = new List<APIPODetailsModel>();
                        var result = (from poD in context.pODetails
                                      join pdt in context.productMasterEntities on poD.ProductId equals pdt.ProductId
                                      where poD.POMasterId == currentPOMId && poD.IsDeleted == false
                                      select new APIPODetailsModel
                                      {
                                          AddedOn = poD.AddedOn,
                                          CurrentStatus = poD.CurrentStatus,
                                          IsDeleted = poD.IsDeleted,
                                          DaimondPrice = poD.DaimondPrice,
                                          Discount = poD.Discount,
                                          GoldPrice = poD.GoldPrice,
                                          GoldRate = poD.GoldRate,
                                          GoldWeight = poD.GoldWeight,
                                          GST = poD.GST,
                                          MakingCharges = poD.MakingCharges,
                                          MetalMasterId = poD.MetalMasterId,
                                          MetalMasterId_Name = poD.MetalMasterId_Name,
                                          NumberOfItems = poD.NumberOfItems,
                                          OldPrice = poD.OldPrice,
                                          PODetailId = poD.PODetailId,
                                          ProductDetailId = poD.ProductDetailId,
                                          ProductId = poD.ProductId,
                                          SizeId = poD.SizeId,
                                          SizeName = poD.SizeName,
                                          TotalPrice = poD.TotalPrice,
                                          ProductName = pdt.ProductTitle,
                                          ImageURL = url+context.productImagesEntities.Where(a => a.IsDeleted == false && a.ProductId == pdt.ProductId).Select(b => b.ImageUrl).FirstOrDefault()

                                      }).ToList();
                        myList[i].APIpoDetails = result;
                    }

                }

            }
            catch (Exception ex)
            {

            }
            return myList;
        }


        public ProcessResponse SaveRefund(RazorRefundEntity request) {

            ProcessResponse response = new ProcessResponse();
            response.statusCode = 0;
            response.statusMessage = "Failed to update";
            try
            {
                
                {
                 var   po = context.pOMasterEntities.Where(a => a.InstrumentDetails == request.order_id).FirstOrDefault();
                    if (po!=null)
                    {
                        request.POID = po.POId;
                    }
                    context.RazorRefundEntities.Add(request);
                    context.SaveChanges();
                }

                response.statusMessage = "success";
                response.statusCode = 1;
                 
            }
            catch (Exception ex)
            {
                response.statusCode = 0;
                response.statusMessage = "Failed to save";
            }
            return response;

        }
        public List<POMasterModel> GetAllOpenOrders(int userId, string source="Self")
        {
            List<POMasterModel> myList = new List<POMasterModel>();
            try
            {
                if(source == "Self")
                {
                    myList = context.pOMasterEntities.Where(a => a.UserId == userId && a.IsDeleted == false &&
                    AppSettings.OpenOrderStatus.Contains(a.OrderStatus))
                        .Select(b => new POMasterModel
                        {
                            CartId = b.CartId,
                            UserId = b.UserId,
                            CreatedOn = b.CreatedOn,
                            CurrentStatus = b.CurrentStatus,
                            InstrumentDetails = b.InstrumentDetails,
                            IsDeleted = b.IsDeleted,
                            OrderStatus = b.OrderStatus,
                            PaidAmount = b.PaidAmount,
                            PaidDate = b.PaidDate,
                            PaymentMethod = b.PaymentMethod,
                            POId = b.POId,
                            PONumber = b.PONumber,
                            RefundedAmount = b.RefundedAmount,
                            RefundedOn = b.RefundedOn,
                            TransactionId = b.TransactionId,
                             OrderAmount = b.OrderAmount,
                              BankCharges = b.BankCharges, 
                               BankTaxes=b.BankTaxes, 
                                 Taxes = b.Taxes
                        }).ToList();
                }
                else
                {
                    myList = (from b in context.pOMasterEntities
                              join u in context.userMasters on b.UserId equals u.UserId
                              join ad in context.addressEntities on u.UserId equals ad.UserId where ad.IsDeliverAddress == "Yes"
                              join c in context.cityMasterEntities on ad.CityId equals c.Id
                              join s in context.stateMasterEntities on ad.StateId equals s.Id
                              where b.IsDeleted == false && AppSettings.OpenOrderStatus.Contains(b.OrderStatus)
                              select new POMasterModel
                              {


                                  CartId = b.CartId,
                                  UserId = b.UserId,
                                  CreatedOn = b.CreatedOn,
                                  CurrentStatus = b.CurrentStatus,
                                  InstrumentDetails = b.InstrumentDetails,
                                  IsDeleted = b.IsDeleted,
                                  OrderStatus = b.OrderStatus,
                                  PaidAmount = b.PaidAmount,
                                  PaidDate = b.PaidDate,
                                  PaymentMethod = b.PaymentMethod,
                                  POId = b.POId,
                                  PONumber = b.PONumber,
                                  RefundedAmount = b.RefundedAmount,
                                  RefundedOn = b.RefundedOn,
                                  TransactionId = b.TransactionId,
                                  OrderAmount = b.OrderAmount,
                                  BankCharges = b.BankCharges,
                                  BankTaxes = b.BankTaxes,
                                  Taxes = b.Taxes,
                                  UserAddress = ad.Address1 + ", " + c.CityName + "," + s.StateName + ", " + ad.ZipCode,
                                  UserMobile = u.MobileNumber, UserName = u.UserName
                              }).ToList();
                }
                if(myList.Count > 0)
                {
                    for(int i=0;i < myList.Count; i ++)
                    {
                        int currentPOMId = myList[i].POId;
                        List<PODetailsModel> pd = new List<PODetailsModel>();
                        pd = context.pODetails.Where(a => a.POMasterId == currentPOMId && 
                        a.IsDeleted == false )
                            .Select(b => new PODetailsModel
                            {
                                AddedOn = b.AddedOn,
                                CurrentStatus = b.CurrentStatus,
                                IsDeleted = b.IsDeleted,
                                DaimondPrice = b.DaimondPrice,
                                Discount = b.Discount,
                                GoldPrice = b.GoldPrice,
                                GoldRate = b.GoldRate,
                                GoldWeight = b.GoldWeight,
                                GST = b.GST,
                                MakingCharges = b.MakingCharges,
                                MetalMasterId = b.MetalMasterId,
                                MetalMasterId_Name = b.MetalMasterId_Name,
                                NumberOfItems = b.NumberOfItems,
                                OldPrice = b.OldPrice,
                                PODetailId = b.PODetailId,
                                ProductDetailId = b.ProductDetailId,
                                ProductId = b.ProductId,
                                SizeId = b.SizeId,
                                SizeName = b.SizeName,
                                TotalPrice = b.TotalPrice

                            }).ToList();
                        myList[i].poDetails = pd;
                    }

                }
                
            }
            catch(Exception ex)
            {

            }
            return myList;
        }
        public List<POMasterModel> GetAllClosedOrders(int userId, string source = "Self")
        {
            List<POMasterModel> myList = new List<POMasterModel>();
            try
            {
                if (source == "self")
                {
                    myList = context.pOMasterEntities.Where(a => a.UserId == userId && a.IsDeleted == false &&
                    a.OrderStatus == "Closed")
                        .Select(b => new POMasterModel
                        {
                            CartId = b.CartId,
                            UserId = b.UserId,
                            CreatedOn = b.CreatedOn,
                            CurrentStatus = b.CurrentStatus,
                            InstrumentDetails = b.InstrumentDetails,
                            IsDeleted = b.IsDeleted,
                            OrderStatus = b.OrderStatus,
                            PaidAmount = b.PaidAmount,
                            PaidDate = b.PaidDate,
                            PaymentMethod = b.PaymentMethod,
                            POId = b.POId,
                            PONumber = b.PONumber,
                            RefundedAmount = b.RefundedAmount,
                            RefundedOn = b.RefundedOn,
                            TransactionId = b.TransactionId,
                            Taxes = b.Taxes, BankTaxes = b.BankTaxes,
                            BankCharges = b.BankCharges, 
                            
                        }).ToList();
                }
                else
                {
                    myList = (from b in context.pOMasterEntities
                              join u in context.userMasters on b.UserId equals u.UserId
                              join ad in context.addressEntities on u.UserId equals ad.UserId
                              where ad.IsDeliverAddress == "Yes"
                              join c in context.cityMasterEntities on ad.CityId equals c.Id
                              join s in context.stateMasterEntities on ad.StateId equals s.Id
                              where b.IsDeleted == false && b.OrderStatus == "Closed"
                              select new POMasterModel
                              {


                                  CartId = b.CartId,
                                  UserId = b.UserId,
                                  CreatedOn = b.CreatedOn,
                                  CurrentStatus = b.CurrentStatus,
                                  InstrumentDetails = b.InstrumentDetails,
                                  IsDeleted = b.IsDeleted,
                                  OrderStatus = b.OrderStatus,
                                  PaidAmount = b.PaidAmount,
                                  PaidDate = b.PaidDate,
                                  PaymentMethod = b.PaymentMethod,
                                  POId = b.POId,
                                  PONumber = b.PONumber,
                                  RefundedAmount = b.RefundedAmount,
                                  RefundedOn = b.RefundedOn,
                                  TransactionId = b.TransactionId,
                                  UserAddress = ad.Address1 + ", " + c.CityName + "," + s.StateName + ", " + ad.ZipCode,
                                  UserMobile = u.MobileNumber,
                                  UserName = u.UserName
                              }).ToList();
                }
                if (myList.Count > 0)
                {
                    for (int i = 0; i < myList.Count; i++)
                    {
                        int currentPOMId = myList[i].POId;
                        List<PODetailsModel> pd = new List<PODetailsModel>();
                        pd = context.pODetails.Where(a => a.POMasterId == currentPOMId &&
                        a.IsDeleted == false )
                            .Select(b => new PODetailsModel
                            {
                                AddedOn = b.AddedOn,
                                CurrentStatus = b.CurrentStatus,
                                IsDeleted = b.IsDeleted,
                                DaimondPrice = b.DaimondPrice,
                                Discount = b.Discount,
                                GoldPrice = b.GoldPrice,
                                GoldRate = b.GoldRate,
                                GoldWeight = b.GoldWeight,
                                GST = b.GST,
                                MakingCharges = b.MakingCharges,
                                MetalMasterId = b.MetalMasterId,
                                MetalMasterId_Name = b.MetalMasterId_Name,
                                NumberOfItems = b.NumberOfItems,
                                OldPrice = b.OldPrice,
                                PODetailId = b.PODetailId,
                                ProductDetailId = b.ProductDetailId,
                                ProductId = b.ProductId,
                                SizeId = b.SizeId,
                                SizeName = b.SizeName,
                                TotalPrice = b.TotalPrice
                            }).ToList();
                        myList[i].poDetails = pd;
                    }

                }

            }
            catch (Exception ex)
            {

            }
            return myList;
        }
        public List<POMasterModel> GetAllCancelledOrders(int userId, string source = "Self")
        {
            List<POMasterModel> myList = new List<POMasterModel>();
            try
            {
                if (source == "self")
                {
                    myList = context.pOMasterEntities.Where(a => a.UserId == userId && a.IsDeleted == false &&
                    a.OrderStatus == "Cancelled")
                        .Select(b => new POMasterModel
                        {
                            CartId = b.CartId,
                            UserId = b.UserId,
                            CreatedOn = b.CreatedOn,
                            CurrentStatus = b.CurrentStatus,
                            InstrumentDetails = b.InstrumentDetails,
                            IsDeleted = b.IsDeleted,
                            OrderStatus = b.OrderStatus,
                            PaidAmount = b.PaidAmount,
                            PaidDate = b.PaidDate,
                            PaymentMethod = b.PaymentMethod,
                            POId = b.POId,
                            PONumber = b.PONumber,
                            RefundedAmount = b.RefundedAmount,
                            RefundedOn = b.RefundedOn,
                            TransactionId = b.TransactionId
                        }).ToList();
                }
                else
                {
                    myList = (from b in context.pOMasterEntities
                              join u in context.userMasters on b.UserId equals u.UserId
                              join ad in context.addressEntities on u.UserId equals ad.UserId
                              where ad.IsDeliverAddress == "Yes"
                              join c in context.cityMasterEntities on ad.CityId equals c.Id
                              join s in context.stateMasterEntities on ad.StateId equals s.Id
                              where b.IsDeleted == false && b.OrderStatus == "Cancelled"
                              select new POMasterModel
                              {


                                  CartId = b.CartId,
                                  UserId = b.UserId,
                                  CreatedOn = b.CreatedOn,
                                  CurrentStatus = b.CurrentStatus,
                                  InstrumentDetails = b.InstrumentDetails,
                                  IsDeleted = b.IsDeleted,
                                  OrderStatus = b.OrderStatus,
                                  PaidAmount = b.PaidAmount,
                                  PaidDate = b.PaidDate,
                                  PaymentMethod = b.PaymentMethod,
                                  POId = b.POId,
                                  PONumber = b.PONumber,
                                  RefundedAmount = b.RefundedAmount,
                                  RefundedOn = b.RefundedOn,
                                  TransactionId = b.TransactionId,
                                  UserAddress = ad.Address1 + ", " + c.CityName + "," + s.StateName + ", " + ad.ZipCode,
                                  UserMobile = u.MobileNumber,
                                  UserName = u.UserName
                              }).ToList();
                }
                if (myList.Count > 0)
                {
                    for (int i = 0; i < myList.Count; i++)
                    {
                        int currentPOMId = myList[i].POId;
                        List<PODetailsModel> pd = new List<PODetailsModel>();
                        pd = context.pODetails.Where(a => a.POMasterId == currentPOMId &&
                        a.IsDeleted == false)
                            .Select(b => new PODetailsModel
                            {
                                AddedOn = b.AddedOn,
                                CurrentStatus = b.CurrentStatus,
                                IsDeleted = b.IsDeleted,
                                DaimondPrice = b.DaimondPrice,
                                Discount = b.Discount,
                                GoldPrice = b.GoldPrice,
                                GoldRate = b.GoldRate,
                                GoldWeight = b.GoldWeight,
                                GST = b.GST,
                                MakingCharges = b.MakingCharges,
                                MetalMasterId = b.MetalMasterId,
                                MetalMasterId_Name = b.MetalMasterId_Name,
                                NumberOfItems = b.NumberOfItems,
                                OldPrice = b.OldPrice,
                                PODetailId = b.PODetailId,
                                ProductDetailId = b.ProductDetailId,
                                ProductId = b.ProductId,
                                SizeId = b.SizeId,
                                SizeName = b.SizeName,
                                TotalPrice = b.TotalPrice
                            }).ToList();
                        myList[i].poDetails = pd;
                    }

                }

            }
            catch (Exception ex)
            {

            }
            return myList;
        }

        public List<POMasterModel> GetAllRetunedOrders(int userId, string source = "Self")
        {
            List<POMasterModel> myList = new List<POMasterModel>();
            try
            {
                if (source == "self")
                {
                    myList = context.pOMasterEntities.Where(a => a.UserId == userId && a.IsDeleted == false &&
                    a.OrderStatus == "Returned")
                        .Select(b => new POMasterModel
                        {
                            CartId = b.CartId,
                            UserId = b.UserId,
                            CreatedOn = b.CreatedOn,
                            CurrentStatus = b.CurrentStatus,
                            InstrumentDetails = b.InstrumentDetails,
                            IsDeleted = b.IsDeleted,
                            OrderStatus = b.OrderStatus,
                            PaidAmount = b.PaidAmount,
                            PaidDate = b.PaidDate,
                            PaymentMethod = b.PaymentMethod,
                            POId = b.POId,
                            PONumber = b.PONumber,
                            RefundedAmount = b.RefundedAmount,
                            RefundedOn = b.RefundedOn,
                            TransactionId = b.TransactionId
                        }).ToList();
                }
                else
                {
                    myList = (from b in context.pOMasterEntities
                              join u in context.userMasters on b.UserId equals u.UserId
                              join ad in context.addressEntities on u.UserId equals ad.UserId
                              where ad.IsDeliverAddress == "Yes"
                              join c in context.cityMasterEntities on ad.CityId equals c.Id
                              join s in context.stateMasterEntities on ad.StateId equals s.Id
                              where b.IsDeleted == false && b.OrderStatus == "Returned"
                              select new POMasterModel
                              {


                                  CartId = b.CartId,
                                  UserId = b.UserId,
                                  CreatedOn = b.CreatedOn,
                                  CurrentStatus = b.CurrentStatus,
                                  InstrumentDetails = b.InstrumentDetails,
                                  IsDeleted = b.IsDeleted,
                                  OrderStatus = b.OrderStatus,
                                  PaidAmount = b.PaidAmount,
                                  PaidDate = b.PaidDate,
                                  PaymentMethod = b.PaymentMethod,
                                  POId = b.POId,
                                  PONumber = b.PONumber,
                                  RefundedAmount = b.RefundedAmount,
                                  RefundedOn = b.RefundedOn,
                                  TransactionId = b.TransactionId,
                                  UserAddress = ad.Address1 + ", " + c.CityName + "," + s.StateName + ", " + ad.ZipCode,
                                  UserMobile = u.MobileNumber,
                                  UserName = u.UserName
                              }).ToList();
                }
                if (myList.Count > 0)
                {
                    for (int i = 0; i < myList.Count; i++)
                    {
                        int currentPOMId = myList[i].POId;
                        List<PODetailsModel> pd = new List<PODetailsModel>();
                        pd = context.pODetails.Where(a => a.POMasterId == currentPOMId &&
                        a.IsDeleted == false)
                            .Select(b => new PODetailsModel
                            {
                                AddedOn = b.AddedOn,
                                CurrentStatus = b.CurrentStatus,
                                IsDeleted = b.IsDeleted,
                                DaimondPrice = b.DaimondPrice,
                                Discount = b.Discount,
                                GoldPrice = b.GoldPrice,
                                GoldRate = b.GoldRate,
                                GoldWeight = b.GoldWeight,
                                GST = b.GST,
                                MakingCharges = b.MakingCharges,
                                MetalMasterId = b.MetalMasterId,
                                MetalMasterId_Name = b.MetalMasterId_Name,
                                NumberOfItems = b.NumberOfItems,
                                OldPrice = b.OldPrice,
                                PODetailId = b.PODetailId,
                                ProductDetailId = b.ProductDetailId,
                                ProductId = b.ProductId,
                                SizeId = b.SizeId,
                                SizeName = b.SizeName,
                                TotalPrice = b.TotalPrice
                            }).ToList();
                        myList[i].poDetails = pd;
                    }

                }

            }
            catch (Exception ex)
            {

            }
            return myList;
        }

        public ProcessResponse UpdatePOMasterStatus(POMasterEntity request)
        {
            ProcessResponse response = new ProcessResponse();
            response.statusCode = 0;
            response.statusMessage = "Failed to update";
            try
            {
                POMasterEntity tempObj = new POMasterEntity();
                tempObj = context.pOMasterEntities.Where(a => a.POId == request.POId).FirstOrDefault();
                context.Entry(tempObj).CurrentValues.SetValues(request);
                context.SaveChanges();
                response.statusMessage = "success";
                response.statusCode = 1;
                response.currentId = request.POId;
            }
            catch (Exception ex)
            {
                response.statusCode = 0;
                response.statusMessage = "Failed to save";
            }
            return response;
        }
        public ProcessResponse UpdatePODetailStatus(PODetailsEntity request)
        {
            ProcessResponse response = new ProcessResponse();
            response.statusCode = 0;
            response.statusMessage = "Failed to update";
            try
            {
                PODetailsEntity tempObj = new PODetailsEntity();
                tempObj = context.pODetails.Where(a => a.PODetailId == request.PODetailId).FirstOrDefault();
                context.Entry(tempObj).CurrentValues.SetValues(request);
                context.SaveChanges();
                response.statusMessage = "success";
                response.statusCode = 1;
                response.currentId = request.PODetailId;
            }
            catch (Exception ex)
            {
                response.statusCode = 0;
                response.statusMessage = "Failed to save";
            }
            return response;
        }

        public POMasterEntity GetPoMasterbyId(int id)
        {
            return context.pOMasterEntities.Where(a => a.POId == id).FirstOrDefault();
        }
        public List<PODetailsEntity> GetAllPODetailsByPoId(int id)
        {
            return context.pODetails.Where(a => a.IsDeleted == false && a.POMasterId == id).ToList();
        }
        public PODetailsEntity GetAllPODetailsById(int id)
        {
            return context.pODetails.Where(a => a.IsDeleted == false && a.PODetailId == id).FirstOrDefault(); 
        }

        public List<CustomizedOrderModel> GetCustomizedOrders()
        {
            List<CustomizedOrderModel> myList = new List<CustomizedOrderModel>();
            myList = (from c in context.customizeOrderEntities
                      where c.IsDeleted == false
                      select new CustomizedOrderModel {
                          IsDeleted = c.IsDeleted,
                          CurrentStatus = c.CurrentStatus,
                          CustomerAddress = c.CustomerAddress,
                          CustomerMobile = c.CustomerMobile,
                          CustomerName = c.CustomerName,
                          CustomerRequirements = c.CustomerRequirements,
                          OrderId = c.OrderId,
                          ProductDetailId = c.ProductDetailId,
                          ProductId = c.ProductId,
                          ProductImage = context.productImagesEntities.Where(a => a.IsDeleted == false && a.ProductId == c.ProductId).Select(b => b.ImageUrl).FirstOrDefault(),
                          RequestedOn = c.RequestedOn,
                          UserId = c.UserId
                      }).ToList();

            return myList;

        }
        public ProcessResponse UpdateCustomizedOrder(CustomizeOrderEntity request)
        {
            ProcessResponse response = new ProcessResponse();
            response.statusCode = 0;
            response.statusMessage = "Failed to update";
            try
            {
                if(request.OrderId > 0)
                {
                    context.Entry(request).CurrentValues.SetValues(request);
                    context.SaveChanges();
                }
                else
                {
                    context.customizeOrderEntities.Add(request);
                    context.SaveChanges();
                }

                response.statusMessage = "success";
                response.statusCode = 1;
                response.currentId = request.OrderId;
            }
            catch (Exception ex)
            {
                response.statusCode = 0;
                response.statusMessage = "Failed to save";
            }
            return response;
        }

        public CustomizeOrderEntity GetCustomizedOrderById(int id)
        {
            return context.customizeOrderEntities.Where(a => a.OrderId == id).FirstOrDefault();
        }
    }
}
