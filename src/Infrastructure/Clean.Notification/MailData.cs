namespace Clean.Notification;

public class MailData
{
    // Receiver
    public string To { get; }
    // Sender
    public string? From { get; }
    public string? DisplayName { get; }
    // Content
    public string Subject { get; }
    public string? Body { get; }

    public MailData(string to, string subject, string? from = null, string? displayName = null, string? body = null)
    {
        To = to; 
        From = from;
        DisplayName = displayName; 
        Subject = subject;
        Body = body;
    }
}
