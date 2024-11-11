using Application.Features.Autheticate.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ResourceTranslationApp.Controllers
{
    [AllowAnonymous]
    public class AuthController : BaseController
    {
        [HttpPost]
        public async Task<string> Authenticate(string username, string password)
        {
            return await Mediator.Send(new AuthenticateQuery { UserName = username, Password = password });
        }
    }
}
