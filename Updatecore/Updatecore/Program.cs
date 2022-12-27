using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Ionic.Zip;


namespace Updatecore
{
    internal class Program
    {
        static void Main(string[] args)
        {

        }


        private async Task CheckForUpdates()
        {
            // URL to the location of the latest version of your application
            string latestVersionUrl = "http://www.example.com/latestversion.zip";

            // Download the latest version to a temporary location
            using (var client = new WebClient())
            {
                await client.DownloadFileTaskAsync(latestVersionUrl, "temp/latestversion.zip");
            }
        }

        private void ExtractZipFile(string zipFilePath, string extractPath)
        {
            // Open the ZIP file
            using (var zip = ZipFile.Read(zipFilePath))
            {
                // Extract the contents to the specified directory
                zip.ExtractAll(extractPath, ExtractExistingFileAction.OverwriteSilently);
            }
        }


        private void UpdateApplication()
        {
            // Get the path to the current executable
            string currentExecutablePath = Assembly.GetExecutingAssembly().Location;

            // Stop the current process
            Process.GetCurrentProcess().Kill();

            // Copy the new version over the old version
            File.Copy("temp/latestversion.exe", currentExecutablePath, true);

            // Start the new version of the application
            Process.Start(currentExecutablePath);
        }

    }
}
