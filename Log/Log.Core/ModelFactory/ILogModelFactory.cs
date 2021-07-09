using Azenix.Log.Core.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Azenix.Log.Core.ModelFactory
{
    public interface ILogModelFactory
    {
        List<LogViewModel> GetLogViewModelList(List<string> items);
        LogViewModel GetLogViewModel(string ipAddress, string url, int statusCode);
    }
}
