using Application.Interfaces;
using MediatR;

namespace Application.Features.Autheticate.Queries
{
    public class AuthenticateQueryHandler : IRequestHandler<AuthenticateQuery, string>
    {
        private readonly IJWTAuthService _jwtService;

        public AuthenticateQueryHandler(IJWTAuthService jwtService)
        {
            _jwtService = jwtService;
        }

        public async Task<string> Handle(AuthenticateQuery request, CancellationToken cancellationToken)
        {
            return await _jwtService.Authentiticate(request.UserName, request.Password);
        }
    }
}
