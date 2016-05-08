using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeesingTechnologies.Assignment.Common.Validation
{
    public class UrlValidation
    {
        public static bool IsValid(string url)
        {
            try
            {
                // check if its a valid uri and the scheme is http or https 
                if (Uri.IsWellFormedUriString(url, UriKind.RelativeOrAbsolute))
                {
                    Uri uri = new Uri(url);
                    return (uri.Scheme == Uri.UriSchemeHttp || uri.Scheme == Uri.UriSchemeHttps);
                }
            }
            catch { }

            return false;
        }
    }
}
