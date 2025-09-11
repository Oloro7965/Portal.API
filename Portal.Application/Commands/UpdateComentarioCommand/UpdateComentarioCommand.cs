using MediatR;
using Portal.Application.ViewModels;
using System;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Application.Commands.UpdateComentarioCommand
{
    public class UpdateComentarioCommand : IRequest<ResultViewModel>
    {
        public Guid Id { get; set; }

        public string Conteudo { get; set; }
    }
}
