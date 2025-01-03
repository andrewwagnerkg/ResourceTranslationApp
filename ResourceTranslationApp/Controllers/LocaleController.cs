﻿using Application.Features.Locales.Commands;
using Application.Features.Locales.Queries;
using Microsoft.AspNetCore.Mvc;

namespace ResourceTranslationApp.Controllers
{
    public class LocaleController : BaseController
    {
        [HttpPost]
        public async Task<long> CreateLocale([FromBody] CreateLocaleCommand command)
            => await Mediator.Send(command);

        [HttpGet]
        public async Task<IEnumerable<LocaleDto>> GetAllLocales()
            => await Mediator.Send(new GetAllLocalesQuery());

        [HttpDelete]
        public async Task DeleteLocale([FromQuery]long id)
            => await Mediator.Send(new DeleteLocaleCommand{Id = id});
    }
}
