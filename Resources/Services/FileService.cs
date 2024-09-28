
using Resources.Response;
using System.Reflection.Metadata.Ecma335;

namespace Resources.Services;

internal class FileService
{
    private readonly string _path;

    public FileService(string path)
    {
        _path = path;
    }

    public ResultResponse SaveToFile(string product)
    {
        try
        {
            if (File.Exists(_path))
            {

                using var sw = new StreamWriter(_path);
                sw.WriteLine(product);
                return ResultResponse.Succeeded();
            }
        }
        catch (Exception) { }
        return ResultResponse.Failed();
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
