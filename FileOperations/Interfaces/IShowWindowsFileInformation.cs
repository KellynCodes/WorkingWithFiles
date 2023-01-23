using System.Threading.Tasks;

namespace FileOperations.Interfaces
{
    public interface IShowWindowsFileInformation
    {
        Task ShowWindowsDirectoryInfoAsync();
        Task DisplayImageFilesAsync();
        Task ModifyAppDirectoryAsync();
        Task FunWithDirectoryTypeAsync();
        Task GetDriverInfoAsync();
    }
}
