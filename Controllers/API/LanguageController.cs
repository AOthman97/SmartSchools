using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace SmartSchools.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class LanguageController : ControllerBase
    {
        private readonly IStringLocalizer<LanguageController> _Localizer;

        public LanguageController(IStringLocalizer<LanguageController> Localizer)
        {
            _Localizer = Localizer;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_Localizer["Welcome"].Value);
        }
    }
}
