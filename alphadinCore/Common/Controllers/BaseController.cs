using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using alphadinCore.Common.Filters;
using Microsoft.AspNetCore.Mvc;

namespace alphadinCore.Common.Controllers
{

    [TrackMethodsFilter]
    [ResultFixer]
    public class BaseController : ControllerBase
    {
      
    }
}