using Azenix.Log.Core.ModelFactory;
using Azenix.Log.Core.ViewModel;
using Azenix.Common.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Azenix.Log.Concrete.ModelFactory
{
    public class LogModelFactory : ILogModelFactory
    {
        public List<LogViewModel> GetLogViewModelList(List<string> lines)
        {
            List<LogViewModel> logViewModels = new List<LogViewModel>();

            if (lines.Count != 0)
            {
                foreach (var line in lines)
                {
                    var parts = Regex.Matches(line, @"[\""].+?[\""]|[[].+?[]]|[^ ]+")
                            .Cast<Match>()
                            .Select(m => m.Value)
                            .ToList();

                    logViewModels.Add(GetLogViewModel(parts[AppConstants.LOG_INDEX_IPADDRESS],
                                                   parts[AppConstants.LOG_INDEX_URL],
                                                   Int32.Parse(parts[AppConstants.LOG_INDEX_STATUS])));
                }
            }

            return logViewModels;
        }

        public LogViewModel GetLogViewModel(string ipAddress, string url, int statusCode)
        {
            return new LogViewModel
            {
                IpAddress = ipAddress,
                Url = url,
                StatusCode = statusCode
            };
        }
    }
}
