using MediatR;
using Portal.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Application.Queries.GetForumQuery
{
    public class GetForumQuery : IRequest<ResultViewModel<ForumViewModel>>
    {
        public GetForumQuery(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; private set; }
    }
}
