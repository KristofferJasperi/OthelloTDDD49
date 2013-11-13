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
    /// Temporary
    /// </summary>
    public class MoveEventArgs : RoutedEventArgs
    {
        public int Column { get; set; }
        public int Row { get; set; }

        public MoveEventArgs(RoutedEvent routedEvent, object source)
            : base(routedEvent, source)
        { }
    }

    /// <summary>
    /// Interaction logic for BoardControl.xaml
    /// </summary>
    public partial class BoardControl : UserControl
    {
        //Experiment
        public static readonly RoutedEvent MoveEvent =
            EventManager.RegisterRoutedEvent("Move", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(BoardControl));

        public BoardControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Sets the board that should be used in the control
        /// </summary>
        public void SetBoard(GUIBoard board)
        {
            this.MainCollection.DataContext = board;                   
        }

        /// <summary>
        /// TODO: Raise event to be listened for in LocalController.GetNextMove()
        /// </summary>
        private void BoardClicked(object sender, MouseButtonEventArgs e)
        {
            var field = ((Border)sender).Tag as Field;
            field.Value = FieldValue.Black;

            //Experiment
            if (MoveEvent != null)
            {
                var eventargs = new MoveEventArgs(MoveEvent, sender) { Column = field.Column, Row = field.Row };
                RaiseEvent(eventargs);
            }
        }
    }
}
