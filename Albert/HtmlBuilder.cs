

namespace Albert;

/// <summary>
/// HtmlTool is designed to generato a html file 
/// </summary>
public class HtmlBuilder : Notify
{
    string? head, title, body, script; 

    #region Constructor 

    public HtmlBuilder()
    {
        // Do nothing 
    }
   
    public HtmlBuilder(string _title)
    {
        Title = _title; 
    }

    public HtmlBuilder(string _title,string _body)
    {
        Title = _title;
        Body = _body;
    }

    public HtmlBuilder(string _title,string _head,string _body)
    {
        Title = _title;
        Head = _head;
        Body = _body;
       
    }

    public HtmlBuilder(string _title, string _head, string _body, string _script)
    {
        Title = _title;
        Head = _head;
        Body = _body;
        Script = _script;
         

    }

    #endregion



    #region Public Properties 
    /// <summary>
    /// Get or set the Title of the Html Document
    /// </summary>
    public string? Title
    {
        get => title;
        set { title = value; OnPropertyChanged("Title"); }
    }
    /// <summary>
    /// Get or set the head tag of the html document 
    /// </summary>
    public string? Head
    {
        get => head;
        set { head = value; OnPropertyChanged("Head"); }
    }
    /// <summary>
    /// Get or set the body tag of the Html Document
    /// </summary>
    public string? Body
    {
        get => body;
        set { body = value; OnPropertyChanged("Body"); }
    }
    /// <summary>
    /// Get or set the Scripts 
    /// </summary>
    public string? Script
    {
        get => script;
        set { script = value; OnPropertyChanged("Script"); }
    }

    #endregion


    #region Html Tool Module's 

    public static string AddCss(string _url)
    {
        return $"<link rel=\"stylesheet\" href=\"{_url}\" />";
    }

    public static string AddJavaScript(string _script)
    {
        return $"<script src=\"{_script}\" defer></script>";
    }

    #endregion


    /// <summary>
    /// ToString Method returns a HTML Document
    /// </summary>
    /// <returns>Html Document</returns>
    public override string ToString()
    {
        //Generate the html 
        var html = $$""" 
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    
    <title>{{Title}}}</title>

    {{Head}}
</head>
<body>
    {{Body}}


    {{Script}}}

</body>
</html>
""";
        //Return the Html 
        return html;
    }

}
