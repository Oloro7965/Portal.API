using MediatR;
using Portal.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Application.Queries.GetArtigoQuery
{
    public class GetArtigoQuery : IRequest<ResultViewModel<ArtigoViewModel>>
    {
        public GetArtigoQuery(Guid id)
        {
            Id = id;
        }
        
        public Guid Id { get; private set; }
    }
}
