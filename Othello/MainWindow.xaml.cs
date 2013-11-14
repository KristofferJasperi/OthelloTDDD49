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
        private GUIBoard m_board;
        private Player m_player1;
        private Player m_player2;
        private bool m_waitForPlayer;
        private bool m_waitForComputer;

        public MainWindow()
        {
            InitializeComponent();
            m_board = new GUIBoard(8);
            m_player1 = new Player() { Type = PlayerType.Player, Color = FieldValue.Black };
            m_player2 = new Player() { Type = PlayerType.Player, Color = FieldValue.White };
            m_game = new OthelloGame(m_board);
            BoardControl.MainCollection.DataContext = m_board;
        }

        private void ExitClicked(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Hej då");
            Application.Current.Shutdown();
        }

        private static void BoardClicked()
        {
            throw new NotImplementedException();
        }


        private void StartClicked(object sender, RoutedEventArgs e)
        {
            m_game.Restart();
        }
    }
}
