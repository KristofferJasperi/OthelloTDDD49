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

        public BoardControl()
        {
            InitializeComponent();
        }

        public void SetBoard(Board board)
        {
            m_board = board;
            this.MainCollection.DataContext = m_board;
        }

        private void BoardClicked(object sender, MouseButtonEventArgs e)
        {
            var field = ((Border)sender).Tag as Field;
            if (field != null)
            {
                m_board.SetValue(FieldValue.Black, field.Row, field.Column);
            }
        }
    }
}
