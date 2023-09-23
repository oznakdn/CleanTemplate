namespace Clean.Notification;

public class NotificationSettings
{
    public string? DisplayName { get; set; }
    public string? From { get; set; } // Sender
    public string? UserName { get; set; }
    public string? Password { get; set; }
    public string? Host { get; set; }
    public int Port { get; set; }
    public bool UseSSL { get; set; } = false;
    public bool UseStartTls { get; set; } = true;
}

