namespace Clean.WebRazorPages;

public class Auth
{
    public string? Login { get; set; }
    public string? Register { get; set; }
}

public class Product
{
    public string? GetProducts { get; set; }
}

public class EndPoints
{
    public List<Auth> Auth { get; set; } = new();
    public List<Product> Product { get; set; } = new();

}
