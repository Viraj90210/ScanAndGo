using System;
using System.Threading.Tasks;
using Foundation;
using ScanAndGo.DependencyServices;
using ScanAndGo.iOS.DependencyServices;
using UIKit;

[assembly: Xamarin.Forms.Dependency(typeof(AppHandler_iOS))]
namespace ScanAndGo.iOS.DependencyServices {
    public class AppHandler_iOS : IAppHandler {
        public Task<bool> LaunchApp(string uri) {
            var canOpen = UIApplication.SharedApplication.CanOpenUrl(new NSUrl(uri));
            if (!canOpen)
                return Task.FromResult(false);
            return Task.FromResult(UIApplication.SharedApplication.OpenUrl(new NSUrl(uri)));
        }
    }
}