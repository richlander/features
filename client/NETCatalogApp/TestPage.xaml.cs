using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Diagnostics;

using Xamarin.Forms;

namespace NETCatalogApp
{
	public partial class TestPage : ContentPage
	{
		public TestPage()
		{
			InitializeComponent();
		}

		protected override async void OnAppearing()
		{
			var client = new HttpClient();
			var url = "http://dotnet-features.azurewebsites.net/topics/";


			bool firstColumn = true;
			int row = 0;

			for (int i = 0; i < 10; i++)
			{
				var stopwatch = new Stopwatch();
				stopwatch.Restart();
				var topics = await client.GetStringAsync(url);
				stopwatch.Stop();
				var label = new Label();
				label.Text = stopwatch.ElapsedMilliseconds.ToString();

				var sl = new StackLayout
				{
					Padding = new Thickness(20, 5, 5, 5),
					Spacing = 10,
					VerticalOptions = LayoutOptions.FillAndExpand,
					Children = { label },
					BackgroundColor = Color.Transparent
				};

				TestGrid.Children.Add(sl, firstColumn ? 0 : 1, row);


				firstColumn = !firstColumn;

				if (i % 2 != 0)
				{
					row++;
				}

				base.OnAppearing();
			}
		}
	}
}