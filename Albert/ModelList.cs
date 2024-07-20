

namespace Albert;

/// <summary>
/// ModelList is an Enhanced ObservableCollection that is designed to work with Model's, plus has some extra features  
/// </summary>
/// <typeparam name="T"></typeparam>
public class ModelList<T> : ObservableCollection<T>
{

    

    /// <summary>for
    /// ForEach Method preforms a ForEach Loop for the Current List  
    /// </summary>
    /// <param name="_method"></param>
    public void ForEach(Action<T> _method)
    {
        
        foreach (var i in this)
        {
            _method.Invoke(i);
        }
    }

    /// <summary>
    /// ToString Methed Converts list to  a JSON Format
    /// </summary>
    /// <returns>JSON Format</returns>
    public override string ToString() => Serialize(this);





}
