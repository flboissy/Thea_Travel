using System;
using System.IO;
using Thea_Travel.iOS.Services;
using Thea_Travel.Services;
using Xamarin.Forms;

[assembly: Dependency(typeof(IOSSaveAndLoad))]
namespace Thea_Travel.iOS.Services
{
    class IOSSaveAndLoad : ISaveAndLoad
    {
        public string LoadText(string filename)
        {
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var filePath = Path.Combine(documentsPath, filename);
            return File.ReadAllText(filePath);
        }

        public void SavePDF(string filename, byte[] data)
        {
            filename += ".pdf";
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var filePath = Path.Combine(documentsPath, filename);
            File.WriteAllBytes(filePath, data);
        }

        public void SaveText(string filename, string text)
        {
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var filePath = Path.Combine(documentsPath, filename);
            File.WriteAllText(filePath, text);
        }
    }
}

