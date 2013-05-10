using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sagrada.IdentityServer.Module
{
    public interface ISagradaIdentityService
    {
        IEnumerable<Tuple<Guid, string>> GetProfiles(string userName);        
        IEnumerable<Tuple<Guid, string>> GetCompanies();
        IEnumerable<CultureInfo> GetLanguages();
        string[] GetRoles(string userName);
    }
}
