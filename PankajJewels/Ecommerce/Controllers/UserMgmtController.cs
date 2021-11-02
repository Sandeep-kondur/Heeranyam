using Ecommerce.Models.InterfacesBAL;
using Ecommerce.Models.ModelClasses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserMgmtController : ControllerBase
    {
        private readonly ILogger<UserMgmtController> _logger;
        private readonly INotificationService _nService;
        private readonly IUserMgmtService _uService;
        public UserMgmtController(ILogger<UserMgmtController> logger,
            INotificationService nService,
            IUserMgmtService uService)
        {
            _logger = logger;
            _nService = nService;
            _uService = uService;
        }

        [HttpPost]
        public IActionResult Login(LoginRequest request)
        {
            try
            {
                var response = _uService.LoginCheck(request);
               
                return Ok(response);
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }

        }
    }
}
