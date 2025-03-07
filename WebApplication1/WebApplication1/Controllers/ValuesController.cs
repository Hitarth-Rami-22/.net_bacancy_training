using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class ValuesController : ControllerBase
{
    [HttpPost("save")]
    public bool SaveData([FromBody] object data)
    {
        try
        {
            Console.WriteLine(data.ToString());
            string filePath = "SaveOutput.txt";
            
                using (StreamWriter streamwriter = new StreamWriter(filePath, true))
                {
                    streamwriter.WriteLine(data.ToString());
                }
            
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }
    }