using Azenix.Data.Core;
using Azenix.Common.Settings;
using System.Collections.Generic;

namespace Azenix.Data.Concrete
{
    public class DataLoaderComponent : IDataLoaderComponent
    {
        public List<string> GetDataFromLogFile()
        {
            List<string> lines = new List<string>();
            string line; 

            System.IO.StreamReader file =
                new System.IO.StreamReader(AppConstants.PATH);

            while ((line = file.ReadLine()) != null)
            {
                lines.Add(line);
            }

            return lines;
        }
    }
}
