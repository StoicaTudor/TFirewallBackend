using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TFirewall.Source.Dtos.User;
using TFirewall.Source.Service.User.UserCrudService;
using TFirewall.Source.SystemConfig;
using TFirewall.Source.UserAppConfig.Entities;
using Unity;

namespace TFirewall.Source.Api;

[Route(ApiConstants.UserApiConstants.Root)]
[ApiController]
public class UserApi : ControllerBase
{
    private readonly IUserCrudService _userCrudService;
    private readonly IMapper _mapper;

    public UserApi()
    {
        IUnityContainer container = IocConfig.GetConfiguredContainer();
        _userCrudService = container.Resolve<IUserCrudService>();
        _mapper = container.Resolve<IMapper>();
    }

    [HttpPost(ApiConstants.UserApiConstants.CreateUser)]
    public async Task<IActionResult> CreateUser(UserCreationDto dto)
    {
        await _userCrudService.CreateUser(_mapper.Map<User>(dto));
        return Ok("hello");
    }

    [HttpDelete(ApiConstants.UserApiConstants.DeleteAllUsers)]
    public async Task<IActionResult> DeleteAllUsers()
    {
        await _userCrudService.DeleteAllUsers();
        return Ok();
    }

    [HttpGet(ApiConstants.UserApiConstants.GetAllUsers)]
    public async Task<IActionResult> GetAllUsers() =>
        Ok(_mapper.Map<IEnumerable<UserFetchResponseDto>>(await _userCrudService.GetAllUsers()));

    [HttpPost(ApiConstants.UserApiConstants.CreateUserProfile)]
    public async Task CreateUserProfile(UserProfileCreationDto dto)
    {
        await _userCrudService.CreateUserProfile(_mapper.Map<UserProfile>(dto));
    }
}