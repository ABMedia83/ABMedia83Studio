using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;
using System.Windows.Media;
using static System.TimeSpan;
namespace Albert.Win32.Controls
{
    /// <summary>
    /// My version of the MediaElement with a few more method's 
    /// </summary>
    public class MediaPlayback: MediaElement
    {

        /// <summary>
        /// Default Constructor 
        /// </summary>
        public MediaPlayback()
        {
            //Setup Default Behavior 
            LoadedBehavior = MediaState.Manual;
            UnloadedBehavior = MediaState.Manual;
        }
        /// <summary>
        /// Rewind 1.5 Second 
        /// </summary>
        public void Rewind()
        {
            Position -= FromSeconds(1.5);
        }
        /// <summary>
        /// Rewind 3 seconds 
        /// </summary>
        public void FastRewind()
        {
            Position -= FromSeconds(3);
        }
        /// <summary>
        /// Manual Rewind 
        /// </summary>
        /// <param name="_seconds">Number of Seconds</param>
        public void ManualRewind(double _seconds)
        {
            Position -= FromSeconds(_seconds);
        }

        /// <summary>
        /// Forward 1.5 Second 
        /// </summary>
        public void Forward()
        {
            Position += FromSeconds(1.5);
        }
        /// <summary>
        /// Fast Forward 3 seconds 
        /// </summary>
        public void FastRForward()
        {
            Position += FromSeconds(3);
        }
        /// <summary>
        /// Manual Forward 
        /// </summary>
        /// <param name="_seconds">Number of Seconds</param>
        public void ManualForward(double _seconds)
        {
            Position += FromSeconds(_seconds);
        }



    }
}
