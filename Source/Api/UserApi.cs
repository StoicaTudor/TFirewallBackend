using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TFirewall.Source.Dtos.User;
using TFirewall.Source.Dtos.User.UserProfileDelete;
using TFirewall.Source.Service.User.UserCrudService;
using TFirewall.Source.SystemConfig;
using TFirewall.Source.UserAppConfig.AppState;
using TFirewall.Source.UserAppConfig.Entities;
using Unity;

namespace TFirewall.Source.Api;

[Route(ApiConstants.UserApiConstants.Root)]
[ApiController]
public class UserApi : ControllerBase
{
    private readonly IUserCrudService _userCrudService;
    private readonly IAppState _appState;
    private readonly IMapper _mapper;

    public UserApi()
    {
        IUnityContainer container = IocConfig.GetConfiguredContainer();
        _userCrudService = container.Resolve<IUserCrudService>();
        _appState = container.Resolve<IAppState>();
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
        Ok((await _userCrudService.GetAllUsersAsync()).Select(UserFetchResponseDto.FromUser));
    // Ok(_mapper.Map<IEnumerable<UserFetchResponseDto>>(await _userCrudService.GetAllUsersAsync()));

    [HttpPost(ApiConstants.UserApiConstants.CreateUserProfile)]
    public async Task<UserProfileCreationResponseDto> CreateUserProfile(UserProfileCreationDto dto)
    {
        UserProfile userProfile = await _userCrudService.CreateUserProfile(_mapper.Map<UserProfile>(dto));
        return _mapper.Map<UserProfileCreationResponseDto>(userProfile);
    }
    
    [HttpPut(ApiConstants.UserApiConstants.UpdateUserProfile)]
    public async Task<UserProfileUpdateResponseDto> UpdateUserProfile(UserProfileEditDto dto)
    {
        UserProfile userProfile = await _userCrudService.UpdateUserProfile(_mapper.Map<UserProfile>(dto));
        return _mapper.Map<UserProfileUpdateResponseDto>(userProfile);
    }
    
    [HttpDelete(ApiConstants.UserApiConstants.DeleteUserProfile)]
    public async Task<UserProfileDeletionResponseDto> DeleteUserProfile(string profileId)
    {
        await _userCrudService.DeleteUserProfileAsync(profileId);
        return new();
    }

    [HttpPost(ApiConstants.UserApiConstants.SetActiveUserProfile)]
    public async Task SetActiveUserProfile(string userProfileId)
    {
        UserProfile userProfile = await _userCrudService.GetUserProfile(userProfileId);
        _appState.SetActiveUserProfile(userProfile);
        // await _userCrudService.CreateUserProfile(_mapper.Map<UserProfile>(dto));
    }
}