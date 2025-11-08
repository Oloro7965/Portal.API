using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Application.Queries.DownloadCapaRevistaQuery
{
    public class DownloadCapaRevistaQuery: IRequest<byte[]>
    {
        public DownloadCapaRevistaQuery(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; private set; }
    }
}
