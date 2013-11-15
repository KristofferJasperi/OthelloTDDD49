using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Othello
{
    /// <summary>
    /// Special class for GUIBoard. Contains Field objects which
    /// implements INotifyPropertyChanged interface.
    /// </summary>
    public class GUIBoard //: Board
    {
        public int Size { get; private set; }

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

        private ObservableCollection<ObservableCollection<Field>> m_rows;

        /// <summary>
        /// Collection of fields.
        /// </summary>
        public ObservableCollection<ObservableCollection<Field>> Rows {
            get
            {
                return m_rows;
            }
            private set
            {
                if (m_rows != value)
                {
                    m_rows = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public void Update(FieldValue[,] fields)
        {
            if (Size * Size != fields.Length)
            {
                throw new ArgumentException("Size mismatch", "fields");
            }

            for (int row = 0; row < Size; row++)
            {
                for (int col = 0; col < Size; col++)
                {
                    Rows[row][col].Value = fields[row, col];
                }
            }
        }

        /// <summary>
        /// Creates a GUIBoard.
        /// </summary>
        /// <param name="size"></param>
        public GUIBoard(int size)
        {
            Rows = new ObservableCollection<ObservableCollection<Field>>();
            Size = size;

            for (int row = 0; row < size; row++)
            {
                var columns = new ObservableCollection<Field>();
                for (int col = 0; col < size; col++)
                {
                    var field = new Field(FieldValue.Empty, new Coords(col, row));
                    columns.Add(field);
                }

                Rows.Add(columns);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
