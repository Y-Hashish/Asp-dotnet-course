
using Microsoft.Extensions.Options;

namespace SocialMediaLinks.Services
{
    public class SocialService : ISocial
    {
        private readonly SocialApi _social;
        public SocialService(IOptions<SocialApi> options)
        {
            _social = options.Value;
        }
        public SocialApi GetSocial()
        {
            return _social;
        }
    }
}
