using MediatR;
using Portal.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Application.Queries.GetRevistaQuery
{
    public class GetRevistaQuery : IRequest<ResultViewModel<RevistaViewModel>>
    {
        public GetRevistaQuery(Guid id)
        {
            Id = id;
        }
        public Guid Id { get; private set; }
    }
}
