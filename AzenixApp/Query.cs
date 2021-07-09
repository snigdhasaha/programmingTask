using Azenix.Data.Core;
using Azenix.Log.Core.Component;
using Azenix.Log.Core.ViewModel;
using System.Collections.Generic;

namespace AzenixApp
{
    public class Query
    {
        public ILogQueryComponent LogQueryComponent { get; set; }
        public IDataLoaderComponent DataLoaderComponent { get; set; }
        public List<LogViewModel> Execute() {
            var lines = DataLoaderComponent.GetDataFromLogFile();
            var logViewModels = LogQueryComponent.GetCompleteLogs(lines);

            return logViewModels;
        }

        public int ExecuteGetNumberOfUniqueIpAddress(List<LogViewModel> logViewModels)
        { 
            return LogQueryComponent.GetNumberOfUniqueIpAdress(logViewModels);
        }

        public List<string> ExecuteGetTopActiveIpAddress(List<LogViewModel> logViewModels)
        {
            return LogQueryComponent.GetTopActiveIpAddress(logViewModels);
        }

        public List<string> ExecuteGetTopVisitedUrls(List<LogViewModel> logViewModels)
        { 
            return LogQueryComponent.GetTopVisitedUrls(logViewModels);
        }
    }
}
