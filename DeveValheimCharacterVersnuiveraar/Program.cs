using DeveCoolLib.DeveConsoleMenu;
using DeveValheimCharacterVersnuiveraar.GameClasses;
using DeveValheimCharacterVersnuiveraar.Helpers;
using DeveValheimCharacterVersnuiveraar.ReaderWriters;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Linq;

namespace DeveValheimCharacterVersnuiveraar
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var localLow = LocalLowFinder.GetLocalLow();
            var dirPath = @$"{localLow}\IronGate\Valheim\characters";

            var fchFiles = Directory.GetFiles(dirPath).Where(t => Path.GetExtension(t).Equals(".fch", StringComparison.OrdinalIgnoreCase));
            var jsonFiles = Directory.GetFiles(dirPath).Where(t => Path.GetExtension(t).Equals(".json", StringComparison.OrdinalIgnoreCase));


            var menu = new ConsoleMenu(ConsoleMenuType.StringInput);
            menu.MenuOptions.Add(new ConsoleMenuOption("Convert FCH to JSON", () =>
            {
                var menu2 = new ConsoleMenu(ConsoleMenuType.StringInput);
                Console.WriteLine("");
                Console.WriteLine("Choose file to convert:");
                foreach (var file in fchFiles)
                {
                    var fileName = Path.GetFileName(file);
                    var fileNameNoExtension = Path.GetFileNameWithoutExtension(file);
                    menu2.MenuOptions.Add(new ConsoleMenuOption($"{fileName} -> {fileNameNoExtension}.json", () =>
                    {
                        ConvertFchToJson(file);
                    }));
                }

                menu2.RenderMenu();
                menu2.WaitForResult();
            }));
            menu.MenuOptions.Add(new ConsoleMenuOption("Convert JSON to FCH", () =>
            {
                var menu2 = new ConsoleMenu(ConsoleMenuType.StringInput);
                Console.WriteLine("");
                foreach (var file in jsonFiles)
                {
                    var fileName = Path.GetFileName(file);
                    var fileNameNoExtension = Path.GetFileNameWithoutExtension(file);
                    menu2.MenuOptions.Add(new ConsoleMenuOption($"{fileName} -> {fileNameNoExtension}.fch", () =>
                    {
                        ConvertJsonToFch(file);
                    }));
                }

                menu2.RenderMenu();
                menu2.WaitForResult();
            }));

            menu.RenderMenu();
            menu.WaitForResult();

            Console.WriteLine();
            Console.WriteLine("Ok thanks bye :)");
            Console.WriteLine("Made by Devedse");
        }

        public static void ConvertFchToJson(string path)
        {
            var fileName = Path.GetFileName(path);
            var fileNameNoExtension = Path.GetFileNameWithoutExtension(path);
            var dir = Path.GetDirectoryName(path);
            var outputJsonFilePath = Path.Combine(dir, fileNameNoExtension + ".json");

            var worldPlayer = WorldPlayerReaderWriter.Load(path);
            var outputJson = JsonConvert.SerializeObject(worldPlayer, Formatting.Indented);

            if (File.Exists(outputJsonFilePath))
            {
                File.Move(outputJsonFilePath, outputJsonFilePath + ".backup", true);
            }
            File.WriteAllText(outputJsonFilePath, outputJson);

            Console.WriteLine($"Converted '{path}' to '{outputJsonFilePath}'");
        }

        public static void ConvertJsonToFch(string path)
        {
            var fileName = Path.GetFileName(path);
            var fileNameNoExtension = Path.GetFileNameWithoutExtension(path);
            var dir = Path.GetDirectoryName(path);
            var outputFchFilePath = Path.Combine(dir, fileNameNoExtension + ".fch");

            var inputJson = File.ReadAllText(path);
            var worldPlayer = JsonConvert.DeserializeObject<WorldPlayer>(inputJson);

            if (File.Exists(outputFchFilePath))
            {
                File.Move(outputFchFilePath, outputFchFilePath + ".backup", true);
            }
            WorldPlayerReaderWriter.Save(outputFchFilePath, worldPlayer);

            Console.WriteLine($"Converted '{path}' to '{outputFchFilePath}'");
        }
    }
}
