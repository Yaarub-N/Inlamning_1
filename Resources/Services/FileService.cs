
using Resources.Interface;
using Resources.Response;
using System.Reflection.Metadata.Ecma335;

namespace Resources.Services;

public class FileService(string path) : IFileService
{
    private readonly string _path = path;

    public ResultResponse SaveToFile(string product)
    {
        try
        {



            using var sw = new StreamWriter(_path);
            sw.WriteLine(product);
            return new ResultResponse { Success=true};

        }
        catch (Exception) { }
        return new ResultResponse { Success = false };
    }


    public string GetFromFile()

    {
        try
        {
            if (File.Exists(_path))
            {
                using var sr = new StreamReader(_path);
                var product = sr.ReadToEnd();
                return product;
            }
        }
        catch (Exception) { }
        return null!;
    }

}
