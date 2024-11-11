using MediatR;

namespace Application.Features.Autheticate.Queries
{
    public class AuthenticateQuery : IRequest<string>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
