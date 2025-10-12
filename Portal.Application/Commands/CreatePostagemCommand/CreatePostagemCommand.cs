using MediatR;
using Portal.Application.ViewModels;
using Portal.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Application.Commands.CreatePostagemCommand
{
    public class CreatePostagemCommand : IRequest<ResultViewModel<object>>
    {
        public string conteudo { get; set; }
    }
}
