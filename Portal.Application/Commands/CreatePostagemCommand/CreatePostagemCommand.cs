using MediatR;
using Portal.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Application.Commands.CreatePostagemCommand
{
    public class CreatePostagemCommand
    {
        public string conteudo { get; set; }
        public List<Comentario> comentarios { get; set; }
    }
}
