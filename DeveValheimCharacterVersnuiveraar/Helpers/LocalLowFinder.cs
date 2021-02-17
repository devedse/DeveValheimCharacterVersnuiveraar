using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace DeveValheimCharacterVersnuiveraar.Helpers
{
    public static class LocalLowFinder
    {
        public static string GetLocalLow()
        {
            var folder = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            var parent = Path.GetDirectoryName(folder);
            var combined = Path.Combine(parent, "LocalLow");
            return combined;
        }
    }
}
