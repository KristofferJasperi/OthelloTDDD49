using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Othello
{
    /// <summary>
    /// Interaction logic for BoardControl.xaml
    /// </summary>
    public partial class BoardControl : UserControl
    {
        public BoardControl()
        {
            InitializeComponent();

            MainCollection.DataContext = new Board(8);
        }
    }

    public class Field
    {
        public int Value {get; set;}
        public Field(int value)
        {
            this.Value = value;
        }
    }

    public class Board
    {
        public List<List<Field>> Rows { get; set; }

        public Board(int size)
        {
            Rows = new List<List<Field>>();
            for (int row = 0; row < size; row++)
            {
                var columns = new List<Field>();
                for (int col = 0; col < size; col++)
                {
                    var field = new Field(row * size + col);
                    columns.Add(field);
                }

                Rows.Add(columns);
            }
        }
    }
}
