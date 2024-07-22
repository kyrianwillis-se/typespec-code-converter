using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TypeSpecCodeConverter.Models;

namespace TypeSpecCodeConverter.Services
{
    public interface ITransformationService
    {
        /// <summary>
        /// Returns an object with two lists, one for new files and one for files the AI thinks will need to be updated
        /// </summary>
        /// <param name="typespecContent"></param>
        /// <param name="allApplicationFiles"></param>
        /// <returns></returns>
        Task<FileChangeSet> GetChangedFiles(string typespecContent, List<string> allApplicationFiles);

        /// <summary>
        /// Creates new files and updates existing files based on the AI's recommendations
        /// </summary>
        /// <param name="fileChangeSet"></param>
        /// <param name="typeSpecFiles"></param>
        /// <returns></returns>
        Task<string> TransformFileToCSharpAsync(FileChangeSet fileChangeSet, IEnumerable<string> typeSpecFiles);
    }
}
