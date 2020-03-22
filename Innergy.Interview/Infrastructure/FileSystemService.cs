using System.IO;
using System.Threading.Tasks;

namespace Innergy.Interview
{
    public class FileSystemService : IFileSystemService
    {
        public Task<string[]> ReadLinesAsync(string path)
        {
            return File.ReadAllLinesAsync(path);
        }

        public Task WriteLinesAsync(string path, string[] lines)
        {
            return File.WriteAllLinesAsync(path, lines);
        }
    }
}