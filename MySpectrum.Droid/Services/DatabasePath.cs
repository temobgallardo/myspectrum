using System.IO;
using MySpectrum.Shared.Repositories;

namespace MySpectrum.Droid.Services
{
    public class DatabasePath : IDatabasePath
    {
        public const string DatabaseFilename = "Spectrum.db3";

        public string GetPath()
        {
            var basePath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData);
            return Path.Combine(basePath, DatabaseFilename);
        }
    }
}