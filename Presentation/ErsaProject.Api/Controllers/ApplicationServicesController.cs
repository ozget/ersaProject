
using ErsaProject.Application.Abstractions.Services;
using ErsaProject.Application.Attributes;
using ErsaProject.Application.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ErsaProject.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   // [Authorize(AuthenticationSchemes = "Admin")]
    public class ApplicationServicesController : ControllerBase
    {
        readonly IApplicationService _applicationService;

        public ApplicationServicesController(IApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

        [HttpGet]
      //  [AuthorizeDefinition(ActionType = ActionType.Reading, Menu = "Application Services")]
        public IActionResult GetAuthorizeDefinitionEndpoints()
        {   //Authorize ile işaretlenmiş endpointleri bize getiriyor
            var datas = _applicationService.GetAuthorizeDefinitionEndpoints(typeof(Program));
            return Ok(datas);
        }
    }
}
