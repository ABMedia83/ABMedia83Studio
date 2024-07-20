using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Albert.Win32
{
	/// <summary>
	///  A special interface to simplfy COmmmand Bindings 
	/// </summary>
	public interface IAddCommand
	{
		void AddCommand(ICommand _command, ExecutedRoutedEventHandler _method);
	}
}
