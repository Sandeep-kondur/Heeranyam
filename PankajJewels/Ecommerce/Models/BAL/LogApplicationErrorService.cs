using Ecommerce.Models.Entity;
using Ecommerce.Models.InterfacesBAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Models.BAL
{
    public class LogApplicationErrorService : ILogApplicationErrorService
    {
        private readonly MyDbContext context;
        public LogApplicationErrorService(MyDbContext context)
        {
            this.context = context;
        }
        public void LogError(Exception ex)
        {
            ApplicationErrorLogEntity obj = new ApplicationErrorLogEntity();
            obj.Error = ex.Message != null ? ex.Message : "";
            obj.ExceptionDateTime = DateTime.Now;
            obj.InnerException = ex.InnerException != null ? ex.InnerException.ToString() : "";
            obj.Source = ex.Source;
            obj.Stacktrace = ex.StackTrace != null ? ex.StackTrace : "";
            context.applicationErrorLogEntities.Add(obj);
            context.SaveChanges();
        }
    }
}
