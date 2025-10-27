using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Application.Commands.UploadImagemCommand
{
    public class UploadImagemCommand: IRequest
    {
        public Guid Id { get; set; }
        public IFormFile Capa { get; set; }
    }
}
