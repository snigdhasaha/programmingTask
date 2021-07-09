using System;
using System.Collections.Generic;
using System.Text;

namespace Azenix.Data.Core
{
    public interface IDataLoaderComponent
    {
        List<string> GetDataFromLogFile();
    }
}
