
namespace Albert.Win32.Controls;
  
public delegate void ColorChangedEventHandler(Color _color);
/// <summary>
/// Image that can be used as aCOlorPicker 
/// </summary>
public sealed class ImageColorCanvas:Image,IAddCommand 
{
    #region Field's
    RenderTargetBitmap? cachedTargetBitmap;
    Point position = new Point();
    #endregion

    #region Depdencey Properties 

    public static readonly DependencyProperty SelectorProperty
= DependencyProperty.Register("Selector", typeof(Drawing), typeof(ImageColorCanvas)
, new FrameworkPropertyMetadata(new GeometryDrawing(Brushes.White, new Pen(Brushes.Black, 1)
        , new EllipseGeometry(new Point(), 5, 5))
    , FrameworkPropertyMetadataOptions.AffectsRender)
    , ValidateSelector);

    public static readonly DependencyProperty SelectedColorProperty
   = DP("SelectedColor", typeof(Color), typeof(ImageColorCanvas),Colors.Black);


    



    #endregion

    #region Constructor 

    public ImageColorCanvas()
    {
        AddCommand(DesktopCommands.Export, (sender, e) =>
         {
             var (title, fitler) = ("Export Image", "Png Format(.png)|*.png)");

             SaveDialogTask(title, fitler, (s, i) =>
               {
                   //Create Png Image 
                   CreatePng(s.FileName, 96, this);
               });

         });
    }


    #endregion

    #region IAddCommand

    /// <summary>
    /// Quick way to add a Coomamand to the control
    /// </summary>
    /// <param name="_command"></param>
    /// <param name="_method"></param>
    public void AddCommand(ICommand _command, ExecutedRoutedEventHandler _method)
    {
        CommandBindings.Add(new CommandBinding(_command, _method));
    }


    #endregion


    #region Events 

    public event ColorChangedEventHandler? OnColorSelected;

    #endregion 


    #region Override's 
    protected override void OnRender(DrawingContext dc)
    {
        base.OnRender(dc);

        if (ActualWidth == 0 || ActualHeight == 0)
            return;

        // Render the SelectorDrawing
        dc.PushTransform(new TranslateTransform(Position.X, Position.Y));
        dc.DrawDrawing(Selector);
        dc.Pop();
    }


    protected override void OnRenderSizeChanged(SizeChangedInfo sizeInfo)
    {
        base.OnRenderSizeChanged(sizeInfo);

        cachedTargetBitmap = null; // TargetBitmap cache isn't valid anymore.
                                   // Adjust the selector position proportionally to size change.
        if (sizeInfo.PreviousSize.Width > 0 && sizeInfo.PreviousSize.Height > 0)
            Position = new Point(Position.X * sizeInfo.NewSize.Width / sizeInfo.PreviousSize.Width
                , Position.Y * sizeInfo.NewSize.Height / sizeInfo.PreviousSize.Height);
    }





    protected override void OnPropertyChanged(DependencyPropertyChangedEventArgs e)
    {
        if (e.Property.Name == "Source")
        {
            cachedTargetBitmap = null; // TargetBitmap cache isn't valid anymore.
            Position = new Point(); // Move the selector to the top-left corner.
        }
        //Execute OnColorSelected 
        var color = this.SelectedColor;
        OnColorSelected?.Invoke(color);

 

        base.OnPropertyChanged(e);
    }

    protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
    {
        base.OnMouseLeftButtonDown(e);
        SetPositionIfInBounds(e.GetPosition(this));
    }

    protected override void OnMouseLeftButtonUp(MouseButtonEventArgs e)
    {
        base.OnMouseLeftButtonUp(e);
        SetPositionIfInBounds(e.GetPosition(this));
    }

    protected override void OnMouseMove(MouseEventArgs e)
    {
        base.OnMouseMove(e);
        if (e.LeftButton == MouseButtonState.Pressed)
            SetPositionIfInBounds(e.GetPosition(this));
    }

    protected override void OnMouseEnter(MouseEventArgs e)
    {
        base.OnMouseEnter(e);
        if (e.LeftButton == MouseButtonState.Pressed)
        {
            Point mousePoint = e.GetPosition(this);
            Position = new Point(mousePoint.X, mousePoint.Y);
        }
    }


    #endregion

    #region Method's
    /// <summary>
    /// Method to Load Image
    /// </summary>
    public void GetAImage()
    {
        (string title, string filter) = DialogInfoTuple("Load a Bitmap", MakeFilter("Png", ".png"));

        SaveDialogTask(title, filter, (s,i) =>
          {
              //Load the Image 
              LoadImageFile(this, s.FileName);
          
          });
    }
    /// <summary>
    /// Get the position restricted by the element bounds.
    /// </summary>
    /// <param name="point">The point.</param>
    /// <returns></returns>
    Point RestrictedPosition(Point point)
    {
        double x = point.X, y = point.Y;

        if (x < 0)
            x = 0;
        else if (x > ActualWidth)
            x = ActualWidth;

        if (y < 0)
            y = 0;
        else if (y > ActualHeight)
            y = ActualHeight;

        return new Point(x, y);
    }

    /// <summary>
    /// Sets the <paramref name="pt"/> as the new position if the point falls 
    /// into the element bounds.
    /// </summary>
    /// <param name="pt">The point.</param>
    void SetPositionIfInBounds(Point pt)
    {
        if (pt.X >= 0 && pt.X <= ActualWidth && pt.Y >= 0 && pt.Y <= ActualHeight)
            Position = pt;
    }
    /// <summary>
    /// Method that returns the picked color 
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <returns></returns>
    public Color PickColor(double x, double y)
    {
        if (Source == null)
            throw new InvalidOperationException("Image Source not set");

        if (Source is BitmapSource bitmapSource)
        { // Get color from bitmap pixel.
          // Convert coopdinates from WPF pixels to Bitmap pixels and restrict them by the Bitmap bounds.
            x *= bitmapSource.PixelWidth / ActualWidth;
            if ((int)x > bitmapSource.PixelWidth - 1)
                x = bitmapSource.PixelWidth - 1;
            else if (x < 0)
                x = 0;
            y *= bitmapSource.PixelHeight / ActualHeight;
            if ((int)y > bitmapSource.PixelHeight - 1)
                y = bitmapSource.PixelHeight - 1;
            else if (y < 0)
                y = 0;

            // Lee Brimelow approach (http://thewpfblog.com/?p=62).
            //byte[] pixels = new byte[4];
            //CroppedBitmap cb = new CroppedBitmap(bitmapSource, new Int32Rect((int)x, (int)y, 1, 1));
            //cb.CopyPixels(pixels, 4, 0);
            //return Color.FromArgb(pixels[3], pixels[2], pixels[1], pixels[0]);

            // Alternative approach
            if (bitmapSource.Format == PixelFormats.Indexed4)
            {
                byte[] pixels = new byte[1];
                int stride = (bitmapSource.PixelWidth * bitmapSource.Format.BitsPerPixel + 3) / 4;
                bitmapSource.CopyPixels(new Int32Rect((int)x, (int)y, 1, 1), pixels, stride, 0);

                Debug.Assert(bitmapSource.Palette != null, "bitmapSource.Palette != null");
                Debug.Assert(bitmapSource.Palette.Colors.Count == 16, "bitmapSource.Palette.Colors.Count == 16");
                return bitmapSource.Palette.Colors[pixels[0] >> 4];
            }
            else if (bitmapSource.Format == PixelFormats.Indexed8)
            {
                byte[] pixels = new byte[1];
                int stride = (bitmapSource.PixelWidth * bitmapSource.Format.BitsPerPixel + 7) / 8;
                bitmapSource.CopyPixels(new Int32Rect((int)x, (int)y, 1, 1), pixels, stride, 0);

                Debug.Assert(bitmapSource.Palette != null, "bitmapSource.Palette != null");
                Debug.Assert(bitmapSource.Palette.Colors.Count == 256, "bitmapSource.Palette.Colors.Count == 256");
                return bitmapSource.Palette.Colors[pixels[0]];
            }
            else
            {
                byte[] pixels = new byte[4];
                int stride = (bitmapSource.PixelWidth * bitmapSource.Format.BitsPerPixel + 7) / 8;
                bitmapSource.CopyPixels(new Int32Rect((int)x, (int)y, 1, 1), pixels, stride, 0);

                return Color.FromArgb(pixels[3], pixels[2], pixels[1], pixels[0]);
            }
            // TODO There are other PixelFormats which processing should be added if desired.
        }

        if (Source is DrawingImage drawingImage)
        { // Get color from drawing pixel.
            RenderTargetBitmap targetBitmap = TargetBitmap;
            Debug.Assert(targetBitmap != null, "targetBitmap != null");

            // Convert coopdinates from WPF pixels to Bitmap pixels and restrict them by the Bitmap bounds.
            x *= targetBitmap.PixelWidth / ActualWidth;
            if ((int)x > targetBitmap.PixelWidth - 1)
                x = targetBitmap.PixelWidth - 1;
            else if (x < 0)
                x = 0;
            y *= targetBitmap.PixelHeight / ActualHeight;
            if ((int)y > targetBitmap.PixelHeight - 1)
                y = targetBitmap.PixelHeight - 1;
            else if (y < 0)
                y = 0;

            // TargetBitmap is always in PixelFormats.Pbgra32 format.
            // Pbgra32 is a sRGB format with 32 bits per pixel (BPP). Each channel (blue, green, red, and alpha)
            // is allocated 8 bits per pixel (BPP). Each color channel is pre-multiplied by the alpha value. 
            byte[] pixels = new byte[4];
            int stride = (targetBitmap.PixelWidth * targetBitmap.Format.BitsPerPixel + 7) / 8;
            targetBitmap.CopyPixels(new Int32Rect((int)x, (int)y, 1, 1), pixels, stride, 0);
            return Color.FromArgb(pixels[3], pixels[2], pixels[1], pixels[0]);
        }

        throw new InvalidOperationException("Unsupported Image Source Type");
    }

 
    #endregion

    #region Public Properties 

    #region SelectedColor


    /// <summary>
    /// Gets or sets the color selected.
    /// </summary>
    /// <value>The color selected.</value>
    public Color SelectedColor
    {
        get => (Color)GetValue(SelectedColorProperty);
        set
        {
           
            SetValue(SelectedColorProperty, value);
        }
    }


    
    #endregion 

    #region Selector
    /// <summary>
    /// Selector property backing DependencyProperty.
    /// </summary>

    /// <summary>
    /// Validates the suggested selector drawing value.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns><c>true</c> if suggested value isn't null; otherwise <c>false</c>.</returns>
    static bool ValidateSelector(object value)
    {
        return value == null ? false : true;
    }
    /// <summary>
    /// Gets or sets the selector drawing.
    /// </summary>
    /// <value>The selector drawing. Must not be null</value>
    /// <remarks>
    /// <see cref="SelectorDrawing"/> is the <see cref="System.Windows.Media.Drawing"/> using
    /// to mark the position where the color is selected.
    /// <para>The <see cref="ImageColorCanvas"/> desn't pose any restrictions on the size of
    /// this drawing. It's the user duty to choose it resonably.</para>
    /// </remarks>
    public Drawing Selector
    {
        get { return (Drawing)GetValue(SelectorProperty); }
        set { SetValue(SelectorProperty, value); }
    }
    #endregion Selector

    #region Position

    /// <summary>
    /// Gets or sets the Selector Position.
    /// </summary>
    /// <value>The position.</value>
    public Point Position
    {
        get { return position; }
        set
        {
            Point newPos = RestrictedPosition(value);
            if (position != newPos)
            {
                position = newPos;
                Color color = PickColor(position.X, position.Y);
                if (color == SelectedColor)
                    InvalidateVisual();
                SetValue(SelectedColorProperty, color);
            }
        }
    }


    #endregion Position

    #region TargetBitmap
    
    /// <summary>
    /// Gets the target bitmap for the DrawingImage image Source.
    /// </summary>
    /// <value>The target bitmap.</value>
    RenderTargetBitmap TargetBitmap
    {
        get
        {
            if (cachedTargetBitmap == null)
            {
                if (Source is DrawingImage drawingImage)
                {
                    DrawingVisual drawingVisual = new DrawingVisual();
                    using (DrawingContext drawingContext = drawingVisual.RenderOpen())
                    {
                        drawingContext.DrawDrawing(drawingImage.Drawing);
                    }

                    // Scale the DrawingVisual.
                    Rect dvRect = drawingVisual.ContentBounds;
                    drawingVisual.Transform = new ScaleTransform(ActualWidth / dvRect.Width
                        , ActualHeight / dvRect.Height);

                    cachedTargetBitmap = new RenderTargetBitmap((int)ActualWidth
                        , (int)ActualHeight, 96, 96, PixelFormats.Pbgra32);
                    cachedTargetBitmap.Render(drawingVisual);
                }
            }
            return cachedTargetBitmap!;
        }
    }
    #endregion TargetBitmap

    #endregion



}
