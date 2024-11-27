using Microsoft.AspNetCore.Mvc;

namespace ResourceTranslationApp.Controllers
{
    public class TranslationController : BaseController
    {
        [HttpGet]
        public async Task<IEnumerable<TranslationDto>> GetAll([FromQuery] GetAllTranslationsQuery query)
        => await Mediator.Send(query);

        [HttpPost]
        public async Task<Guid> Create(CreateTranslationCommand command)
            => await Mediator.Send(command);

        [HttpDelete]
        public async Task<ActionResult> Delete([FromQuery]DeleteTranslationCommand command)
            => await Mediator.Send(command);

        [HttpPatch]
        public async Task<ActionResult> Update(UpdateTranslationCommand command)
            => await Mediator.Send(command);

        [HttpGet]
        public async Task<TranslationDto> Get([FromQuery]GetTranslationQuery query)
            => await Mediator.Send(query);
    }
}
