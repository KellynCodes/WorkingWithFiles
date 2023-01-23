using FileOperations.Interfaces;
using System;
using System.IO;
using System.Threading.Tasks;

namespace FileOperations.Implementation
{
    public class ShowWindowsFileInformation : IShowWindowsFileInformation
    {
        public async Task ShowWindowsDirectoryInfoAsync()
        {
            Console.WriteLine("***** Fun with Directory(Info) *****\n");
            // Dump directory information. If you are not on Windows, plug in another directory
            DirectoryInfo directory = new DirectoryInfo($@"C{Path.VolumeSeparatorChar}{Path.
            DirectorySeparatorChar}Windows");
            Console.WriteLine("***** Directory Info *****");
            Console.WriteLine("FullName: {0}", directory.FullName);
            Console.WriteLine("Name: {0}", directory.Name);
            Console.WriteLine("Parent: {0}", directory.Parent);
            Console.WriteLine("Creation: {0}", directory.CreationTime);
            Console.WriteLine("Attributes: {0}", directory.Attributes);
            Console.WriteLine("Root: {0}", directory.Root);
            Console.WriteLine("**************************\n");
        }

        public async Task DisplayImageFilesAsync()
        {
            try
            {
                DirectoryInfo dir = new
                DirectoryInfo($@"C{Path.VolumeSeparatorChar}{Path.DirectorySeparatorChar}Users{Path.DirectorySeparatorChar}KELLYNCODES{Path.DirectorySeparatorChar}source{Path.DirectorySeparatorChar}repos{Path.DirectorySeparatorChar}WorkingWithFiles{Path.DirectorySeparatorChar}FileOperations{Path.DirectorySeparatorChar}Images");
                FileInfo[] imageFiles =
                       dir.GetFiles("*.png", SearchOption.AllDirectories);
                // How many were found?
                Console.WriteLine("Found {0} *.png files\n", imageFiles.Length);
                // Now print out info for each file.
                // C: \Users\KELLYNCODES\source\repos\WorkingWithFiles\FileOperations\Images
                // Get all files with a *.jpg extension.

                foreach (FileInfo f in imageFiles)
                {
                    Console.WriteLine("***************************");
                    Console.WriteLine("File name: {0}", f.Name);
                    Console.WriteLine("File size: {0}", f.Length);
                    Console.WriteLine("Creation: {0}", f.CreationTime);
                    Console.WriteLine("Attributes: {0}", f.Attributes);
                    Console.WriteLine("***************************\n");
                    Console.WriteLine();
                }
            }
            catch (Exception exception)
            {

                Console.WriteLine(exception.Message);
            }
        }

        public async Task ModifyAppDirectoryAsync()
        {
            {
                DirectoryInfo dir = new DirectoryInfo(".");
                // Create \MyFolder off initial directory.
                dir.CreateSubdirectory("MyFolder");
                // Capture returned DirectoryInfo object.
                DirectoryInfo myDataFolder = dir.CreateSubdirectory(
                $@"MyFolder2{Path.DirectorySeparatorChar}Data");
                // Prints path to ..\MyFolder2\Data.
                Console.WriteLine("New Folder is: {0}", myDataFolder);
            }
        }

       public async Task FunWithDirectoryTypeAsync()
        {
            // List all drives on current computer.
            string[] drives = Directory.GetLogicalDrives();
            Console.WriteLine("Here are your drives:");
            foreach (string s in drives)
            {
                Console.WriteLine("--> {0} ", s);
            }
            // Delete what was created.
            Console.WriteLine("Press Enter to delete directories");
            Console.ReadLine();
            try
            {
                Directory.Delete("MyFolder");
                // The second parameter specifies whether you
                // wish to destroy any subdirectories.
                Directory.Delete("MyFolder2", true);
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public async Task GetDriverInfoAsync()
        {
            // Get info regarding all drives.
            DriveInfo[] myDrives = DriveInfo.GetDrives();
            // Now print drive stats.
            foreach (DriveInfo d in myDrives)
            {
                Console.WriteLine("Name: {0}", d.Name);
                Console.WriteLine("Type: {0}", d.DriveType);
                // Check to see whether the drive is mounted.
                if (d.IsReady)
                {
                    Console.WriteLine("Free space: {0}", d.TotalFreeSpace);
                    Console.WriteLine("Format: {0}", d.DriveFormat);
                    Console.WriteLine("Label: {0}", d.VolumeLabel);
                }
                Console.WriteLine();
            }
        }
    }
}
