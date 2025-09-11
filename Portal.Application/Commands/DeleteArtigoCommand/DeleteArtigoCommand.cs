using Portal.Application.ViewModels;
using MediatR;
using Portal.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Application.Commands.DeleteArtigoCommand
{
    public class DeleteArtigoCommand:IRequest<ResultViewModel>
    {
        public DeleteArtigoCommand(Guid id)
        {
            Id = id;
        }
        public Guid Id { get; private set; }
    }
}
