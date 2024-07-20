

namespace Albert;

/// <summary>
/// Class is designed to build Visual Studio Snippets 
/// </summary>
public class VSSnippetBuilder : Notify
{
    string? title, author, deescription, shortcut, code,language;


    public VSSnippetBuilder()
    {
        //Do nothing for now
    }

    public required string? Title
    {
        get => title;
        set { title = value; OnPropertyChanged("Title"); }
    }
    public string? Author
    {
        get => author ;
        set { author = value; OnPropertyChanged("Author"); }
    }

    public  string? Desciption
    {
        get => deescription;
        set { deescription = value; OnPropertyChanged("Description"); }
    }
    public  string? Shortcut
    {
        get => shortcut;
        set { shortcut = value; OnPropertyChanged("Shortcut"); }
    }

    public string? CodeLanguage
    {
        get => language;
        set { language = value; OnPropertyChanged("CodeLanguage"); }
    }

    public  string? Code
    {
        get => code;
        set { code = value; OnPropertyChanged("Code"); }
    }
    /// <summary>
    /// Return the Snippet Xml to be used
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
        return $$""" 
 <?xml version="1.0" encoding="utf-8"?>
<CodeSnippets xmlns="http://schemas.microsoft.com/VisualStudio/2005/CodeSnippet">
    <CodeSnippet Format="1.0.0">
        <Header>
            <Title>{{Title}}</Title>
            <Author>{{Author}}</Author>
            <Description>{{Desciption}}}</Description>
            <Shortcut>{{Shortcut}}</Shortcut>
        </Header>
        <Snippet>
            <Code Language="{{CodeLanguage}}">
                <![CDATA[{{Code}}]]>
            </Code>
        </Snippet>
    </CodeSnippet>
</CodeSnippets>


""";
    }

}