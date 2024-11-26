using Application.Features.Resources.Commands;
using Application.Features.Resources.Dtos;
using Application.Features.Resources.Queries;
using Microsoft.AspNetCore.Mvc;

namespace ResourceTranslationApp.Controllers
{
    public class ResourcesController : BaseController
    {
        [HttpGet]
        public async Task<IEnumerable<ResourceDto>> GetAll([FromQuery]GetAllResourcesQuery query)
            => await Mediator.Send(query);

        [HttpPost]
        public async Task<long> CreateResource(CreateResourceCommand createCommand)
            => await Mediator.Send(createCommand);
    }
}
