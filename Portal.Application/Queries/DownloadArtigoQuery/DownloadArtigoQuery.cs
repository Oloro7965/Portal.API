using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Application.Queries.DownloadArtigoQuery
{
    public class DownloadArtigoQuery: IRequest<byte[]>
    {
        public DownloadArtigoQuery(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; private set; }
    }
}
