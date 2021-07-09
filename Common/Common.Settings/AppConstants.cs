using Microsoft.Extensions.Configuration;
using System;

namespace Azenix.Common.Settings
{
    public static class AppConstants
    {
        private static readonly IConfigurationRoot Configuration = new ConfigurationBuilder()
                                      .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                                      .Build();

        private const string SECTION_LOG_INDEX_IPADDRESS = "Log:Index:IpAddress";
        private const string SECTION_LOG_INDEX_URL = "Log:Index:Url";
        private const string SECTION_LOG_INDEX_STATUS = "Log:Index:Status";
        private const string SECTION_PATH = "Path";
        private static IConfigurationSection GetConfigSection(string section)
        {
            return Configuration.GetSection(section);
        }
        public static int LOG_INDEX_IPADDRESS
        {
            get
            {
                return Int32.Parse(GetConfigSection(SECTION_LOG_INDEX_IPADDRESS).Value);
            }
        }

        public static int LOG_INDEX_URL
        {
            get
            {
                return Int32.Parse(GetConfigSection(SECTION_LOG_INDEX_URL).Value);
            }
        }

        public static int LOG_INDEX_STATUS
        {
            get
            {
                return Int32.Parse(GetConfigSection(SECTION_LOG_INDEX_STATUS).Value);
            }
        }

        public static string PATH
        {
            get
            {
                return GetConfigSection(SECTION_PATH).Value;
            }
        }
    }
}
