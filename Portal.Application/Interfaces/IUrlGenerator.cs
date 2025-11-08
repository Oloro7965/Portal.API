using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Application.Interfaces
{
    public interface IUrlGenerator
    {
        string? GetDownloadArtigoUrl(Guid id);
        string? GetDownloadRevistaUrl(Guid id);
        string? GetImagemRevistaUrl(Guid id);
    }
}
