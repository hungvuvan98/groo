using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace web.Controllers
{
    [ApiController]
    [Authorize]
    [Route("[controller]")]
    public abstract class ApiControllerBase : ControllerBase
    {
    }
}