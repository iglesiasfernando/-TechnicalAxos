using IsacMobile.Services;
using TechnicalAxos.ViewModels;

namespace TestApp
{
    [TestFixture]
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            Xamarin.Forms.Mocks.MockForms.Init();
            
        }

        [Test]
        public void TestCountriesNull()
        {
            var viewModel = new MainPageViewModel();
            var countries = viewModel.Countries;
            Assert.IsNotNull(countries);
        }

        [Test]
        public void TestService()
        {
            var countries = ApiService.GetCountries().Result;
            Assert.That(countries.Count, Is.GreaterThanOrEqualTo(0));
        }


    }
}