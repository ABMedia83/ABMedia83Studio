using System;

namespace Albert.Win32
{

	public delegate void ViewTabItemEventHandler(object sender, ViewTabItemEventArgs e);

	public class ViewTabItemEventArgs: RoutedEventArgs
	{
		public ViewTabItem? TabItem { get; set; }
	}
}
