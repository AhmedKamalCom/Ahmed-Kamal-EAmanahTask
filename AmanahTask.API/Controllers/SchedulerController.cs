using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AmanahTask.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SessionrController : BaseController
    {       

        private readonly ILogger<SessionrController> _logger;

        public SessionrController(ILogger<SessionrController> logger)
        {
            _logger = logger;
        }
        
    }
}
