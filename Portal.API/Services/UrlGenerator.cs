using Portal.Application.Interfaces;

namespace Portal.API.Services
{
    public class UrlGenerator : IUrlGenerator
    {
        private readonly LinkGenerator _linkGenerator;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UrlGenerator(LinkGenerator linkGenerator, IHttpContextAccessor httpContextAccessor)
        {
            _linkGenerator = linkGenerator;
            _httpContextAccessor = httpContextAccessor;
        }

        public string? GetDownloadArtigoUrl(Guid id)
        {
            var http = _httpContextAccessor.HttpContext!;
            return _linkGenerator.GetUriByName(http, "DownloadArtigoPdf", new { id });
        }

        public string? GetDownloadRevistaUrl(Guid id)
        {
            var http = _httpContextAccessor.HttpContext!;
            return _linkGenerator.GetUriByName(http, "DownloadRevistaPdf", new { id });
        }
    }
}
