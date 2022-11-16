using Xamarin.UITest;

namespace Calculator.UITest
{
    public class AppInitializer
    {
        public static IApp StartApp(Platform platform)
        {
            if (platform == Platform.Android)
            {
                return ConfigureApp.Android
                    .EnableLocalScreenshots()
                    .InstalledApp("com.companyname.calculator")
                    .StartApp();
            }

            return ConfigureApp.iOS.StartApp();
        }
    }
}