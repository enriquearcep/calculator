using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace Calculator.UITest
{
    [TestFixture(Platform.Android)]
    //[TestFixture(Platform.iOS)]
    public class Tests
    {
        IApp app;
        Platform platform;

        public Tests(Platform platform)
        {
            this.platform = platform;
        }

        [SetUp]
        public void BeforeEachTest()
        {
            app = AppInitializer.StartApp(platform);
        }

        [Test]
        public void WelcomeScreen()
        {
            AppResult[] results = app.WaitForElement(c => c.Marked("Welcome to Xamarin.Forms!"));
            
            app.Screenshot("Welcome screen.").CopyTo($@"C:\me\screenshots\{TestContext.CurrentContext.Test.Name.ToLower()}_{DateTime.Now.Ticks}.png");

            Assert.IsTrue(results.Any());
        }

        [Test]
        public void SignIn()
        {
            app.Tap("mailEntry");
            app.EnterText("mailEntry", "kikin@gmail.com");

            app.Tap("passwordEntry");
            app.EnterText("passwordEntry", "kikin");

            app.Tap("signInButton");

            app.Screenshot("SignIn").CopyTo($@"C:\me\screenshots\{TestContext.CurrentContext.Test.Name.ToLower()}_{DateTime.Now.Ticks}.png");

            app.WaitForElement("welcomeLabel", "Error in navigation...", TimeSpan.FromMinutes(3));

            app.Screenshot("Dashboard").CopyTo($@"C:\me\screenshots\{TestContext.CurrentContext.Test.Name.ToLower()}_{DateTime.Now.Ticks}.png");
        }
    }
}