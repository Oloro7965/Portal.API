using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Application.Commands.UploadPdfArtigoCommand
{
    public class UploadPdfArtigoCommand:IRequest
    {
        public Guid ArquivoId { get; set; }
        public IFormFile ArquivoPdf { get; set; }
    }
}
