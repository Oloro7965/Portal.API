using MediatR;
using Portal.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Application.Queries.GetConteudoQuery
{
    public class GetConteudoQuery: IRequest<ResultViewModel<List<PublicacaoViewModel>>>
    {
        public GetConteudoQuery(string input)
        {
            Input = input;
        }

        public string Input { get; set; }
    }
}
