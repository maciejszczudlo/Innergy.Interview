﻿using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Innergy.Interview
{
    public interface ILoad
    {
        string[] Process(List<OutputDataModel> output);
    }
}