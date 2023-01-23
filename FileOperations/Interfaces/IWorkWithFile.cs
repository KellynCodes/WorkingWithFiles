using System.Threading.Tasks;

namespace FileOperations.Interfaces
{
    public interface IWorkWithFile
    {
        Task FileIOAsync();
        Task OpenAndOrManipulateFileAsync();
    }
}
