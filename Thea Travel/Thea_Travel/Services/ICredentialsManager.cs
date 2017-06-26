using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thea_Travel.Services
{
    public interface ICredentialsManager
    {
        void SaveCredentials(string username, string password);
        void DeleteCredentials();
        string UserName { get; }
        string Password { get; }
    }
}
