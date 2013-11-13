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
        private Board m_board;

        public delegate void MoveEventHandler(object sender, EventArgs e);

        public BoardControl()
        {
            InitializeComponent();
        }

        public void SetGame(Board board)
        {
            m_board = board;
            this.MainCollection.DataContext = (GUIBoard)m_board;
                   
        }

        private void BoardClicked(object sender, MouseButtonEventArgs e)
        {
            var field = ((Border)sender).Tag as Field;
            field.Value = FieldValue.Black;
        }
    }
}
