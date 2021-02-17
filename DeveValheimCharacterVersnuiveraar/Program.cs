using DeveValheimCharacterVersnuiveraar.Helpers;
using DeveValheimCharacterVersnuiveraar.ReaderWriters;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Linq;

namespace DeveValheimCharacterVersnuiveraar
{
    public class Program
    {
        static void Main(string[] args)
        {
            var localLow = LocalLowFinder.GetLocalLow();
            var dirPath = @$"{localLow}\IronGate\Valheim\characters";

            foreach(var playerFilePath in Directory.GetFiles(dirPath).Where(t => Path.GetExtension(t).Equals(".fch", StringComparison.OrdinalIgnoreCase)))
            {
                var worldPlayer = WorldPlayerReaderWriter.Load(playerFilePath);

                var outputJsonFilePath = Path.Combine(Path.GetDirectoryName(playerFilePath), Path.GetFileNameWithoutExtension(playerFilePath) + ".json");
                var outputJson = JsonConvert.SerializeObject(worldPlayer, Formatting.Indented);
                File.WriteAllText(outputJsonFilePath, outputJson);
            }
            Console.WriteLine("Hello World!");
        }
    }
}
