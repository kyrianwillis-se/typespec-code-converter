using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TypeSpecCodeConverter.Configuration;

namespace TypeSpecCodeConverter.Services
{
    public class FileService : IFileService
    {
        private readonly ApplicationConfig _config;
        private const string FileDelimiter = "<<<<<File:";
        private const string EndDelimiter = ">>>>>";

        public FileService(IOptions<ApplicationConfig> config)
        {
            _config = config.Value;
        }

        /// <inheritdoc/>>
        public List<string> GetAllFiles()
        {
            var allFiles = new List<string>();

            foreach (var path in _config.Paths.Values)
            {
                if (Directory.Exists(path))
                {
                    var files = Directory.GetFiles(path, "*.*", SearchOption.AllDirectories)
                                         .Where(f => !f.Contains("\\generated\\"))
                                         .ToList();
                    allFiles.AddRange(files);
                }
            }

            return allFiles;
        }

        /// <inheritdoc/>>
        public string ConcatenateFiles(IEnumerable<string> paths)
        {
            var stringBuilder = new StringBuilder();

            foreach (var path in paths)
            {
                if (File.Exists(path))
                {
                    stringBuilder.AppendLine($"FileName: {path}");
                    stringBuilder.AppendLine(File.ReadAllText(path));
                    stringBuilder.AppendLine(); // Add an extra line for separation between files
                }
            }

            return stringBuilder.ToString();
        }

        /// <inheritdoc/>>
        public void SaveGeneratedFiles(string output)
        {
            var fileCount = 0;
            var files = output.Split(new string[] { FileDelimiter }, StringSplitOptions.None);
            foreach (var file in files)
            {
                if (string.IsNullOrWhiteSpace(file)) continue;

                var formatedFile = file.Replace("```csharp", string.Empty).Replace("```", string.Empty);

                // Extract the file path and contents
                var filePathEndIndex = formatedFile.IndexOf(EndDelimiter);
                var filePath = formatedFile.Substring(0, filePathEndIndex).Trim();
                var fileContents = formatedFile.Substring(filePathEndIndex + EndDelimiter.Length).Trim();

                // Create the new file path in the GeneratedCode subfolder
                var generatedFilePath = Path.Combine(Path.GetDirectoryName(filePath), "GeneratedCode", Path.GetFileName(filePath));

                Console.WriteLine($"Saving {generatedFilePath}");
                // Ensure the directory exists
                var directory = Path.GetDirectoryName(generatedFilePath);
                if (!Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }

                // Write the contents to the file
                File.WriteAllText(generatedFilePath, fileContents);
                fileCount++;
            }
            Console.WriteLine($"{fileCount} files generated");
        }

        /// <inheritdoc/>>
        public string GetPrompt(string promptFileName)
        {
            string executablePath = Assembly.GetExecutingAssembly().Location;
            string promptPath = Path.GetDirectoryName(executablePath) + "\\Prompts\\" + promptFileName;
            using (var stream = File.OpenText(promptPath))
            {
                return stream.ReadToEnd();
            }
        }
    }
}
