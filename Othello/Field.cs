using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace Othello
{
    public class GUIField : INotifyPropertyChanged
    {
        /// <summary>
        /// This method is called by the Set accessor of each property. 
        /// The CallerMemberName attribute that is applied to the optional propertyName 
        /// parameter causes the property name of the caller to be substituted as an argument. 
        /// </summary>
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private Storyboard m_storyboard;

        public GUIField(FieldValue value, Coords coord)
        {
            Value = value;
            Coords = coord;
            BackgroundColor = new SolidColorBrush(Colors.White);
            BackgroundColor.Opacity = 0.0;
        }

        public Coords Coords { get; private set; }

        private FieldValue? m_value;
        public FieldValue Value { 
            get
            {
                return (FieldValue)m_value;
            }
            set
            {
                if (m_value != value)
                {
                    m_value = value;
                    //NotifyPropertyChanged();
                    if (value == FieldValue.Black)
                    {
                        Color = new SolidColorBrush(Colors.Black);
                    }
                    else if (value == FieldValue.White)
                    {
                        Color = new SolidColorBrush(Colors.White);
                    }
                    else
                    {
                        Color = new SolidColorBrush(Colors.Transparent);
                    }
                }
            }
        }

        private SolidColorBrush m_color;
        public SolidColorBrush Color
        {
            get
            {
                return m_color;
            }
            private set
            {
                if (m_color != value)
                {
                    var old_color = m_color;
                    m_color = value;
                    if (old_color != null && WasFlipped(old_color.Color, value.Color))
                    {
                        //TODO: Animate
                    }
                    NotifyPropertyChanged();
                }
            }
        }

        private bool WasFlipped(Color old_color, Color new_color)
        {
            return (old_color.Equals(Colors.Black) && new_color.Equals(Colors.White)) ||
                (old_color.Equals(Colors.White) && new_color.Equals(Colors.Black));
        }

        private Brush m_backgroundColor;
        public Brush BackgroundColor
        {
            get
            {
                return m_backgroundColor;
            }
            set
            {
                if (m_backgroundColor != value)
                {
                    m_backgroundColor = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
