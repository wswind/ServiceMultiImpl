using Microsoft.AspNetCore.Mvc;

namespace ServiceMultiImpl.Controllers;

[ApiController]
[Route("[controller]")]
public class TestController : ControllerBase
{
    private readonly IService _service;

    public TestController(IEnumerable<IService> services)
    {
        _service = services.FirstOrDefault();
    }

    [HttpGet]
    public string Get()
    {
        return _service.DoSth();
    }
}
