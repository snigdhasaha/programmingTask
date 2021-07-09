using Azenix.Data.Core;
using Azenix.Log.Core.Component;
using Azenix.Log.Core.ModelFactory;
using Azenix.Log.Core.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Azenix.Log.Concrete.Component
{
    public class LogQueryComponent : ILogQueryComponent
    {
        public ILogModelFactory LogModelFactory { get; set; }        
        public List<LogViewModel> GetCompleteLogs(List<string> lines)
        {
            var logViewModels = LogModelFactory.GetLogViewModelList(lines);

            return logViewModels;
        }

        public int GetNumberOfUniqueIpAdress(List<LogViewModel> logViewModels)
        {
            int count = logViewModels.Select(lv => lv.IpAddress).Distinct().Count();
            return count;
        }

        public List<string> GetTopActiveIpAddress(List<LogViewModel> logViewModels)
        {
            var activeIps = logViewModels.Where(lv => lv.StatusCode < 400).ToList();
            var top3ActiveIps = activeIps
                                    .GroupBy(l => l.IpAddress)
                                    .Where(grp => grp.Count() > 1)
                                    .OrderByDescending(o => o.Count())
                                    .Select(l => l.Key )
                                    .Take(3)
                                    .ToList();

            return top3ActiveIps;
        }

        public List<string> GetTopVisitedUrls(List<LogViewModel> logViewModels)
        {
            var topVisitedUrls = logViewModels.GroupBy(l => l.IpAddress).Where(grp => grp.Count() > 1).OrderByDescending(o => o.Count()).Select(l =>  l.Key).Take(3).ToList();

            return topVisitedUrls;
        }
    }
}
