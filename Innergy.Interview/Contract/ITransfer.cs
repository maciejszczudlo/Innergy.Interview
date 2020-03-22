using System.Collections.Generic;

namespace Innergy.Interview
{
    public interface ITransfer
    {
        List<OutputDataModel> Process(List<InputDataModel> input);
    }
}