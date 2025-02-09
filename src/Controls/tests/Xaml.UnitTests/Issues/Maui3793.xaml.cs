using Microsoft.Maui.Controls.Core.UnitTests;
using Microsoft.Maui.Essentials;
using NUnit.Framework;

namespace Microsoft.Maui.Controls.Xaml.UnitTests
{
	public partial class Maui3793 : ContentPage
	{
		public Maui3793() => InitializeComponent();
		public Maui3793(bool useCompiledXaml)
		{
			//this stub will be replaced at compile time
		}

		[TestFixture]
		class Tests
		{
			[SetUp] public void Setup() => AppInfo.SetCurrent(new MockAppInfo());
			[TearDown] public void TearDown() => AppInfo.SetCurrent(null);

			[Test]
			public void ControlTemplateFromStyle([Values(false, true)] bool useCompiledXaml)
			{
				Maui3793 page;
				Assert.DoesNotThrow(() => page = new Maui3793(useCompiledXaml));
			}
		}
	}
}
