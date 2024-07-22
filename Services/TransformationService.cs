using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TypeSpecCodeConverter.Models;

namespace TypeSpecCodeConverter.Services
{
    public class TransformationService : ITransformationService
    {
        private readonly IFileService _fileService;
        private readonly IGptApiService _gptApiService;

        public TransformationService(IFileService fileService, IGptApiService gptApiService)
        {
            _fileService = fileService;
            _gptApiService = gptApiService;
        }

        ///<inheritdoc/>
        public async Task<FileChangeSet> GetChangedFiles(string typespecContent, List<string> allApplicationFiles)
        {
            var instructions = _fileService.GetPrompt("GenerateChangedFilesInstructions.txt");
            instructions = instructions.Replace("<typespecfiles>", typespecContent);
            instructions = instructions.Replace("<appfiles>", string.Join('\n', allApplicationFiles));
            var result = await _gptApiService.CallGpt4Api(instructions);
            return JsonConvert.DeserializeObject<FileChangeSet>(result)!;
        }

        ///<inheritdoc/>
        public async Task<string> TransformFileToCSharpAsync(FileChangeSet fileChangeSet, IEnumerable<string> typeSpecFiles)
        {
            var instructions = _fileService.GetPrompt("UpdateFilesInstructions.txt");
            instructions = instructions.Replace("<typespec>", _fileService.ConcatenateFiles(typeSpecFiles));
            instructions = instructions.Replace("<newfiles>", string.Join('\n', fileChangeSet.NewFiles));
            instructions = instructions.Replace("<updatefiles>", _fileService.ConcatenateFiles(fileChangeSet.UpdatedFiles));
            return await _gptApiService.CallGpt4Api(instructions);
        }
    }
}
