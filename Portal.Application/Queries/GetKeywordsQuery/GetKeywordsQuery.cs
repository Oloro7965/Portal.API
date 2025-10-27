using MediatR;
using Portal.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Application.Queries.GetKeywordsQuery
{
    public class GetKeywordsQuery: IRequest<ResultViewModel<KeywordsViewModel>>
    {
        public GetKeywordsQuery(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
    }
}
