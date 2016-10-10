using System.Threading.Tasks;

namespace Angular2MultiSPA.Services {
    public interface IEmailSender {
        Task SendEmailAsync(string email, string subject, string message);
    }
}
