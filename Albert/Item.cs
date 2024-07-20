
namespace Albert;

/// <summary>
/// Abstract Base class for creating a flexible Item for softwae 
/// </summary>
public abstract class Item: Notify
{
	string? name; 

	/// <summary>
	/// Gets or set the name of the property 
	/// </summary>
	public string? Name
	{
		get => name;
		set { name = value; OnPropertyChanged("Name"); }
	}

        public override string ToString()
        {
		return Name!;
        }
    }
