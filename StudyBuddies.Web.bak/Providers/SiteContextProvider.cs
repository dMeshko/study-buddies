using System.Web;

namespace StudyBuddies.Web.Providers
{
    public interface ISiteContextProvider
    {
        bool IsMobile { get; }
    }

    public class SiteContextProvider : ISiteContextProvider
    {
        private readonly HttpContextBase _httpContextBase;

        public SiteContextProvider(HttpContextBase httpContextBase)
        {
            _httpContextBase = httpContextBase;
        }

        public bool IsMobile => _httpContextBase.Request.Browser.IsMobileDevice;
    }
}