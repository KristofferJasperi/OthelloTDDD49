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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private OthelloGame m_game;
        private Board m_board;

        public MainWindow()
        {
            InitializeComponent();
            m_board = new GUIBoard(8);
            m_game = new OthelloGame(m_board);
            BoardControl.SetBoard(m_board);
        }

        private void ExitClicked(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Hej då");
            Application.Current.Shutdown();
        }

        private void StartClicked(object sender, RoutedEventArgs e)
        {
            m_game.Restart();
        }
    }
}
