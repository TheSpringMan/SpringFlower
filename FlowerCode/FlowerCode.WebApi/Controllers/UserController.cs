using Microsoft.AspNetCore.Mvc;
using FlowerCode.Service;
using FlowerCode.Model;

namespace FlowerCode.Controllers;
[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserService userService;

    public UserController(IUserService userService)
    {
        this.userService = userService;
    }
    [HttpPost("Register")]
    public ApiResult Register(RegisterReq req)
    {
        string msg = "";
        var user = userService.Register(req, ref msg);
        ApiResult result = new ApiResult();
        result.IsSuccess = user != null;
        result.Msg = msg;
        result.Result = user;
        return result;
    }
    [HttpGet("GetAllUser")]
    public IActionResult Get()
    {
        return Ok(this.userService.GetAllUser());
    }
}
