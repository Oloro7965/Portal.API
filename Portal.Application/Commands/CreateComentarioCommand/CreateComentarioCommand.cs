using MediatR;
using Portal.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Application.Commands.CreateComentarioCommand
{
    public class CreateComentarioCommand : IRequest<ResultViewModel<object>>
    {
          public string Conteudo { get; set; }
    }
}
