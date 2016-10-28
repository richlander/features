using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
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
			var url = "http://dotnet-features.azurewebsites.net/topics";
			var watch = new Stopwatch();
			var row = 0;


			for (var i = 0; i < 10; i++)
			{
				watch.Restart();
				var s = await client.GetStringAsync(url);
				watch.Stop();

				var label = new Label();
				label.Text = watch.ElapsedMilliseconds.ToString();
				label.TextColor = Color.White;


				var sl = new StackLayout
				{
					Padding = new Thickness(20, 5, 5, 5),
					Spacing = 10,
					Orientation = StackOrientation.Horizontal,
					HorizontalOptions = LayoutOptions.FillAndExpand,
					Children = {label}
				};

				TestGrid.Children.Add(sl, 0, row++);
			}




			base.OnAppearing();
		}
	}
}
