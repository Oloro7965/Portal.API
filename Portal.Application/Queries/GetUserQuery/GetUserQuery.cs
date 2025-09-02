using MediatR;
using Portal.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Application.Queries.GetUsersQuery
{
    public class GetUserQuery : IRequest<ResultViewModel<UsuarioViewModel>>
    {
        public GetUserQuery(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; private set; }
    }
}
