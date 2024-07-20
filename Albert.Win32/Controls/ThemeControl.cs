

namespace Albert.Win32.Controls
{

    /// <summary>
    /// A special control that displays 5 Colors 
    /// </summary>
    public  class ThemeControl: ViewControl 
    {

        private static readonly DependencyProperty PrimaryColorPropeerty = DP("PrimaryColor",typeof(Color),typeof(ThemeControl));

        private static readonly DependencyProperty SecondaryColorPropeerty = DP("SecondaryColor", typeof(Color), typeof(ThemeControl));

        private static readonly DependencyProperty AccentColorOnePropeerty = DP("AccentColorOne", typeof(Color), typeof(ThemeControl));

        private static readonly DependencyProperty AccentColorTwoPropeerty = DP("AccentColorTwo", typeof(Color), typeof(ThemeControl));

        private static readonly DependencyProperty AccentColorThreePropeerty = DP("AccentColorThree", typeof(Color), typeof(ThemeControl));




        public Color PrimaryColor
        {
            get => (Color)GetValue(PrimaryColorPropeerty);
            set => SetValue(PrimaryColorPropeerty, value);
        }
        public Color SecondaryColor
        {
            get { return (Color)GetValue(SecondaryColorPropeerty); }
            set => SetValue(SecondaryColorPropeerty, value);
        }

        public Color AccentColorOne
        {
            get => (Color)GetValue(AccentColorOnePropeerty);
            set => SetValue(AccentColorOnePropeerty, value);
        }

        public Color AccentColorTwo
        {
            get => (Color)GetValue(AccentColorTwoPropeerty);
            set => SetValue(AccentColorTwoPropeerty, value);
        }
        public Color AccentColorThree
        {
            get => (Color)GetValue(AccentColorThreePropeerty);
            set => SetValue(AccentColorThreePropeerty, value);

        }


    }
}
