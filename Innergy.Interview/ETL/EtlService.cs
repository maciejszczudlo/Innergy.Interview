using System.Threading.Tasks;

namespace Innergy.Interview
{
    public class EtlService : IEtlService
    {
        private readonly IExtract _extract;
        private readonly IFileSystemService _fileSystemSystemService;
        private readonly ILoad _load;
        private readonly ITransfer _transfer;

        public EtlService(IFileSystemService fileSystemSystemService, IExtract extract, ITransfer transfer, ILoad load)
        {
            _fileSystemSystemService = fileSystemSystemService;
            _extract = extract;
            _transfer = transfer;
            _load = load;
        }

        public Task Process(string inputFilePath, string outputFilePath)
        {
            var fileLines = _fileSystemSystemService.ReadLinesAsync(inputFilePath).Result;

            var inputModel = _extract.Process(fileLines);

            var outputModel = _transfer.Process(inputModel);

            var outputData = _load.Process(outputModel);

            var task = _fileSystemSystemService.WriteLinesAsync(outputFilePath, outputData);

            return task;

        }
    }
}