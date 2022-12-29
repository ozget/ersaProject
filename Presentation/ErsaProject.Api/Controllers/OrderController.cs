using ErsaProject.Application.Attributes;
using ErsaProject.Application.Consts;
using ErsaProject.Application.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ErsaProject.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Admin")]
    public class OrderController : Controller
    {
        public OrderController()
        {
        }
    
        [HttpGet]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Orders, ActionType = ActionType.Reading, Definition="Get Order")]
        public async Task<IActionResult> Get()
        {
            return Ok();
        }

        [HttpPost]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Orders, ActionType = ActionType.Writing, Definition= "Add Order")]
        public async Task<IActionResult> Add()
        {
            return Ok();
        }

        [HttpPut]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Orders, ActionType = ActionType.Updating,Definition = "Update Order")]
        public async Task<IActionResult> Update()
        {
            return Ok();
        }

        [HttpDelete("{OrderId}")]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Orders, ActionType = ActionType.Deleting, Definition= "Remove Order")]
        public async Task<IActionResult> Remove()
        {
            return Ok();
        }
    }
}
