using Xamarin.Forms;
using NETCatalogApp;

namespace NETCatalog
{
    public class NETCatalogApp : Application
    {
        public NETCatalogApp()
        {
			MainPage = new NavigationPage(new TestPage())
			{
				BarBackgroundColor = Color.FromHex("#212238"),
				BarTextColor = Color.FromHex("#FFFFFF")
			};
        }
    }
}