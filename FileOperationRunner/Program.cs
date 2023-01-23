using FileOperations.Enums;
using FileOperations.Implementation;
using FileOperations.Interfaces;

namespace FileOperationRunner
{
    internal class Program
    {
        readonly IShowWindowsFileInformation _showWindowsFileInformations;
        readonly IWorkWithFile _workWithFile;
       
        public Program(IShowWindowsFileInformation showWindowsFileInformations, IWorkWithFile workWithFile)
        {
            _showWindowsFileInformations = showWindowsFileInformations;
            _workWithFile = workWithFile;
        }

        static async Task Main()
        {
            Program program = new(new ShowWindowsFileInformation(), new WorkWithFile());
            Console.WriteLine("Choose what operation you would like to perform.");
            Console.WriteLine("1.\t ShowWindowsDirectoryInfo\n2.\t Show image files\n3.\t Modify App directory.\n4.\t Check directory type.\n5.\t Get directory iformation.\n6\t Work with file.\n7.\t Open and or manipulate files.");
            string Operation = Console.ReadLine() ?? string.Empty;
            if (int.TryParse(Operation, out int Choice))
            {
                switch (Choice)
                {
                    case (int)SwitchCase.CaseOne:
                       await program._showWindowsFileInformations.ShowWindowsDirectoryInfoAsync();
                        break;
                    case (int)SwitchCase.CaseTwo:
                       await program._showWindowsFileInformations.DisplayImageFilesAsync();
                        break;
                    case (int)SwitchCase.CaseThree:
                       await program._showWindowsFileInformations.ModifyAppDirectoryAsync();
                        break;
                    case (int)SwitchCase.CaseFour:
                       await program._showWindowsFileInformations.FunWithDirectoryTypeAsync();
                        break;
                    case (int)SwitchCase.CaseFive:
                        await program._showWindowsFileInformations.GetDriverInfoAsync();
                        break;
                    case (int)SwitchCase.CaseSix:
                        await program._workWithFile.FileIOAsync();
                        break;
                    case (int)SwitchCase.CaseSeven:
                        await program._workWithFile.OpenAndOrManipulateFileAsync();
                        break;
                    default:
                        Console.WriteLine("Input was not in the options. PLease try again.");
                        break;
                }
            }
        }
    }
}