using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Application.Queries.BaixarRevistaQuery
{
    public class DownloadRevistaQuery: IRequest<byte[]>
    {
        public DownloadRevistaQuery(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; private set; }
    }
}
