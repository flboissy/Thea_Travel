using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thea_Travel.Services
{
     public interface ISaveAndLoad
    {
        void SaveText(string filename, string text);
        string LoadText(string filename);

        void SavePDF(string filename, byte[] data);
    }
}
