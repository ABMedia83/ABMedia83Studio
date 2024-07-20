using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using static Albert.Win32.MediaConvert;
namespace Albert.Win32.Controls
{
    #region DialogState 
    public enum DialogState
    {
        New,Open,Save,Import,Export,Close
    }
    #endregion 

    [TemplatePart(Name = "PART_tbMessage", Type = typeof(TextBlock))]
    [TemplatePart(Name = "PART_btnOne", Type = typeof(PushButton))]
    [TemplatePart(Name = "PART_btnTwo", Type = typeof(PushButton))]
    public  class ViewDialog : ContentControl, IAddCommand
    {
        #region Field's 
        //Field's
        //Controls 
        TextBlock? tbMessage = new TextBlock();
        PushButton? btnOne = new PushButton();
        PushButton? btnTwo = new PushButton();
        
   
        //Actions 
        Action? onBtnOne, onBtnTwo;

        //Depdencey Propertey 
        public  static readonly DependencyProperty TitleProperty = DP("Title", typeof(string), typeof(ViewDialog));

        public static readonly DependencyProperty MessageProperty = DP("Message", typeof(string), typeof(ViewDialog));

        public static readonly DependencyProperty ButtonTextOneProperty = DP("ButtonTextOne", typeof(string), typeof(ViewDialog));

        public static readonly DependencyProperty TitleAlignmentProperty = DP("TitleAlignment", typeof(TextAlignment), typeof(ViewDialog));

        public static readonly DependencyProperty ButtonTextTwoProperty = DP("ButtonTextTwo", typeof(string), typeof(ViewDialog));

        public static readonly DependencyProperty IsButtonsHiddenProperty = DP("IsButtonsHidden", typeof(bool), typeof(ViewDialog));

            
      


        #endregion

        public ViewDialog()
        {
            //ReDraw the Control 
            DefaultStyleKey = typeof(ViewDialog);
            //Make Hidden by default 
            Visibility = Visibility.Collapsed;
            Focus();
         


        }
        protected override void OnPropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            base.OnPropertyChanged(e);

            if (IsButtonsHidden == true)
            {
                btnOne!.Visibility = Visibility.Collapsed;
                btnTwo!.Visibility = Visibility.Collapsed;
            }
            else if (IsButtonsHidden == false)
            {
                btnOne!.Visibility = Visibility.Visible;
                btnTwo!.Visibility = Visibility.Visible;
            }

        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            //Message TextBlock  
            tbMessage = GetTemplateChild("PART_tbMessage") as TextBlock;
            
            //Button One 
            btnOne = GetTemplateChild("PART_btnOne") as PushButton;
            //BUtton Two 
            btnTwo = GetTemplateChild("PART_btnTwo") as PushButton;

         
            //Button One Logic 
            btnOne!.Click += btnOne_Click!;
        
            // Button Two Logic 
            btnTwo!.Click += btnTwo_Click!;


    

        }

        #region Button Logic 

        void btnOne_Click(object sender, RoutedEventArgs e)
        {
            //Execute onBtnThree
            onBtnOne?.Invoke();
            //Hide the Dialog when finished 
            Hide();
        }
        void btnTwo_Click(object sender, RoutedEventArgs e)
        {
            //Execute onBtnThree
            onBtnTwo?.Invoke();
            //Hide the Dialog when finished 
            Hide();
        }

      

        #endregion 


        /// <summary>
        /// IAddCommand Method to easialy add commands 
        /// </summary>
        /// <param name="_command"></param>
        /// <param name="_method"></param>
        public void AddCommand(ICommand _command, ExecutedRoutedEventHandler _method)
        {
            CommandBindings.Add(new CommandBinding(_command,_method));
        }

        #region Show and Hide Method's 
        public void Hide()
        {
            Visibility = Visibility.Collapsed;
        }

        public void Show(string _title,string _msg)
        {
            //Show the COntrool
            Visibility = Visibility.Visible;
            //Display the TItle 
            Title = _title;
            //Display the Message 
            Message = _msg;
            btnOne!.Visibility = Visibility.Collapsed;
            btnTwo!.Visibility = Visibility.Collapsed;
            
        }
     
 

        public void Show(string _title, string _msg,string _btnOneText,string _btnTwoText, Action _method)
        {
            //Show the Control 
            Visibility = Visibility.Visible;
            btnOne!.Visibility = Visibility.Visible;
            btnTwo!.Visibility = Visibility.Visible;
            Title = _title;
            Message = _msg;
            //Default Text is Ok 
            ButtonTextOne = _btnOneText;
            ButtonTextTwo = _btnTwoText;
            //Link to BtnONe Method 
            onBtnOne = _method;
          
        }

        public void Show(string _title, string _msg, string _btnOneText, string _btnTwoText, Action _method,Action _method2)
        {
            //Show the Control 
            Visibility = Visibility.Visible;
            btnOne!.Visibility = Visibility.Visible;
            btnTwo!.Visibility = Visibility.Visible;
            Title = _title;
            Message = _msg;
            //Default Text is Ok 
            ButtonTextOne = _btnOneText;
            ButtonTextTwo = _btnTwoText;
            //Link to BtnONe Method 
            onBtnOne = _method;
            //Link to Button Two 
            onBtnTwo = _method2;
  
        }


        #endregion

      

        #region Public Properties 
        /// <summary>
        /// Gets or sets the Title 
        /// </summary>
        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }
        /// <summary>
        /// Gets or sets the Messsage 
        /// </summary>
        public string Message
        {
            get { return (string)GetValue(MessageProperty); }
            set { SetValue(MessageProperty, value); }
        }
        /// <summary>
        /// Gets or sets the Text For Button One 
        /// </summary>
        public string ButtonTextOne
        {
            get { return (string)GetValue(ButtonTextOneProperty); }
            set { SetValue(ButtonTextOneProperty, value); }
        }
        /// <summary>
        /// Gets or sets the text for Button Two 
        /// </summary>
        public string ButtonTextTwo
        {
            get { return (string)GetValue(ButtonTextTwoProperty); }
            set { SetValue(ButtonTextTwoProperty, value); }
        }
        /// <summary>
        /// Get or set if Buttons can be shown 
        /// </summary>
        public bool IsButtonsHidden
        {
            get => (bool)GetValue(IsButtonsHiddenProperty);
            set => SetValue(IsButtonsHiddenProperty, value);
        }

        public TextAlignment TitleAlignment
        {
            get => (TextAlignment)GetValue(TitleAlignmentProperty);
            set => SetValue(TitleAlignmentProperty,value);
        }

        
        #endregion


    }
}
