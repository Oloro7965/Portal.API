using MediatR;
using Portal.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Application.Commands.UpdateUserCommand
{
    public class UpdateUserCommand : IRequest<ResultViewModel>
    {
        public Guid id { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
    }
}
