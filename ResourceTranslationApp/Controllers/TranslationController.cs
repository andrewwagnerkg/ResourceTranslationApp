using Application.Features.Translations.Commands;
using Application.Features.Translations.Dtos;
using Application.Features.Translations.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ResourceTranslationApp.Controllers
{
    public class TranslationController : BaseController
    {
        [HttpGet]
        [Route("")]
        public async Task<IEnumerable<TranslationDto>> GetAll([FromQuery] GetAllTranslationsQuery query) 
            => await Mediator.Send(query);

        [HttpPost]
        [Route("")]
        public async Task<Guid> Create(CreateTranslationCommand command)
            => await Mediator.Send(command);

        [HttpDelete]
        [Route("")]
        public async Task<Unit> Delete(DeleteTranslationCommand command)
            => await Mediator.Send(command);

        [HttpPatch]
        [Route("")]
        public async Task<TranslationDto> Update(UpdateTranslationCommand command)
            => await Mediator.Send(command);
    }
}
