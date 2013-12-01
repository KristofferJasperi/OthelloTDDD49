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
    public enum PlayerType
    {
        Player,
        Computer
    }

    public class Player
    {
        public PlayerType Type { get; set;}
        public FieldValue Color { get; set; }
    }

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
            m_board = new Board(8);
            m_game = new OthelloGame(m_board);
            Board.SetBoard(m_board);// DataContext = m_guiboard;
            Board.BoardClickedEvent += BoardClicked;
            
        }

        private void ExitClicked(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Hej då");
            Application.Current.Shutdown();
        }

        private void BoardClicked(object sender, MouseEventArgs e)
        {
            var field = ((Border)sender).Tag as GUIField;
            m_game.MakeMove(MoveType.AddPiece, field.Coords);
        }

        private void PassClicked(object sender, RoutedEventArgs e)
        {
            if (!m_game.MakeMove(MoveType.Pass, new Coords(-1, -1)))
            {
                MessageBox.Show("Pass not allowed at the moment.");
            }
        }

        private void StartClicked(object sender, RoutedEventArgs e)
        {
           m_game.Restart();
        }
    }
}
