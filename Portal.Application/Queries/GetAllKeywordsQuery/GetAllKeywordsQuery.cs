using MediatR;
using Portal.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Application.Queries.GetAllKeywordsQuery
{
    public class GetAllKeywordsQuery : IRequest<ResultViewModel<List<KeywordsViewModel>>>
    {
    }
}
