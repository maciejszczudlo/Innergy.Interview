using System.Threading.Tasks;

namespace Innergy.Interview
{
    public interface IFileSystemService
    {
        Task<string[]> ReadLinesAsync(string path);
        Task WriteLinesAsync(string path, string[] lines);
    }
}