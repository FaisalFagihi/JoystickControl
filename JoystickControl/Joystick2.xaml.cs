using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Shapes;


namespace JoystickControl
{

    public partial class Joystick2 : Control
    {
        //public System.Drawing.Brush Background
        //{
        //    get { return (System.Drawing.Brush)GetValue(BackgroundProperty); }
        //    set { SetValue(BackgroundProperty, value); }
        //}

        //// Using a DependencyProperty as the backing store for Background.  This enables animation, styling, binding, etc...
        //public static readonly DependencyProperty BackgroundProperty =
        //    DependencyProperty.Register("Background", typeof(System.Drawing.Brush), typeof(Joystick2), new PropertyMetadata(System.Drawing.Brushes.White));

        //public System.Drawing.Brush Foreground
        //{
        //    get { return (System.Drawing.Brush)GetValue(ForegroundProperty); }
        //    set { SetValue(ForegroundProperty, value); }
        //}

        //// Using a DependencyProperty as the backing store for Foreground.  This enables animation, styling, binding, etc...
        //public static readonly DependencyProperty ForegroundProperty =
        //    DependencyProperty.Register("Foreground", typeof(System.Drawing.Brush), typeof(Joystick2), new PropertyMetadata(System.Drawing.Brushes.Black));

        public double Width { get => 300; }

        public Joystick2()
        {
            DefaultStyleKey = typeof(Joystick2);
        }
        public override void OnApplyTemplate()
        {
            thumbPoint = GetTemplateChild("thumbPoint") as Ellipse;
            thumbX = GetTemplateChild("thumbX") as Rectangle;
            thumbY = GetTemplateChild("thumbY") as Rectangle;
            space = GetTemplateChild("space") as Grid;
            thumbLine = GetTemplateChild("thumbLine") as Line;
            container = GetTemplateChild("container") as Grid;

            center = new Point(Canvas.GetLeft(thumbPoint), Canvas.GetTop(thumbPoint));
            centerY = Canvas.GetTop(thumbY);
            centerX = Canvas.GetLeft(thumbX);

            rightLimit = space.Width - (thumbPoint.Width / 2);
            bottomLimit = space.Height - (thumbPoint.Height / 2);
            leftLimit = thumbPoint.Width / 2;
            topLimit = thumbPoint.Height / 2;
            ResetPosition();
        }

        Point center;
        private double centerY;
        private double centerX;
        private double rightLimit;
        private double bottomLimit;
        private double leftLimit;
        private double topLimit;
        private Point currentPosition;
        private Ellipse thumbPoint;
        private Rectangle thumbX;
        private Rectangle thumbY;
        private Grid space;
        private Line thumbLine;
        private Grid container;

        public void Canvas_PreviewMouseMove(object sender, MouseEventArgs e)
        {
           
        }
        public void Grid_MouseLeave(object sender, MouseEventArgs e)
        {
            ResetPosition();
        }
        public void ResetPosition()
        {
            Canvas.SetLeft(thumbPoint, center.X);
            Canvas.SetTop(thumbPoint, center.Y);
            Canvas.SetLeft(thumbX, centerX);
            Canvas.SetTop(thumbY, centerY);
            thumbLine.X2 = 0;
            thumbLine.Y2 = 0;
        }

        public void thumb_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            ResetPosition();
        }

        protected override void OnPreviewMouseMove(MouseEventArgs e)
        {
            if (e.LeftButton != MouseButtonState.Pressed)
                return;

            //if (e.OriginalSource != thumbPoint && e.OriginalSource != thumbX && e.OriginalSource != thumbY)
            //    return;

            currentPosition = e.GetPosition(space);
            if (currentPosition.X > center.X && currentPosition.X < rightLimit)
            {
                //send right
                Canvas.SetLeft(thumbPoint, (currentPosition.X - (thumbPoint.Width / 2)));
                Canvas.SetLeft(thumbX, currentPosition.X);
                thumbLine.X2 = currentPosition.X - center.X - (thumbPoint.Width / 2);

            }

            else if (currentPosition.X < center.X && currentPosition.X > leftLimit)
            {
                //send left
                Canvas.SetLeft(thumbPoint, currentPosition.X - (thumbPoint.Width / 2));
                Canvas.SetLeft(thumbX, currentPosition.X);
                thumbLine.X2 = currentPosition.X - center.X - (thumbPoint.Width / 2);
            }

            if (currentPosition.Y < center.Y && currentPosition.Y > topLimit)
            {
                //send up
                Canvas.SetTop(thumbPoint, currentPosition.Y - (thumbPoint.Height / 2));
                Canvas.SetTop(thumbY, currentPosition.Y);
                thumbLine.Y2 = currentPosition.Y - center.Y - (thumbPoint.Height / 2);

            }

            else if (currentPosition.Y > center.Y && currentPosition.Y < bottomLimit)
            {
                //send down
                Canvas.SetTop(thumbPoint, currentPosition.Y - (thumbPoint.Height / 2));
                Canvas.SetTop(thumbY, currentPosition.Y);
                thumbLine.Y2 = currentPosition.Y - center.Y - (thumbPoint.Height / 2);

            }
        }

        protected override void OnMouseLeave(MouseEventArgs e)
        {
            ResetPosition();
        }

        protected override void OnPreviewMouseLeftButtonUp(MouseButtonEventArgs e)
        {
            ResetPosition();

        }


        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (e.LeftButton != MouseButtonState.Pressed)
                return;

            currentPosition = e.GetPosition(space);
            if (currentPosition.X > center.X && currentPosition.X < rightLimit)
            {
                //send right
                Canvas.SetLeft(thumbPoint, (currentPosition.X - (thumbPoint.Width / 2)));
                Canvas.SetLeft(thumbX, currentPosition.X);
                thumbLine.X2 = currentPosition.X - center.X - (thumbPoint.Width / 2);

            }

            else if (currentPosition.X < center.X && currentPosition.X > leftLimit)
            {
                //send left
                Canvas.SetLeft(thumbPoint, currentPosition.X - (thumbPoint.Width / 2));
                Canvas.SetLeft(thumbX, currentPosition.X);
                thumbLine.X2 = currentPosition.X - center.X - (thumbPoint.Width / 2);
            }

            if (currentPosition.Y < center.Y && currentPosition.Y > topLimit)
            {
                //send up
                Canvas.SetTop(thumbPoint, currentPosition.Y - (thumbPoint.Height / 2));
                Canvas.SetTop(thumbY, currentPosition.Y);
                thumbLine.Y2 = currentPosition.Y - center.Y - (thumbPoint.Height / 2);

            }

            else if (currentPosition.Y > center.Y && currentPosition.Y < bottomLimit)
            {
                //send down
                Canvas.SetTop(thumbPoint, currentPosition.Y - (thumbPoint.Height / 2));
                Canvas.SetTop(thumbY, currentPosition.Y);
                thumbLine.Y2 = currentPosition.Y - center.Y - (thumbPoint.Height / 2);

            }
        }

    }
}
