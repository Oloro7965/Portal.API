using MediatR;
using Portal.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Application.Queries.GetAllPostagensQuery
{
    public class GetAllPostagensQuery : IRequest<ResultViewModel<List<PostagemViewModel>>>
    {
    }
}
