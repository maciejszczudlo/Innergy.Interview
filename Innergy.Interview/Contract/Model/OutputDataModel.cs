using System;
using System.Collections.Generic;
using System.Linq;

namespace Innergy.Interview
{
    public class OutputDataModel 
    {
        public string MagazineId { get; set; }
        public List<OutputMaterialModel> Materials { get; set; } = new List<OutputMaterialModel>();

        public int Total => Materials.Sum(m => m.Count);

    }
}