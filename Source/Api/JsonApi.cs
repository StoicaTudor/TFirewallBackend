using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TFirewall.Source.Dtos.Json.JsonValidation;
using TFirewall.Source.Dtos.Json.UserProfileJsonSettingsUpload;
using TFirewall.Source.FirewallCore.Services;
using TFirewall.Source.Service.User.UserCrudService;
using TFirewall.Source.SystemConfig;
using TFirewall.Source.UserAppConfig.Entities;
using Unity;

namespace TFirewall.Source.Api;

[Route(ApiConstants.JsonApiConstants.Root)]
[ApiController]
public class JsonApi
{
    private readonly IJsonValidator _jsonValidator;
    private readonly IUserCrudService _userCrudService;
    private readonly IMapper _mapper;

    public JsonApi()
    {
        IUnityContainer container = IocConfig.GetConfiguredContainer();
        _jsonValidator = container.Resolve<IJsonValidator>();
        _userCrudService = container.Resolve<IUserCrudService>();
        _mapper = container.Resolve<IMapper>();
    }

    [HttpPost(ApiConstants.JsonApiConstants.ValidateJson)]
    public JsonValidationResponseDto ValidateJson(JsonValidationRequestDto dto) =>
        new(_jsonValidator.IsValid(dto.Json));
}