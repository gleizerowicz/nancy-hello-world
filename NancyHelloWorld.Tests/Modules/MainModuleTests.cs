using Nancy.Testing;
using NancyHelloWorld.Tests.TestHelpers;
using Xunit;

namespace NancyHelloWorld.Tests.Modules
{
    public class MainModuleTests : TestBase
    {
        [Fact(DisplayName = "VersionTest")]
        public void VersionTest()
        {
            var response = browser.Get("/", with =>
            {
                with.HttpRequest();
            });

            var info = response.Result.Body.AsString();

            Assert.False(string.IsNullOrEmpty(info));
        }
    }
}
