using System.Threading.Tasks;

namespace ScanAndGo.DependencyServices {
    public interface IAppHandler {
        Task<bool> LaunchApp(string uri);
    }
}