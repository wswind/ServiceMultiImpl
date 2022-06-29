using Microsoft.AspNetCore.Mvc;

namespace ServiceMultiImpl.Controllers;

[ApiController]
[Route("[controller]")]
public class TestController : ControllerBase
{
    private readonly IService _service;

    public TestController(
        IMultiImplServiceFactory<IService, string> serviceFactory
        )
    {
        _service = serviceFactory.Create("2");
    }

    [HttpGet]
    public string Get()
    {
        if (_service == null)
            return "not implemented service";
        return _service.DoSth();
    }
}
