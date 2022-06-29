using Microsoft.AspNetCore.Mvc;

namespace ServiceMultiImpl.Controllers;

[ApiController]
[Route("[controller]")]
public class TestController : ControllerBase
{
    private readonly IService _service;

    public TestController(//IEnumerable<IService> services
        IFactory<IService, string> serviceFactory

        )
    {
        //_service = services.FirstOrDefault();
        _service = serviceFactory.Create("1");
    }

    [HttpGet]
    public string Get()
    {
        return _service.DoSth();
    }
}
