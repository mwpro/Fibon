using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fibon.Api.Controllers;
using Fibon.Messages;
using Microsoft.AspNetCore.Mvc;

namespace Fibon.Api.Handlers
{
    public class ValueCalculatedEventHandler : IEventHandler<ValueCalculated>
    {
        private readonly IRepository _repo;

        public ValueCalculatedEventHandler(IRepository repo)
        {
            _repo = repo;
        }


        public async Task HandleAsync(ValueCalculated @event)
        {
            _repo.Insert(@event.Number, @event.Result);
        }
    }
}
