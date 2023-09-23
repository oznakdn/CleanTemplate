using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;

namespace Clean.Notification.NotificationService;

public class MailService : IMailService
{
    private readonly NotificationSettings _settings;
    public MailService(IOptions<NotificationSettings> settings)
    {
        _settings = settings.Value;
    }
    public async Task<bool> SendAsync(MailData mailData, CancellationToken cancellationToken = default)
    {
        try
        {
            var mail = new MimeMessage();

            #region Sender / Receiver
            // Sender
            mail.From.Add(new MailboxAddress(_settings.DisplayName, mailData.From ?? _settings.From));
            mail.Sender = new MailboxAddress(mailData.DisplayName ?? _settings.DisplayName, mailData.From ?? _settings.From);
            #endregion

            #region Content

            // Add Content to Mime Message
            var body = new BodyBuilder();
            mail.Subject = mailData.Subject;
            body.HtmlBody = mailData.Body;
            mail.Body = body.ToMessageBody();

            #endregion

            #region Send Mail

            using var smtp = new SmtpClient();

            if (_settings.UseSSL)
            {
                await smtp.ConnectAsync(_settings.Host, _settings.Port, SecureSocketOptions.SslOnConnect, cancellationToken);
            }
            else if (_settings.UseStartTls)
            {
                await smtp.ConnectAsync(_settings.Host, _settings.Port, SecureSocketOptions.StartTls, cancellationToken);
            }
            await smtp.AuthenticateAsync(_settings.UserName, _settings.Password, cancellationToken);
            await smtp.SendAsync(mail, cancellationToken);
            await smtp.DisconnectAsync(true, cancellationToken);

            #endregion

            return true;

        }
        catch (Exception)
        {
            return false;
        }
    }
}
