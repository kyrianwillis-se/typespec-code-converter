using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypeSpecCodeConverter.Services
{
    public interface IFileService
    {
        /// <summary>
        /// Returns a list of all files in the paths specified in the appsettings.json. These represent the files that will be examined for needed changes
        /// </summary>
        /// <returns></returns>
        List<string> GetAllFiles();

        /// <summary>
        /// Concatenates the files specified in the paths parameter into a single string 
        /// </summary>
        /// <param name="paths"></param>
        /// <returns></returns>
        string ConcatenateFiles(IEnumerable<string> paths);

        /// <summary>
        /// Saves the generated files to the specified output directories
        /// </summary>
        /// <param name="output"></param>
        void SaveGeneratedFiles(string output);

        /// <summary>
        /// Gets the contents of the prompt file
        /// </summary>
        /// <param name="resourceName"></param>
        /// <returns></returns>
        string GetPrompt(string resourceName);
    }
}
