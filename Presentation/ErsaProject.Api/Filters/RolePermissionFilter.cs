
using ErsaProject.Application.Abstractions.Services;
using ErsaProject.Application.Attributes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Routing;
using System.Reflection;

namespace ErsaProject.Api.Filters
{
    public class RolePermissionFilter : IAsyncActionFilter
    {
        readonly IUserService _userService;

        public RolePermissionFilter(IUserService userService)
        {
            _userService = userService;
        }
        //kullanıcının rolü bakıyoruz,yetki kontrolü varmı, sayfaya erişebilir mi
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var name = context.HttpContext.User.Identity?.Name; //user name bilgisini alıyoruz
            if (!string.IsNullOrEmpty(name) && name != "ozge") // ozge Admin oldugu icin bu alana girmicek
            {
                var descriptor = context.ActionDescriptor as ControllerActionDescriptor; //name ismi gelmedigi icin bu şekilde yapıldı
                //action üstündeki attributlere erişiyoruz
                var attribute = descriptor.MethodInfo.GetCustomAttribute(typeof(AuthorizeDefinitionAttribute)) as AuthorizeDefinitionAttribute;

                //get,put vb 
                var httpAttribute = descriptor.MethodInfo.GetCustomAttribute(typeof(HttpMethodAttribute)) as HttpMethodAttribute;

                var code = $"{(httpAttribute != null ? httpAttribute.HttpMethods.First() : HttpMethods.Get)}.{attribute.ActionType}.{attribute.Definition.Replace(" ", "")}";

                var hasRole = await _userService.HasRolePermissionToEndpointAsync(name, code);

                if (!hasRole)// bu işlemi yapmaya yetkisi yoktur
                    context.Result = new UnauthorizedResult();
                else
                    await next();
            }
            else
                await next();
        }
    }
}
