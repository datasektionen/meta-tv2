using Meta_TV2_BusinessLayer;
using Microsoft.AspNetCore.Mvc;

namespace Meta_TV2_api.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    IBusinessRules businessRules = new BusinessRules();
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public void Test()
    {
        //businessRules.TestMethod();
    }
}

[Route("[controller]/dbinput")]
public class TestApiRoute : ControllerBase 
{
    IBusinessRules businessRules = new BusinessRules();
    [HttpPost]
    public void addBlacklisted(string Name){
        businessRules.TestMethod(Name);
    }

    [HttpGet]
    public string getFirstAlphabetical(){
        return businessRules.getFirstAlphabetical();
    }
}
