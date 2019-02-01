using Foundation;
using UIKit;
using HelpDesk.iOS;

namespace Sample
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the
    // User Interface of the application, as well as listening (and optionally responding) to application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : UIApplicationDelegate
    {
        // class-level declarations

        public override UIWindow Window
        {
            get;
            set;
        }

        public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
        {
            // Override point for customization after application launch.
            // If not required for your application you can safely delete this method

            var version = HDClient.SharedClient().CurrentVersion;
            var sdkVersion = HDClient.SharedClient().SdkVersion;
            var imVersion = HDClient.SharedClient().ImSdkVersion;

            var manager = HDClient.SharedClient().CallManager;

            var con = new HDConversation();
            con.LoadMessagesWithType(Hyphenate.iOS.Lib.EMMessageBodyType.Text, 111111, 1, "xx", HDMessageSearchDirection.Up
            ,(NSArray arg1, HDError arg2) => { });
            return true;
        }
    }

    partial class AppDelegate : IHDClientDelegate
    {
        [Export("connectionStateDidChange:")]
        public void ConnectionStateDidChange(HConnectionState aConnectionState)
        {

        }
    }
}

