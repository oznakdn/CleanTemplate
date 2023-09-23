using Org.BouncyCastle.Asn1.Pkcs;

namespace Clean.Notification.NotificationService;

public interface IMailService
{
    Task<bool> SendAsync(MailData mailData, CancellationToken cancellationToken = default);
}
