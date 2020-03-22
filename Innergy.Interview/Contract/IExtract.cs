using System.Collections.Generic;

namespace Innergy.Interview
{
    public interface IExtract
    {
        List<InputDataModel> Process(string[] lines);
    }
}