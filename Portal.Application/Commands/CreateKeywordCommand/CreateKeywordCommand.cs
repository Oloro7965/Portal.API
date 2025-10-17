using MediatR;
using Portal.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Application.Commands.CreateKeywordCommand
{
    public class CreateKeywordCommand: IRequest<ResultViewModel<object>>
    {
        public string titulo { get; set; }
    }
}
