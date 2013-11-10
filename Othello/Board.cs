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
    public abstract class Board
    {
        protected int m_size;

        protected Board(int size)
        {
            m_size = size;
        }

        /// <summary>
        /// Gets the value of the field specified
        /// by a row and column index.
        /// </summary>
        /// <param name="row">The row index</param>
        /// <param name="col">The column index</param>
        public abstract FieldValue GetValue(int row, int col);

        /// <summary>
        /// Sets a field to a value.
        /// </summary>
        /// <param name="value">The new field value</param>
        /// <param name="row">The row index</param>
        /// <param name="col">The column index</param>
        public abstract void SetValue(FieldValue value, int row, int col);

        /// <summary>
        /// Gets a two dimensional enumerable of all field values.
        /// The outermost enumerable contains the rows, each row
        /// contains values for each column.
        /// </summary>
        public abstract IEnumerable<IEnumerable<FieldValue>> GetAllValues();

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

        public void SetStartValues()
        {
            var middle = m_size / 2;
            SetValue(FieldValue.Black, middle - 1, middle - 1);
            SetValue(FieldValue.Black, middle, middle);
            SetValue(FieldValue.White, middle - 1, middle);
            SetValue(FieldValue.White, middle, middle - 1);
        }
    }

    public class AIBoard : Board
    {
        //TODO Fix
        public AIBoard() : base(8) {}

        public override FieldValue GetValue(int row, int col)
        {
            throw new NotImplementedException();
        }

        public override void SetValue(FieldValue value, int row, int col)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<IEnumerable<FieldValue>> GetAllValues()
        {
            throw new NotImplementedException();
        }
    }

    /// <summary>
    /// Special class for GUIBoard. Contains Field objects which
    /// implements INotifyPropertyChanged interface.
    /// </summary>
    public class GUIBoard : Board
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

        private ObservableCollection<ObservableCollection<Field>> m_rows;
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

        public GUIBoard(int size) : base(size)
        {
            Rows = new ObservableCollection<ObservableCollection<Field>>();
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

        public override FieldValue GetValue(int row, int col)
        {
            return Rows[row][col].Value;
        }

        public override void SetValue(FieldValue value, int row, int col)
        {
            Rows[row][col].Value = value;
        }

        public override IEnumerable<IEnumerable<FieldValue>> GetAllValues()
        {
            return Rows.Select(row => row.Select(col => col.Value));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
