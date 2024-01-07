namespace Clean.Mvc.Areas.Admin.Models.AuthViewModels;

public record LoginRequest(string Email, string Password, bool RememberMe);
