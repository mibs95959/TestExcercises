using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;

namespace Tools.General_Tools.Windows
{
    public class FileManager_Tool
    {

        // Variables:

        public static string downloadsPath = GetDownloadsFolderPath();

        // Get Path methods:
        public static void SetupFolders()
        {
            Directory.CreateDirectory(GetDownloadsFolderPath());
            Directory.CreateDirectory(GetProjectTempPath());
            Directory.CreateDirectory(GetReportsFolder());
        }

        private static string GetReportsFolder()
        {
            return Path.Combine(GetBasePath(), "Reports");
        }

        /// <summary>
        /// TODO: Set the other methods to use this one.
        /// </summary>
        /// <returns></returns>
        public static string GetBasePath()
        {
            return AppDomain.CurrentDomain.BaseDirectory;
        }

        public static string GetProjectPath()
        {
            return AppDomain.CurrentDomain.BaseDirectory.Split("bin")[0];
        }

        public static string GetCurrentPath()
        {
            return Directory.GetCurrentDirectory();
        }

        public static string GetProjectTempPath()
        {
            return GetBasePath() + "Temp";
        }

        public static string GetDownloadsFolderPath()
        {
            return GetBasePath() + "Downloads";
        }

        public static string NavigateUpFromGivenPath(int times, string path)
        {
            string timesUp = "";
            for (int i = 0; i < times; i++)
            {
                timesUp = timesUp + @".." + Path.DirectorySeparatorChar;
            }
            return Path.GetFullPath(Path.Combine(path, timesUp));
        }

        // Drives info:

        private static DriveInfo[] GetDrivesInfo()
        {
            return DriveInfo.GetDrives();
        }

        private static DriveInfo FindGivenDrive(string _givenDrive)
        {
            DriveInfo[] drives = GetDrivesInfo();

            foreach (DriveInfo drive in drives)
            {
                if (drive.Name.Equals(_givenDrive)) return drive;
            }
            return null;
        }


        // Get Given File info:

        public static long GetGivenDriveSize(string _givenDrive)
        {
            return FindGivenDrive(_givenDrive).TotalSize;
        }

        public static long GetGivenDriveAvailableSpace(string _givenDrive)
        {
            return FindGivenDrive(_givenDrive).TotalFreeSpace;
        }

        private static FileInfo GetGivenFileInfo(string _filePath)
        {
            return new FileInfo(_filePath);
        }

        public static long GetGivenFileSize(string _filePath)
        {
            return GetGivenFileInfo(_filePath).Length;
        }

        public static string GetGivenFileExtension(string _filePath)
        {
            return GetGivenFileInfo(_filePath).Extension;
        }

        public static string[] GetListOfFilesFromPath(string path)
        {
            try
            {
                return Directory.GetFiles(path);
            }
            catch (DirectoryNotFoundException)
            {
                Console.WriteLine("Warning: There are no files at the given path.");
                return null;
            }
        }


        // Deletion methods:

        public static void DeleteGivenFile(string filePath)
        {
            try
            {
                File.Delete(filePath);
            }
            catch (Exception e)
            {
                Console.WriteLine("Failed to delete file with Path/Name: '" + filePath + "', " + e.Message);
            }
        }

        public static void DeleteGivenFileList(List<string> filePaths)
        {
            foreach (string file in filePaths) File.Delete(file);
        }

        public static void DeleteGivenFileList(string[] filePaths)
        {
            foreach (string file in filePaths) File.Delete(file);
        }

        public static void DeleteAllFilesInGivenFolder(string folderPath)
        {
            try
            {
                string[] filesInFolder = GetListOfFilesFromPath(folderPath);
                foreach (string x in filesInFolder) DeleteGivenFile(x);
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("There are no files to delete at the given folder path.");
            }
        }

        public static void DeleteAllFilesInTempFolder()
        {
            DeleteAllFilesInGivenFolder(GetProjectTempPath());
        }

        public static void DeleteAllFilesInDownloadsFolder()
        {
            DeleteAllFilesInGivenFolder(GetDownloadsFolderPath());
        }

        /// <summary>
        /// Cleanup the Reports folder, but leave the last few images and reports for later retrieval.
        /// </summary>
        public static void CleanupReportsFolder()
        {
            var reports = GetReportsFolder();
            DeleteFilesInGivenFolder(reports, "*.html", 3);
            DeleteFilesInGivenFolder(reports, "*.jpg", 3);
        }

        public static void DeleteFilesInGivenFolder(string folderPath, string filePattern, int numberOfLatestFilesToKeep)
        {
            // E.g. "Reports" may not exist to begin with
            if (!Directory.Exists(folderPath))
            {
                return;
            }

            var files = Directory.EnumerateFiles(folderPath, filePattern, SearchOption.TopDirectoryOnly)
                .OrderByDescending(f => File.GetLastWriteTime(f))
                .Skip(numberOfLatestFilesToKeep);

            foreach (var file in files)
            {
                DeleteGivenFile(file);
            }
        }


        public static void DeleteAllFilesThatNameContains(string folderPath, string name)
        {
            string[] filesInFolder = GetListOfFilesFromPath(folderPath);
            foreach (string x in filesInFolder)
            {
                if (x.Contains(name)) DeleteGivenFile(x);
            }
        }

        // Does given file/s exist?

        public static bool DoesGivenFileNameExists(string folderPath, string filename)
        {
            return File.Exists(folderPath + Path.AltDirectorySeparatorChar + filename);
        }

        public static bool DoesGivenFileNameExists(string folderPath)
        {
            return File.Exists(folderPath);
        }

        public static bool DoesFileExistWithName(string folderPath, string filename)
        {
            string[] filesInFolder = GetListOfFilesFromPath(folderPath);
            foreach (string x in filesInFolder)
            {
                if (x.Contains(filename)) return true;
            }
            return false;
        }

        // Others:

        public static string GetFileNameThatContains(string folderPath, string filename)
        {
            string[] filesInFolder = GetListOfFilesFromPath(folderPath);
            foreach (string x in filesInFolder)
            {
                if (x.Contains(filename)) return x;
            }
            return null;
        }


        // Advanced methods:

        public static bool WasFileDownloaded(string partialName)
        {
            if (!DoesFileExistWithName(downloadsPath, partialName)) return false;
            string orderReceiptFileName = GetFileNameThatContains(GetDownloadsFolderPath(), partialName);
            if (GetGivenFileSize(orderReceiptFileName) < 1) return false;
            return true;
        }

        public static bool WasFileDownloaded(string partialName, string fileExtension)
        {
            if (!DoesFileExistWithName(downloadsPath, partialName)) return false;
            string orderReceiptFileName = GetFileNameThatContains(GetDownloadsFolderPath(), partialName);
            if (!orderReceiptFileName.Contains(fileExtension)) return false;
            if (GetGivenFileSize(orderReceiptFileName) < 1) return false;
            return true;
        }

        public static bool WaitUntilFileWasDownloadedByPartialName(string partialName, string fileExtension, int seconds)
        {
            for (int i = 0; i <= seconds; i++)
            {
                if (WasFileDownloaded(partialName, fileExtension))
                {
                    return true;
                }
                else
                {
                    Thread.Sleep(1000);
                }
            }
            return false;
        }

    }
}
