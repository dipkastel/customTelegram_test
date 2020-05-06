using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using alphadinCore.Common.Controllers;
using Authentication.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace alphadinCore.Areas.TesterCity.Common
{
    [Area("TesterCity")]
    public class TesterCityController : BaseController
    {
        public TesterCityController(IOnlineUserService onlineUserService) : base(onlineUserService)
        {
        }
    }
}

