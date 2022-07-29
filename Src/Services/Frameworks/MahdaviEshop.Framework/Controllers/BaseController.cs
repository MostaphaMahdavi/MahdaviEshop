using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MahdaviEshop.Framework.Controllers
{
    [ApiController]
    [Route("[controller]/[Action]")]
  //  [Authorize]
    public class BaseController : ControllerBase
    {
    }
}

