using GameShopEntity.BusinessLogicalLayer.DTO.Request;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameShopEntity.BusinessLogicalLayer.Producers
{
    public class GameProducer
    {
        private readonly IBus _bus;

        public GameProducer(IBus bus)
        {
            _bus = bus;
        }

        public async Task PublishGameCreatedEventFalout(GameCreatedEvent gameEvent)
        {
            await _bus.Publish(gameEvent);
        }

        public async Task PublishGameCreatedEventTopic(GameCreatedEvent gameEvent)
        {
            await _bus.Publish(gameEvent, x =>
            {
                x.SetRoutingKey("game.created"); 
            });
        }
    }
}
