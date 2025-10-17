using MediatR;
using Portal.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Application.Commands.UpdateKeywordCommand
{
    public class UpdateKeywordCommand: IRequest<ResultViewModel>
    {
        public Guid id { get; set; }
        public string NovoTitulo { get; set; }
        
    }
}
