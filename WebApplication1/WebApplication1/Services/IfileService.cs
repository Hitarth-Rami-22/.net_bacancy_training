public interface IFileService
{
    Task SaveToFileAsync(string data);
    Task<string> ReadFileAsync();
}
