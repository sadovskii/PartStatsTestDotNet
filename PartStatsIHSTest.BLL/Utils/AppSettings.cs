using System.Configuration;
using System.Collections.Specialized;

namespace PartStatsIHSTest.BLL.Utils
{
    public class AppSettings
    {
        public static string GetThreadsMaxCount()
        {
            var section = ConfigurationManager.GetSection("appSettings") as NameValueCollection;
            return section["Threads.MaxCount"];
        }
    }
}
