using MediatR;
using Microsoft.AspNetCore.SignalR;
using Portal.Application.Queries.GetArtigosSemanticosQuery;

namespace Portal.API.Hubs
{
    public class ArtigosHub:Hub
    {
        private readonly IMediator _mediator;

        public ArtigosHub(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task BuscarArtigos(string termo)
        {
            var artigos = await _mediator.Send(new GetArtigosSemanticosQuery(termo));
            await Clients.Caller.SendAsync("ReceberArtigos", artigos);
        }
    }
}
