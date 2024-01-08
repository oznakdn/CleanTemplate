namespace Clean.WebRazorPages.Pages.Admin.Auth.Models;

public record LoginRequest(string email, string password, bool isRememberMe);
