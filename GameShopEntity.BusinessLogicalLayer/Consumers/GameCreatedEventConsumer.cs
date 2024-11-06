using GameShopEntity.BusinessLogicalLayer.DTO.Request;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameShopEntity.BusinessLogicalLayer.Consumers
{
    public class GameCreatedEventConsumer : IConsumer<GameCreatedEvent>
    {
        public async Task Consume(ConsumeContext<GameCreatedEvent> context)
        {
            var message = context.Message;
            Console.WriteLine($"Game Created: Id = {message.GameId}, Title = {message.Title}, Price = {message.Price}");

            await Task.CompletedTask;
        }
    }
}
