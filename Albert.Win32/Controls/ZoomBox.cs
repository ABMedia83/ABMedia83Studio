﻿
namespace Albert.Win32.Controls
{
	/// <summary>
	/// Control designed to ZoomIn and ZoomOut Content 
	/// </summary>
	public class ZoomBox:ContentControl
	{
		public static DependencyProperty StretchProperty = DependencyProperty.Register("Stretch", typeof(Stretch), typeof(ZoomBox), new PropertyMetadata(Stretch.Uniform));

		public static DependencyProperty ZoomProperty = DependencyProperty.Register("Zoom", typeof(Thickness), typeof(ZoomBox), new PropertyMetadata(new Thickness(0)));



		/// <summary>
		/// Default Constructor 
		/// </summary>
		public ZoomBox()
		{
			//Recreate the Style
			DefaultStyleKey = typeof(ZoomBox);
		}

		public Stretch Stretch
		{
			get { return (Stretch)GetValue(StretchProperty); }
			set { SetValue(StretchProperty, value); }
		}

		public Thickness Zoom
		{
			get { return (Thickness)GetValue(ZoomProperty); }
			set { SetValue(ZoomProperty, value); }
		}
	}
}
