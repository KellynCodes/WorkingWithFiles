using FileOperations.Interfaces;
using System;
using System.IO;
using System.Threading.Tasks;

namespace FileOperations.Implementation
{
    public class WorkWithFile : IWorkWithFile
    {
        public async Task FileIOAsync()
        {
            Console.WriteLine("***** Simple IO with the File Type *****\n");
            //Change to a folder on your machine that you have read/write access to, or run as 
            try
            {
                var fileName = $@"C{Path.VolumeSeparatorChar}{Path.DirectorySeparatorChar}Windows{Path.DirectorySeparatorChar}temp{Path.
           DirectorySeparatorChar}Test.dat";
                // Make a new file on the C drive.
                FileInfo f = new FileInfo(fileName);
                FileStream fs = f.Create();
                // Use the FileStream object...
                // Close down file stream.
                fs.Close();
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }

        public async Task OpenAndOrManipulateFileAsync()
        {
            try
            {

                var fileName = $@"C{Path.VolumeSeparatorChar}{Path.DirectorySeparatorChar}Test.dat";
                // Make a new file via FileInfo.Open().
                FileInfo f2 = new FileInfo(fileName);
                using (FileStream fs2 = f2.Open(FileMode.OpenOrCreate,
                 FileAccess.ReadWrite, FileShare.None))
                {
                    // Use the FileStream object...
                }
                f2.Delete();
            }
            catch (IOException IoMessage)
            {

                Console.WriteLine(IoMessage.Message);
            }
        }
    }
}
