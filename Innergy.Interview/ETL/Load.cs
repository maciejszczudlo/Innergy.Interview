using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Innergy.Interview
{
    public class Load : ILoad
    {
        public string[] Process(List<OutputDataModel> output)
        {
            var result = new List<string>();

            var n = output.Count;
            for (var i = 0; i < n; i++)
            {
                var item = output[i];
                

                result.Add($"{item.MagazineId} (total {item.Total})");
                foreach (var material in item.Materials)
                {
                    result.Add($"{material.Id}: {material.Count}");
                }

                if (i < n - 1)
                    result.Add(string.Empty);
            }

            return result.ToArray();
        }
    }
}