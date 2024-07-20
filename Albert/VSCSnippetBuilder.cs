

namespace Albert;
/// <summary>
/// Class is designed to build Visaul Studio Code Snippets
/// </summary>
public class VSCSnippetBuilder : Notify
{
    string? title, scope, prefix, body, description;

    public string? Title
    {
        get => title;
        set { title = value; OnPropertyChanged("Title"); }
    }
    public string? Scope
    {
        get => scope;
        set { scope = value; OnPropertyChanged("Scope"); }
    }
    public string? Prefix
    {
        get => prefix;
        set { prefix = value; OnPropertyChanged("Prefix"); }
    }
    public string? Body
    {
        get => body;
        set { body = value; OnPropertyChanged("Body"); }
    }

    public string? Description
    {
        get => description;
        set { description = value; OnPropertyChanged("Descripton"); }
    }
    /// <summary>
    /// Converts to the Json format used for this Snippet type
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
        return $$""" 
  "{{Title}}": {
    "scope":"{{Scope}}",
    "prefix": "{{Prefix}}",
    "body": {
    {{Body}}
    }, 
    "descriptton": {{Description}}

  """ ;
    }
}





















