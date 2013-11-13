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
        protected int m_size;

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

        /// <summary>
        /// Creates a GUIBoard.
        /// </summary>
        /// <param name="size"></param>
        public GUIBoard(int size)
        {
            Rows = new ObservableCollection<ObservableCollection<Field>>();
            m_size = size;

            for (int row = 0; row < size; row++)
            {
                var columns = new ObservableCollection<Field>();
                for (int col = 0; col < size; col++)
                {
                    var field = new Field(FieldValue.Empty, row, col);
                    columns.Add(field);
                }

                Rows.Add(columns);
            }
        }
        /// <summary>
        /// Sets all fields value to empty.
        /// </summary>
        public void ClearBoard()
        {
            for (int row = 0; row < m_size; row++)
            {
                for (int col = 0; col < m_size; col++)
                {
                    SetValue(FieldValue.Empty, row, col);
                }
            }
        }
        /// <summary>
        /// Gets a value
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <returns></returns>
        public FieldValue GetValue(int row, int col)
        {
            return Rows[row][col].Value;
        }

        /// <summary>
        /// Sets the starting field values
        /// </summary>
        public void SetStartValues()
        {
            var middle = m_size / 2;
            SetValue(FieldValue.Black, middle - 1, middle - 1);
            SetValue(FieldValue.Black, middle, middle);
            SetValue(FieldValue.White, middle - 1, middle);
            SetValue(FieldValue.White, middle, middle - 1);
        }

        /// <summary>
        /// Sets a value
        /// </summary>
        /// <param name="value"></param>
        /// <param name="row"></param>
        /// <param name="col"></param>
        public void SetValue(FieldValue value, int row, int col)
        {
            Rows[row][col].Value = value;
        }

        /// <summary>
        /// Gets a two dimensional enumerable of all field values.
        /// The outermost enumerable contains the rows, each row
        /// contains values for each column.
        /// </summary>
        public IEnumerable<IEnumerable<FieldValue>> GetAllValues()
        {
            return Rows.Select(row => row.Select(col => col.Value));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
