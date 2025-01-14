﻿namespace TFirewall.Source.Dtos.User;

public record UserProfileCreationDto(
    bool IsActiveProfile,
    string Name,
    string UserId,
    string Content
);