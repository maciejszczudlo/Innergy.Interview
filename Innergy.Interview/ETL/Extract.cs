using System.Collections.Generic;
using System.Linq;

namespace Innergy.Interview
{
    public class Extract : IExtract
    {
        private readonly IIgnoreLineSpecification _ignoreLineSpecification;
        private readonly IInputLineParser _inputLineParser;

        public Extract(IInputLineParser inputLineParser, IIgnoreLineSpecification ignoreLineSpecification)
        {
            _inputLineParser = inputLineParser;
            _ignoreLineSpecification = ignoreLineSpecification;
        }

        public List<InputDataModel> Process(string[] lines)
        {
            var result = new List<InputDataModel>();

            foreach (var line in lines)
            {
                if (_ignoreLineSpecification.IsToBeIgnored(line))
                    continue;

                var iModel = _inputLineParser.Parse(line);
                result.Add(iModel);
            }

            return result;
        }
    }
}