using System;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Reflection;
using System.Threading.Tasks;

class Program
{
    public static string documentsFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
    public static string tempDirPath = Path.Combine(documentsFolderPath, "temp");

    static void Main(string[] args)
    {
        ClearDirectory(tempDirPath);
        CheckForUpdates().Wait();
    }

    private static void ClearDirectory(string directoryPath, string skipFolderName = null)
    {
        string currentExePath = Assembly.GetExecutingAssembly().Location;

        if (!Directory.Exists(directoryPath))
        {
            Directory.CreateDirectory(directoryPath);
        }

        // Delete all files in the directory, except the current executable
        foreach (string filePath in Directory.GetFiles(directoryPath))
        {
            if (!filePath.Equals(currentExePath, StringComparison.OrdinalIgnoreCase))
            {
                File.Delete(filePath);
            }
        }

        // Delete all subdirectories and their files recursively, except the specified folder to skip
        foreach (string subdirectoryPath in Directory.GetDirectories(directoryPath))
        {
            if (skipFolderName == null || !subdirectoryPath.EndsWith(skipFolderName, StringComparison.OrdinalIgnoreCase))
            {
                ClearDirectory(subdirectoryPath);
                Directory.Delete(subdirectoryPath);
            }
        }
    }



    private static async Task CheckForUpdates()
    {
        // URL to the location of the latest version of your application
        string latestVersionUrl = "https://github.com/dynamit93/Downloads/raw/main/Debug.zip";
        string documentsFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        string tempDirPath = Path.Combine(documentsFolderPath, "temp");
        string programFilesX86Path = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86);
        string targetDirPath = Path.Combine(programFilesX86Path, "DLBot Development\\DLBot");

        string zipFilePath = Path.Combine(tempDirPath, "Debug.zip");

        // Download the latest version to a temporary location
        using (var client = new WebClient())
        {
            await client.DownloadFileTaskAsync(latestVersionUrl, zipFilePath);
        }

        // Extract the contents of the zip file to the temporary directory
        ZipFile.ExtractToDirectory(zipFilePath, tempDirPath);

        // Get the extracted Debug folder path
        string extractedDebugFolderPath = Path.Combine(tempDirPath, "Debug");

        // Clear the target directory except for the "update" folder
        ClearDirectory(targetDirPath, skipFolderName: "update");

        // Move the contents of the extracted Debug folder to the target directory
        CopyDirectory(extractedDebugFolderPath, targetDirPath);

        // Delete the tempDirPath directory after the extraction is done
        Directory.Delete(tempDirPath, true);
    }



    private static void CopyDirectory(string sourceDirPath, string destDirPath)
    {
        if (!Directory.Exists(destDirPath))
        {
            Directory.CreateDirectory(destDirPath);
        }

        foreach (string filePath in Directory.GetFiles(sourceDirPath))
        {
            string destFilePath = Path.Combine(destDirPath, Path.GetFileName(filePath));
            File.Copy(filePath, destFilePath, true);
        }

        foreach (string subDirPath in Directory.GetDirectories(sourceDirPath))
        {
            string destSubDirPath = Path.Combine(destDirPath, Path.GetFileName(subDirPath));
            CopyDirectory(subDirPath, destSubDirPath);
        }
    }
}
