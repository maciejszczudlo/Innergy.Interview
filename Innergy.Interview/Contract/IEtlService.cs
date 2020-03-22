using System.Threading.Tasks;

namespace Innergy.Interview
{
    public interface IEtlService
    {
        Task Process(string inputFilePath, string outputFilePath);
    }
}