using Microsoft.Toolkit.Uwp.Notifications;

namespace CustomStartup.Resources {
    public static class Notification {
        public static void SendNotification(string title, string mesage) {
            new ToastContentBuilder()
                .AddText(title)
                .AddText(mesage)
                .Show();
        }
    }
}
