using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Othello
{
    public class Field : INotifyPropertyChanged
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

        public Field(FieldValue value, int row, int column)
        {
            Value = value;
            Row = row;
            Column = column;            
        }

        public int Row { get; private set; }
        public int Column { get; private set; }

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
                    NotifyPropertyChanged();
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

        private Brush m_color;
        public Brush Color
        {
            get
            {
                return m_color;
            }
            private set
            {
                if (m_color != value)
                {
                    m_color = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private Brush m_backgroundColor;
        public Brush BackgroundColor
        {
            get
            {
                return m_backgroundColor;
            }
            private set
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
