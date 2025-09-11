using MediatR;
using Portal.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Application.Commands.UpdateArtigoCommand
{
    public class UpdateArtigoCommand : IRequest<ResultViewModel>
    {
        public Guid id { get; set; }
        public string titulo { get; set; }
        public string descricao { get; set; }
        public string arquivopdf { get; set; }
    }
}
