﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Controllers
{
    public class ErrorController : Controller
    {
        private readonly ILogger<ErrorController> _logger;

        public ErrorController(ILogger<ErrorController> logger)
        {
            _logger = logger;
        }

        public IActionResult NotFoundError()
        {
            return View();
        }

        public IActionResult GenericError(int code)
        {
            _logger.LogInformation($"Error codigo {code}");
            return View();
        }
    }
}