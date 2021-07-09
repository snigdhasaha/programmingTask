using Azenix.Log.Core.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Azenix.Log.Core.Component
{
    public interface ILogQueryComponent
    {
        List<LogViewModel> GetCompleteLogs(List<string> lines);
        int GetNumberOfUniqueIpAdress(List<LogViewModel> logViewModels);
        List<string> GetTopVisitedUrls(List<LogViewModel> logViewModels);
        List<string> GetTopActiveIpAddress(List<LogViewModel> logViewModels);
    }
}
