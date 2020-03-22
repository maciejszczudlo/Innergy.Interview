using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;

namespace Innergy.Interview
{
    public class Transfer : ITransfer
    {
        public List<OutputDataModel> Process(List<InputDataModel> input)
        {

            var items = input.SelectMany(material => material.Magazines,
                    ((model, inputModel) => new
                        {materialId = model.MaterialId, magazineId = inputModel.Id, count = inputModel.Count}))
                .ToList();

            var result = items.GroupBy(i => i.magazineId).Select(g => new OutputDataModel
            {
                MagazineId = g.Key,
                Materials = g.Select(i => new OutputMaterialModel {Id = i.materialId, Count = i.count}).ToList()
            }).ToList();

            result.Sort(new Comparer());

            result.ForEach(magazine =>
            {
                magazine.Materials.Sort((a,b) => a.Id.CompareTo(b.Id));
            });

            return result;

        }

        class Comparer : IComparer<OutputDataModel>
        {
            public int Compare(OutputDataModel x, OutputDataModel y)
            {
                if (x.Total == y.Total)
                    return x.MagazineId.CompareTo(y.MagazineId) * (-1);

                return x.Total.CompareTo(y.Total)*(-1);
            }
        }

    } 


    


}