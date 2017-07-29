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

        public CalculateValueCommandHandler(IBusClient client)
        {
            _client = client;
        }

        public async Task HandleAsync(CalculateValueCommand command)
        {
            int result = Fib(command.Number);

            await _client.PublishAsync(new ValueCalculated()
            {
                Number = command.Number,
                Result = result
            });
        }

        private int Fib(int number)
        {
            // not optimal
            switch (number)
            {
                case 0:
                    return 0;
                case 1:
                    return 1;
                default:
                    return Fib(number -2) + Fib(number - 1);
            }
        }
    }
}
