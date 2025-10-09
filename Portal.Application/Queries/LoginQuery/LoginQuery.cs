using MediatR;
using Portal.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Application.Queries.LoginQuery
{
    public class LoginQuery: IRequest<ResultViewModel<LoginViewModel>>
    {
        public string Email { get; set; }
        public string Senha { get; set; }
    }
}
