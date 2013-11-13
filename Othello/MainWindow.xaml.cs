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
        private PlayerController m_player1;
        private PlayerController m_player2;

        public MainWindow()
        {
            InitializeComponent();
            m_board = new GUIBoard(8);
            m_player1 = new LocalController();
            m_player2 = new LocalController();
            m_game = new OthelloGame(m_board, m_player1, m_player2);
            BoardControl.SetGame(m_board);
        }

        private void ExitClicked(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Hej då");
            Application.Current.Shutdown();
        }


        private void StartClicked(object sender, RoutedEventArgs e)
        {
            m_game.Restart();
            m_game.Run();
        }
    }
}
