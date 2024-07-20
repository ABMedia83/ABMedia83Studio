
namespace Albert.Win32.Controls
{
	/// <summary>
	/// A Special TabItem designed to work with MVVM Pattern 
	/// </summary>
	[TemplatePart(Name = "PART_CloseButton", Type  = typeof(PushButton))]
	public sealed class ViewTabItem: TabItem 
	{
		//Field's
		PushButton? btn = new PushButton();

        //Depdendcey 


        public static readonly DependencyProperty BackgroundSelectedProperty =
    DependencyProperty.Register("BackgroundSelected", typeof(Brush), typeof(ViewTabItem),new PropertyMetadata(HexBrush("#FF1D76C5")));


        public static readonly DependencyProperty ForegroundSelectedProperty =
    DependencyProperty.Register("ForegroundSelected", typeof(Brush), typeof(ViewTabItem), new PropertyMetadata(HexBrush("#ffffff")));

        public static readonly DependencyProperty BorderBrushSelectedProperty =
    DependencyProperty.Register("BorderBrushSelected", typeof(Brush), typeof(ViewTabItem), new PropertyMetadata(HexBrush("#222222")));


        public static readonly DependencyProperty IsClosedEnabledProperty = DependencyProperty.Register("IsClosedEnabled",
			typeof(bool),typeof(ViewTabItem), new PropertyMetadata(true));

		public static readonly DependencyProperty IsPageEnabledProperty = DependencyProperty.Register("IsPageEnabled",
		typeof(bool), typeof(ViewTabItem), new PropertyMetadata(false));


		public static readonly DependencyProperty CornerRadiusProperty = DependencyProperty.Register("CornerRadius", 
			typeof(CornerRadius), typeof(ViewTabItem));

		public static readonly DependencyProperty MainTabProperty = DependencyProperty.Register("MainTab", typeof(TabControl), typeof(ViewTabItem), null);





		public ViewTabItem()
		{
			DefaultStyleKey = typeof(ViewTabItem);
			IsClosedEnabled = false;

			
		}
		public ViewTabItem(string? _header,object _content, TabControl _tab)
		{
			DefaultStyleKey = typeof(ViewTabItem);
			Header = _header;
			IsClosedEnabled = true;
			Content = _content;
			MainTab = _tab;
			SetTab();
		}
		public ViewTabItem(string _Header,bool _isClosedEnabled, object _content,TabControl _mainTabControl)
		{
			DefaultStyleKey = typeof(ViewTabItem);
			Header = _Header;
			IsClosedEnabled = _isClosedEnabled;
			Content = _content;
			MainTab = _mainTabControl;
			SetTab();
		}
		
		public override void OnApplyTemplate()
		{
			btn = GetTemplateChild("PART_CloseButton") as PushButton;
			//Closed Event to the Button 
			btn!.Click += Closed_Click;
		}

		public void SetTab()
		{
			if (MainTab != null)
				MainTab.Items.Add(this);
		}

		public event ViewTabItemEventHandler? Closed;

		public void RemoveTab()
		{
			//Remove the Tab
			MainTab.Items.Remove(this);
		}

		void OnClosed(object sender, ViewTabItemEventArgs e)
		{
			if (Closed != null)
			{
				e.TabItem = this;
				Closed(this, e);
			}
			else if (Closed == null && MainTab != null)
			{
				MainTab.Items.Remove(this);
				Content = null;
			}
		}

		void Closed_Click(object sender, RoutedEventArgs e)
		{
			var args = new ViewTabItemEventArgs();
			OnClosed(this, args);
			
		}

        //Public Properties 

   


        public Brush BackgroundSelected
        {
            get { return (Brush)GetValue(BackgroundSelectedProperty); }
            set { SetValue(BackgroundSelectedProperty, value); }
        }
        public Brush ForegroundSelected
        {
            get { return (Brush)GetValue(ForegroundSelectedProperty); }
            set { SetValue(ForegroundSelectedProperty, value); }
        }
        public Brush BorderBrushSelected
        {
            get { return (Brush)GetValue(BorderBrushSelectedProperty); }
            set { SetValue(BorderBrushSelectedProperty, value); }
        }

        public CornerRadius CornerRadius
		{
			get { return (CornerRadius)GetValue(CornerRadiusProperty); }
			set { SetValue(CornerRadiusProperty, value); }
		}


		public TabControl MainTab
		{
			get { return (TabControl)GetValue(MainTabProperty); }
			set { SetValue(MainTabProperty, value); }
		}


		public bool IsClosedEnabled
		{
			get { return (bool)GetValue(IsClosedEnabledProperty); }
			set { SetValue(IsClosedEnabledProperty, value); }
		}

	}



}
