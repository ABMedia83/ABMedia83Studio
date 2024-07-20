

using System.CodeDom;

namespace Albert.Win32.Controls;

/// <summary>
/// A special Control designed to be turned to image Thumbnail and or meme
/// </summary>
public class ThumbnailControl: ContentControl
{

    public static readonly DependencyProperty CornerRadiusProperty = DP("CornerRadius", typeof(CornerRadius), typeof(ThumbnailControl));
    public static readonly DependencyProperty HeaderProperty = DP("Header", typeof(object), typeof(ThumbnailControl));
    public static readonly DependencyProperty FooterProperty = DP("Footer", typeof(object), typeof(ThumbnailControl));
    public static readonly DependencyProperty TopicSourceProperty = DP("TopicSource", typeof(ImageSource), typeof(ThumbnailControl));
    public static readonly DependencyProperty LogoSourceProperty = DP("LogoSource", typeof(ImageSource), typeof(ThumbnailControl));
   
    
    public ThumbnailControl()
    {
        DefaultStyleKey = typeof(ThumbnailControl);
    }

    /// <summary>
    /// Get or set CornerRadius 
    /// </summary>
    public CornerRadius CornerRadius
    {
        get => (CornerRadius)GetValue(CornerRadiusProperty);
        set => SetValue(CornerRadiusProperty, value);       
    }

    public object Header
    {
        get => (object)GetValue(HeaderProperty);
        set => SetValue(HeaderProperty,value);
    }
    /// <summary>
    /// Get or set the Footer of the Documen t
    /// </summary>
    public object Footer
    {
        get => (object)GetValue(FooterProperty);
        set => SetValue(FooterProperty, value);
    }
    /// <summary>
    /// Get or set the main Image you want if any 
    /// </summary>
    public ImageSource TopicSource 
    {
        get => (ImageSource)GetValue(TopicSourceProperty);  
        set => SetValue(TopicSourceProperty,value); 
    }


    /// <summary>
    /// Get or set the Logo for your Thumbnail
    /// </summary>
    public ImageSource LogoSource
    {
        get => (ImageSource)GetValue(LogoSourceProperty);
        set => SetValue(LogoSourceProperty, value);
    }




}
