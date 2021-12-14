﻿using System.Globalization;
using Foundation;
using UIKit;

namespace Microsoft.Maui.Platform
{
	public static class DatePickerExtensions
	{
		public static void UpdateFormat(this MauiDatePicker nativeDatePicker, IDatePicker datePicker)
		{
			nativeDatePicker.UpdateDate(datePicker, null);
		}

		public static void UpdateFormat(this MauiDatePicker nativeDatePicker, IDatePicker datePicker, UIDatePicker? picker)
		{
			nativeDatePicker.UpdateDate(datePicker, picker);
		}

		public static void UpdateDate(this MauiDatePicker nativeDatePicker, IDatePicker datePicker)
		{
			nativeDatePicker.UpdateDate(datePicker, null);
		}
						
		public static void UpdateTextColor(this MauiDatePicker nativeDatePicker, IDatePicker datePicker, UIColor? defaultTextColor)
		{
			var textColor = datePicker.TextColor;

			if (textColor == null)
				nativeDatePicker.TextColor = defaultTextColor;
			else
				nativeDatePicker.TextColor = textColor.ToNative();

			// HACK This forces the color to update; there's probably a more elegant way to make this happen
			nativeDatePicker.UpdateDate(datePicker);
		}

		public static void UpdateDate(this MauiDatePicker nativeDatePicker, IDatePicker datePicker, UIDatePicker? picker)
		{
			if (picker != null && picker.Date.ToDateTime().Date != datePicker.Date.Date)
				picker.SetDate(datePicker.Date.ToNSDate(), false);

			// Can't use Element.Format because it won't display the correct format if the region and language are set differently
			if (picker != null && string.IsNullOrWhiteSpace(datePicker.Format) || datePicker.Format.Equals("d") || datePicker.Format.Equals("D"))
			{
				NSDateFormatter dateFormatter = new NSDateFormatter();
				dateFormatter.TimeZone = NSTimeZone.FromGMT(0);

				if (datePicker.Format?.Equals("D") == true)
				{
					dateFormatter.DateStyle = NSDateFormatterStyle.Long;
					var strDate = dateFormatter.StringFor(picker?.Date);
					nativeDatePicker.Text = strDate;
				}
				else
				{
					dateFormatter.DateStyle = NSDateFormatterStyle.Short;
					var strDate = dateFormatter.StringFor(picker?.Date);
					nativeDatePicker.Text = strDate;
				}
			}
			else if (datePicker.Format.Contains("/"))
			{
				nativeDatePicker.Text = datePicker.Date.ToString(datePicker.Format, CultureInfo.InvariantCulture);
			}
			else
			{
				nativeDatePicker.Text = datePicker.Date.ToString(datePicker.Format);
			}

			nativeDatePicker.UpdateCharacterSpacing(datePicker);
		}

		public static void UpdateMinimumDate(this MauiDatePicker nativeDatePicker, IDatePicker datePicker)
		{
			nativeDatePicker.UpdateMinimumDate(datePicker, null);
		}

		public static void UpdateMinimumDate(this MauiDatePicker nativeDatePicker, IDatePicker datePicker, UIDatePicker? picker)
		{
			if (picker != null)
			{
				picker.MinimumDate = datePicker.MinimumDate.ToNSDate();
			}
		}

		public static void UpdateMaximumDate(this MauiDatePicker nativeDatePicker, IDatePicker datePicker)
		{
			nativeDatePicker.UpdateMaximumDate(datePicker, null);
		}

		public static void UpdateMaximumDate(this MauiDatePicker nativeDatePicker, IDatePicker datePicker, UIDatePicker? picker)
		{
			if (picker != null)
			{
				picker.MaximumDate = datePicker.MaximumDate.ToNSDate();
			}
		}

		public static void UpdateTextAlignment(this MauiDatePicker nativeDatePicker, IDatePicker datePicker)
		{
			// TODO: Update TextAlignment based on the EffectiveFlowDirection property.
		}
	}
}