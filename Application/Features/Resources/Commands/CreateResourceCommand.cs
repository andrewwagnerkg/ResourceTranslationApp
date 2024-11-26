using MediatR;

namespace Application.Features.Resources.Commands
{
    public class CreateResourceCommand : IRequest<long>
    {
        public string Key { get; set; }
        public string DefaultName { get; set; }
    }
}
