using System;

using Microsoft.AspNetCore.Mvc;

using ServicesAndDI.Services;

namespace ServicesAndDI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PopcornController : ControllerBase
    {
        private IPopcornService _service;

        public IPopcornService Service
        {
            get => _service ??= new PopcornService();
            set
            {
                if (_service is not null)
                {
                    throw new InvalidOperationException(nameof(value));
                }

                _service = value ?? throw new ArgumentNullException(nameof(value));
            }
        }

        [HttpGet]
        public IActionResult BuyPopcorn([FromQuery] PopcornSize size)
            => Ok(Service.Buy(size));
    }
}
