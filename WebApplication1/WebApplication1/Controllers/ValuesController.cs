using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class ValuesController : ControllerBase
{
    private readonly IFileService _fileService;
    private readonly ILogger<ValuesController> _logger;

    // Injecting FileService
    public ValuesController(IFileService fileService, ILogger<ValuesController> logger)
    {
        _fileService = fileService;
        _logger = logger;
    }

    [HttpPost("save")]
    public async Task<bool> SaveData([FromBody] object? data)
    {
        try
        {

            if (data == null)
            {
                _logger.LogWarning("Received null data.");
                return false; //return false if data is null
            }


            string dataString = data?.ToString() ?? "Empty Data";
            _logger.LogInformation($"Received Data: {dataString}"); 
            Console.WriteLine($"Data in Console: {dataString}");

            

            
            string filePath = "SaveOutput.txt";

            using (StreamWriter streamwriter = new StreamWriter(filePath, true))
            {
                streamwriter.WriteLine(data?.ToString());
            }

            // NEW: USING FILESERVICE FOR FILE SAVING (RECOMMENDED WAY)
            await _fileService.SaveToFileAsync(dataString);

            return true;
        }
        catch (Exception)
        {
            _logger.LogError($"Error saving data: "); 
            return false;
        }
    }
}