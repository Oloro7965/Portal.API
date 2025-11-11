using MediatR;
using Portal.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Application.Commands.CreateProfessorCommand
{
    public class CreateProfessorCommand: IRequest<ResultViewModel<object>>
    {
        public string NomeCompleto { get; set; }
        public string email { get; set; }
        public string senhaHash { get; set; }
    }
}
