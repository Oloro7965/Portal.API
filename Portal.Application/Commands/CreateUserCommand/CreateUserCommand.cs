using MediatR;
using Portal.Application.ViewModels;
using Portal.Core.Entities;
using Portal.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Application.Commands.CreateUserCommand
{
    public class CreateUserCommand : IRequest<ResultViewModel<object>>
    {
        public string NomeCompleto { get; set; }
        public string email { get; set; }
        public string senhaHash { get; set; }
        public EtipoUsuario tipoUsuario { get; set; }
    }
}
