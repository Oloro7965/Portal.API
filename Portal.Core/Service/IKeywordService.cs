using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Core.Service
{
    public interface IKeywordService
    {
        Task<List<string>> ExtractKeywordsAsync(string userQuery);
    }
}
