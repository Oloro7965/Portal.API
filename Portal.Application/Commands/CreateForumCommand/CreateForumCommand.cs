using MediatR;
using Portal.Core.Entities;
using Portal.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Application.Commands.CreateForumCommand
{
    public class CreateForumCommand
    {
        public string titulo { get; set; }
        public Earea area { get; set; }
        public string descricao { get; set; }
        public List<Postagem> postagem { get; set; }
    }
}
