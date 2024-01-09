namespace Clean.WebRazorPages.Models.AuthModels;

public record LoginRequest(string email, string password, bool isRememberMe);
