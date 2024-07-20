

namespace Albert.Win32.Controls
{
    /// <summary>
    /// Modified InkCanvas for doing more realistic art work
    /// </summary>
    public sealed class DrawCanvas : InkCanvas, IAddCommand
    {

      

        #region Depedency Properties 

        public static readonly DependencyProperty DrawModeProperty = DP("DrawMode", typeof(DrawMode), typeof(DrawCanvas), DrawMode.Draw);

        public static readonly DependencyProperty BrushColorProperty = DP("BrushColor", typeof(Color), typeof(DrawCanvas), Colors.Black);

        public static readonly DependencyProperty BrushSizeProperty = DP("BrushSize", typeof(double), typeof(DrawCanvas), 10.4, (sender, e) =>
            {
                var board = (DrawCanvas)sender;
                board.DefaultDrawingAttributes.Width = (double)e.NewValue;
                board.DefaultDrawingAttributes.Height = (double)e.NewValue;
            });

        public static readonly DependencyProperty StylusTipProperty = DP("StylusTip", typeof(StylusTip), typeof(DrawCanvas), StylusTip.Ellipse, (sender, e) =>
            {
                var board = sender as DrawCanvas;

                //Link to StylusTip 
                board!.DefaultDrawingAttributes.StylusTip = (StylusTip)e.NewValue;

            });

        public static readonly DependencyProperty BrushOpacityProperty = DP("BrushOpacity", typeof(byte), typeof(DrawCanvas));

        public static readonly DependencyProperty DrawTipTypeProperty = DP("DrawTipType", typeof(DrawTipType), typeof(DrawCanvas));

        public static readonly DependencyProperty PencilOpacityProperty = DP("PencilOpacity", typeof(byte), typeof(DrawCanvas));
        
        public static readonly DependencyProperty MarkerOpacityProperty = DP("MarkerOpacity", typeof(byte), typeof(DrawCanvas));
        
        public static readonly DependencyProperty PenOpacityProperty = DP("PenOpacity", typeof(byte), typeof(DrawCanvas));



        protected override void OnPropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            //Get the Brush Opacity  
            var alpha = BrushOpacity;
            //Color 
            var color = BrushColor;
        
            //Set the color based on opacity 
            var setcolor = Color.FromArgb(alpha, color.R, color.G, color.B);
            //Set Bursh Color on Artboard 
            DefaultDrawingAttributes.Color = setcolor;
            //Set the Brush Color 
            BrushColor = setcolor;


           
            
            

            

            base.OnPropertyChanged(e);
        }





        #endregion

        #region Constuctor  
        /// <summary>
        /// Default Constructor 
        /// </summary>
        public DrawCanvas()
        {
            BrushOpacity = 60;

            PencilOpacity = 60;
            MarkerOpacity = 100;
            PenOpacity = 255;

            BrushOpacity = 75;

            //Declare UndoStrokes 
            UndoStrokes = new StrokeCollection();

            //Undo Command  
            AddCommand(ApplicationCommands.Undo, (sender, e) =>
             {
                 if(Strokes.Count >= 1)
                 {
                    // Clone the Strokes 
                    UndoStrokes = Strokes.Clone();
                    Strokes.RemoveAt(Strokes.Count - 1);
                 }
             });

            //Redo Command 
            AddCommand(ApplicationCommands.Redo, (sender, e) =>
           {
               if(UndoStrokes.Count >= 1)
               {
                   Strokes = UndoStrokes.Clone();
               }

           });

          






        }
        #endregion

        #region Method's and Tuple's 




        #endregion

        #region Public Properties 

        public DrawTipType DrawTipType
        {
            get => (DrawTipType)GetValue(DrawTipTypeProperty);
            set
            {
                SetValue(DrawTipTypeProperty, value);

                switch(value)
                {
                    case DrawTipType.Pencil:
                        StylusTip = StylusTip.Ellipse;
                         BrushOpacity = PencilOpacity;
                        break;
                    case DrawTipType.Marker:
                        StylusTip = StylusTip.Rectangle;
                        BrushOpacity = MarkerOpacity;
                        break;
                    case DrawTipType.Pen:
                        StylusTip = StylusTip.Ellipse;
                        BrushOpacity = PenOpacity;
                        break;
                }

            }
        }

        public byte PencilOpacity
        {
            get => (byte)GetValue(PencilOpacityProperty);
            set => SetValue(PencilOpacityProperty, value);
        }

        public byte MarkerOpacity
        {
            get => (byte)GetValue(MarkerOpacityProperty);
            set => SetValue(MarkerOpacityProperty, value);
        }



        public byte PenOpacity
        {
            get =>(byte)GetValue(PenOpacityProperty);
            set => SetValue(PenOpacityProperty, value);
        }

        public StrokeCollection UndoStrokes
        {
            get;
            set;
        }

        /// <summary>
        /// Get or set the Current DrawMode 
        /// </summary>
        public DrawMode DrawMode
        {
            get { return (DrawMode)GetValue(DrawModeProperty); }
            set
            {
                SetValue(DrawModeProperty, value);

                switch (value)
                {
                    case DrawMode.Draw:
                        EditingMode = InkCanvasEditingMode.Ink;
                        break;
                    case DrawMode.Erase:
                        EditingMode = InkCanvasEditingMode.EraseByPoint;
                        break;
                    case DrawMode.EraseByStroke:
                        EditingMode = InkCanvasEditingMode.EraseByStroke;
                        break;
                    case DrawMode.Select:
                        EditingMode = InkCanvasEditingMode.Select;
                        break;

                }
            }
        }

        /// <summary>
        /// Gets or set Brush Opacity based on the ARGB scale 
        /// </summary>
        [Category("Common")]
        public byte BrushOpacity
        {
            get { return (byte)GetValue(BrushOpacityProperty); }
            set { SetValue(BrushOpacityProperty, value); }
        }
        /// <summary>
        /// Get or set the BrushSize that your drawing with 
        /// </summary>
        [Category("Common")]
        public double BrushSize
        {
            get { return (double)GetValue(BrushSizeProperty); }
            set { SetValue(BrushSizeProperty, value); }
        }
        /// <summary>
        /// Get or set Brush Color that drawing with 
        /// </summary>
        [Category("Common")]
        public Color BrushColor
        {
            get { return (Color)GetValue(BrushColorProperty); }
            set { SetValue(BrushColorProperty, value); }
        }
        /// <summary>
        /// Get or sets the StylusTip Type 
        /// </summary>
        [Category("Common")]
        public StylusTip StylusTip
        {
            get { return (StylusTip)GetValue(StylusTipProperty); }
            set { SetValue(StylusTipProperty, value); }
        }

        /// <summary>
        /// Add a Command Quickly 
        /// </summary>
        /// <param name="_command"></param>
        /// <param name="_method"></param>
        public void AddCommand(ICommand _command, ExecutedRoutedEventHandler _method)
        {
            CommandBindings.Add(new CommandBinding(_command, _method));
        }






        #endregion

    }

    public enum DrawMode
    {
        Draw, Erase, EraseByStroke, Select
    }

    public enum DrawTipType 
    {
        Pencil,Marker,Pen
    }

}
