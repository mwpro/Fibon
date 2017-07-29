using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fibon.Messages;
using Microsoft.AspNetCore.Mvc;
using RawRabbit;

namespace Fibon.Service.Handlers
{
    public class CalculateValueCommandHandler : ICommandHandler<CalculateValueCommand>
    {
        private readonly IBusClient _client;
        private readonly ICalculator _calculator;

        public CalculateValueCommandHandler(IBusClient client, ICalculator calculator)
        {
            _client = client;
            _calculator = calculator;
        }

        public async Task HandleAsync(CalculateValueCommand command)
        {
            int result = _calculator.Fib(command.Number);

            await _client.PublishAsync(new ValueCalculated()
            {
                Number = command.Number,
                Result = result
            });
        }
    }
}
