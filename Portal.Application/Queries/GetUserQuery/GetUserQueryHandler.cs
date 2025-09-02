using MediatR;
using Portal.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Application.Queries.GetUsersQuery
{
    public class GetUserQueryHandler : IRequestHandler<GetUserQuery, ResultViewModel<UsuarioViewModel>>
    {
        public Task<ResultViewModel<UsuarioViewModel>> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
