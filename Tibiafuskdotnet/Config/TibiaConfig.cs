using System.Configuration;
using System.Diagnostics;
using System.Linq;

namespace Tibiafuskdotnet.Config
{
    public static class TibiaConfig
    {
        private const string DefaultProcessName = "Odenia Online";
        private const string DefaultVersion = "8.60";

        public static string ProcessName => GetSetting("Tibia.ProcessName", DefaultProcessName);
        public static string Version => GetSetting("Tibia.Version", DefaultVersion);

        public static Process[] GetProcesses()
        {
            return Process.GetProcessesByName(ProcessName);
        }

        public static Process GetProcess()
        {
            return GetProcesses().FirstOrDefault();
        }

        public static void ApplyVersion(Process process = null)
        {
            global::Tibia.Version.Set(Version, process ?? Process.GetCurrentProcess());
        }

        private static string GetSetting(string key, string fallback)
        {
            string value = ConfigurationManager.AppSettings[key];
            return string.IsNullOrWhiteSpace(value) ? fallback : value.Trim();
        }
    }
}
