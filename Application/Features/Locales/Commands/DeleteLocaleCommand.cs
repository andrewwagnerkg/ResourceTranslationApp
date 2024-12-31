using MediatR;

namespace Application.Features.Locales.Commands;

public class DeleteLocaleCommand: IRequest<Unit>
{
    public long Id { get; set; }
}