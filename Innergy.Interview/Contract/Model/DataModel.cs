using System.Collections.Generic;

namespace Innergy.Interview
{
    public abstract class DataModel<TParent, TChild> 
    {
        public TParent Item { get; set; }
        public List<TChild> Children = new List<TChild>(); 
    }
}