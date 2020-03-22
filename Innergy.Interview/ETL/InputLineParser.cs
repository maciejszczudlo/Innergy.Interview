using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Schema;

namespace Innergy.Interview
{
    public class InputLineParser : IInputLineParser
    {
        public InputDataModel Parse(string line)
        {
            var items = line.Split(';');
            var matName = items[0];
            var matId = items[1];

            var magColl = items[2];
            var magAsStr = magColl.Split('|');


            var materialInfos = new List<MagazineInputModel>();
            foreach (var materialStr in magAsStr)
            {
                var magazineData = materialStr.Split(',');
                var id = magazineData[0];
                var count = int.Parse(magazineData[1]);
                
                materialInfos.Add(new MagazineInputModel
                {
                    Count = count,
                    Id = id
                });
            }
            
            var result = new InputDataModel
            {
                
                    MaterialId = matId,
                    MaterialName = matName,
                                
                Magazines = materialInfos
            };

            return result;

        }
    }
}