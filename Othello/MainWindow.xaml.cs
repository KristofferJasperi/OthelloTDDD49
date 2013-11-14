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

        public MainWindow()
        {
            InitializeComponent();
            m_board = new GUIBoard(8);
            m_game = new OthelloGame(ref m_board);
            BoardControl.DataContext = m_board;
        }

        private void ExitClicked(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Hej då");
            Application.Current.Shutdown();
        }

        private void BoardClicked(object sender, MouseEventArgs e)
        {
            var field = ((Border)sender).Tag as Field;
           // field.Value = FieldValue.Black;

            m_game.MakeMove(new Move(field.Column, field.Row));
        }


        private void StartClicked(object sender, RoutedEventArgs e)
        {
           m_game.Restart();
        }
    }
}
