using System;

using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace xamarinmaps
{
	public class App : Application 
	{
		public App() {
			var position = new Position(38.924318, -77.228214);
			var map = new Map(
			  MapSpan.FromCenterAndRadius(
			position, Distance.FromMiles(0.3))) {
				IsShowingUser = true,
				HeightRequest = 600,
				WidthRequest = 960,
				VerticalOptions = LayoutOptions.FillAndExpand
					
			};
			//map.MapType == MapType.Street;
			var stack = new StackLayout { 
				VerticalOptions = LayoutOptions.Center,
				Spacing = 0 };
			stack.Children.Add(map);
			var slider = new Slider (10, 18, 17);
			slider.ValueChanged += (sender, e) => {
				var zoomLevel = e.NewValue; // between 9 and 18
				var latlongdegrees = 360 / (Math.Pow(2, zoomLevel));
				map.MoveToRegion(new MapSpan (map.VisibleRegion.Center, latlongdegrees, latlongdegrees));
			};
		
			var pin = new Pin {
				Type = PinType.Place,
				Position = position,
				Label = "OSTGlobal",
				Address =38.924318 +"latitude"+ -77.228214+" longitude"
			};
			map.Pins.Add(pin);



			stack.Children.Add(slider);
			View v = stack;
			MainPage = new ContentPage {
				Content = v

			};
			 
		}
	}
}

