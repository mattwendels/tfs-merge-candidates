using System.Configuration;

namespace TfsMergeCandidates.Config
{
    public static class AppConfig
    {
        public static string DefaultTFSServer
        {
            get { return GetApplicationSetting("DefaultTfsServer"); }
        }

        public static string XsltOutputTemplateLocation
        {
            get { return GetApplicationSetting("MergeOutput.XsltTemplateLocation"); }
        }

        private static string GetApplicationSetting(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }
    }
}
