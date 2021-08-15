using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace JoystickControl
{
    /// <summary>
    /// Interaction logic for JoystickUserControl.xaml
    /// </summary>
    public partial class JoystickUserControl : UserControl
    {
        public JoystickUserControl()
        {
            InitializeComponent();
            //center = new Point(Canvas.GetLeft(thumbPoint), Canvas.GetTop(thumbPoint));
            //centerY = Canvas.GetTop(thumbY);
            //centerX = Canvas.GetLeft(thumbX);

            //rightLimit = space.Width - (thumbPoint.Width / 2);
            //bottomLimit = space.Height - (thumbPoint.Height / 2);
            //leftLimit = thumbPoint.Width / 2;
            //topLimit = thumbPoint.Height / 2;
        }

        //Point center;
        //private double centerY;
        //private double centerX;
        //private double rightLimit;
        //private double bottomLimit;
        //private double leftLimit;
        //private double topLimit;
        //private Point currentPosition;

        //public void Canvas_PreviewMouseMove(object sender, MouseEventArgs e)
        //{
        //    if (e.LeftButton != MouseButtonState.Pressed)
        //        return;

        //    currentPosition = e.GetPosition(space);
        //    if (currentPosition.X > center.X && currentPosition.X < rightLimit)
        //    {
        //        //send right
        //        Canvas.SetLeft(thumbPoint, (currentPosition.X - (thumbPoint.Width / 2)));
        //        Canvas.SetLeft(thumbX, currentPosition.X);
        //        thumbLine.X2 = currentPosition.X - center.X - (thumbPoint.Width / 2);

        //    }

        //    else if (currentPosition.X < center.X && currentPosition.X > leftLimit)
        //    {
        //        //send left
        //        Canvas.SetLeft(thumbPoint, currentPosition.X - (thumbPoint.Width / 2));
        //        Canvas.SetLeft(thumbX, currentPosition.X);
        //        thumbLine.X2 = currentPosition.X - center.X - (thumbPoint.Width / 2);
        //    }

        //    if (currentPosition.Y < center.Y && currentPosition.Y > topLimit)
        //    {
        //        //send up
        //        Canvas.SetTop(thumbPoint, currentPosition.Y - (thumbPoint.Height / 2));
        //        Canvas.SetTop(thumbY, currentPosition.Y);
        //        thumbLine.Y2 = currentPosition.Y - center.Y - (thumbPoint.Height / 2);

        //    }

        //    else if (currentPosition.Y > center.Y && currentPosition.Y < bottomLimit)
        //    {
        //        //send down
        //        Canvas.SetTop(thumbPoint, currentPosition.Y - (thumbPoint.Height / 2));
        //        Canvas.SetTop(thumbY, currentPosition.Y);
        //        thumbLine.Y2 = currentPosition.Y - center.Y - (thumbPoint.Height / 2);

        //    }
        //}
        //public void Grid_MouseLeave(object sender, MouseEventArgs e)
        //{
        //    ResetPosition();
        //}

        //public void ResetPosition()
        //{
        //    Canvas.SetLeft(thumbPoint, center.X);
        //    Canvas.SetTop(thumbPoint, center.Y);
        //    Canvas.SetLeft(thumbX, centerX);
        //    Canvas.SetTop(thumbY, centerY);
        //    thumbLine.X2 = 0;
        //    thumbLine.Y2 = 0;
        //}

        //public void thumb_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        //{
        //    ResetPosition();
        //}
    }
}
