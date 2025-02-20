using System.IO;
using System.Threading.Tasks;

public class FileService : IFileService
{
    private const string FilePath = "SaveOutput.txt"; // File to save and read data

    public async Task SaveToFileAsync(string data)
    {
        using (StreamWriter writer = new StreamWriter(FilePath, true))
        {
            await writer.WriteLineAsync(data);
        }
    }

    public async Task<string> ReadFileAsync()
    {
        if (!File.Exists(FilePath))
            return "File not found.";

        using (StreamReader reader = new StreamReader(FilePath))
        {
            return await reader.ReadToEndAsync();
        }
    }
}
