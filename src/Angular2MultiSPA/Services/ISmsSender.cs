using System.Threading.Tasks;

namespace Angular2MultiSPA.Services {
    public interface ISmsSender {
        Task SendSmsAsync(string number, string message);
    }
}
