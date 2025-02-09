﻿using System;
using Microsoft.Maui.Controls.Xaml;
using Microsoft.Maui.Essentials;
using Microsoft.Maui.Graphics;

namespace Microsoft.Maui.Controls.Compatibility.ControlGallery
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ButtonBorderBackgroundGalleryPage : ContentPage
	{
		public ButtonBorderBackgroundGalleryPage()
			: this(VisualMarker.MatchParent)
		{
		}

		public ButtonBorderBackgroundGalleryPage(IVisual visual)
		{
			InitializeComponent();
			Visual = visual;

			// buttons are transparent on default iOS, so we have to give them something
			if (DeviceInfo.Platform == DevicePlatform.iOS)
			{
				if (Visual != VisualMarker.Material)
				{
					SetBackground(Content);

					void SetBackground(View view)
					{
						if (view is Button button && !button.IsSet(Button.BackgroundColorProperty))
							view.BackgroundColor = Colors.LightGray;

						if (view is Layout layout)
						{
							foreach (var child in layout.Children)
							{
								if (child is View childView)
									SetBackground(childView);
							}
						}
					}
				}
			}
		}

		void HandleChecks_Clicked(object sender, System.EventArgs e)
		{
			var thisButton = sender as Button;
			var layout = thisButton.Parent as Layout;
			foreach (var child in layout.Children)
			{
				var button = child as Button;

				Console.WriteLine($"{button.Text} => {button.Bounds}");
			}
		}
	}
}
