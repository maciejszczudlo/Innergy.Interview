using System.Collections.Generic;

namespace Innergy.Interview
{
    public class InputDataModel 
    {
        public string MaterialId { get; set; }
        public string MaterialName { get; set; }
        public List<MagazineInputModel> Magazines { get; set; }

        public override string ToString()
        {
            return $"{MaterialName}{MaterialId}";
        }
    }
}