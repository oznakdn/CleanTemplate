namespace Clean.Mvc.Areas.Admin.Models.AuthViewModels;

public record LoginResponse(string AccessToken, string AccessExpire, string RefreshToken, string RefreshExpire);

