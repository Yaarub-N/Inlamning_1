using Resources.Response;

namespace Resources.Interface
{
    public interface IFileService
    {
        string GetFromFile();
        ResultResponse SaveToFile(string product);
    }
}