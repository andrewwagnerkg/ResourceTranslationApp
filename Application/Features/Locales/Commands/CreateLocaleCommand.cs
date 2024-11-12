using MediatR;

namespace Application.Features.Locales.Commands
{
    public class CreateLocaleCommand : IRequest<long>
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
}
