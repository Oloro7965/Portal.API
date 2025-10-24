using MediatR;
using Portal.Application.ViewModels;
using Portal.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Application.Queries.GetArtigosSemanticosQuery
{
    public class GetArtigosSemanticosQuery: IRequest<ResultViewModel<List<PublicacaoViewModel>>>
    {
        public GetArtigosSemanticosQuery(string input)
        {
            Input = input;
        }

        public string Input { get; set; }
    }
}
