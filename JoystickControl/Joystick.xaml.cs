using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Shapes;

namespace JoystickControl
{

    public class Joystick : Control
    {



        public double XAxis
        {
            get { return (double)GetValue(XAxisProperty); }
            set { SetValue(XAxisProperty, value); }
        }

        // Using a DependencyProperty as the backing store for XAxis.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty XAxisProperty =
            DependencyProperty.Register("XAxis", typeof(double), typeof(Joystick), new PropertyMetadata(0.0));



        public double YAxis
        {
            get { return (double)GetValue(YAxisProperty); }
            set { SetValue(YAxisProperty, value); }
        }

        // Using a DependencyProperty as the backing store for YAxis.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty YAxisProperty =
            DependencyProperty.Register("YAxis", typeof(double), typeof(Joystick), new PropertyMetadata(0.0));



        public int AxisScale
        {
            get { return (int)GetValue(AxisScaleProperty); }
            set { SetValue(AxisScaleProperty, value); }
        }

        // Using a DependencyProperty as the backing store for AxisScale.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty AxisScaleProperty =
            DependencyProperty.Register("AxisScale", typeof(int), typeof(Joystick), new PropertyMetadata(1));




        Point centerOfStick;
        private Point currentPosition;
        private double centerOfExtraButtonA;
        private double centerOfExtraButtonB;
        private double spaceRightLimit;
        private double spaceBottomLimit;
        private double spaceLeftLimit;
        private double spaceTopLimit;
        private Ellipse stick;
        private Rectangle extraButtonA;
        private Rectangle extraButtonB;
        private Canvas space;
        private Line stickBase;
        private Canvas joystickBase;
        private double xAxisOfStick;
        private double xAxisOfExtraButtonA;
        private double yAxisOfExtraButtonB;
        private double yAxisOfStick;

        public Joystick()
        {
            centerOfStick = new Point();
            currentPosition = new Point();
            stick = new Ellipse();
            extraButtonA = new Rectangle();
            extraButtonB = new Rectangle();
            space = new Canvas();
            stickBase = new Line();
            joystickBase = new Canvas();
            Application.Current.MainWindow.PreviewMouseLeftButtonUp += MainWindow_PreviewMouseLeftButtonUp;
            Application.Current.MainWindow.PreviewMouseMove += MainWindow_PreviewMouseMove;
            Application.Current.MainWindow.MouseLeave += MainWindow_MouseLeave;
        }
        public override void OnApplyTemplate()
        {
            stick = GetTemplateChild("stick") as Ellipse;
            extraButtonA = GetTemplateChild("extraButtonA") as Rectangle;
            extraButtonB = GetTemplateChild("extraButtonB") as Rectangle;
            space = GetTemplateChild("space") as Canvas;
            stickBase = GetTemplateChild("stickBase") as Line;
            joystickBase = GetTemplateChild("joystickBase") as Canvas;

            centerOfStick = new Point(Canvas.GetLeft(stick), Canvas.GetTop(stick));
            centerOfExtraButtonB = Canvas.GetTop(extraButtonB);
            centerOfExtraButtonA = Canvas.GetLeft(extraButtonA);

            spaceRightLimit = space.Width - (stick.Width / 2);
            spaceBottomLimit = space.Height - (stick.Height / 2);
            spaceLeftLimit = stick.Width / 2;
            spaceTopLimit = stick.Height / 2;

        }

        private void MainWindow_MouseLeave(object sender, MouseEventArgs e)
        {
            ResetPosition();
        }

        private void MainWindow_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton != MouseButtonState.Pressed)
                return;

            //Restrict the mouse moving on the thumbs only
            //if (e.OriginalSource != thumbPoint && e.OriginalSource != thumbX && e.OriginalSource != thumbY)
            //    return;

            currentPosition = e.GetPosition(space);
            xAxisOfStick = (currentPosition.X - (stick.Width / 2));
            yAxisOfStick = currentPosition.Y - (stick.Height / 2);
            xAxisOfExtraButtonA = currentPosition.X + (extraButtonA.Width / 2);
            yAxisOfExtraButtonB = currentPosition.Y + (extraButtonB.Height / 2);
            if (currentPosition.X > centerOfStick.X && currentPosition.X < spaceRightLimit)
            {
                //move ellipse the right direction
                Canvas.SetLeft(stick, xAxisOfStick);
                //move top rectangle to right direction
                Canvas.SetLeft(extraButtonA, xAxisOfExtraButtonA);
                //move line to right direction
                stickBase.X2 = xAxisOfStick - centerOfStick.X;

                XAxis = Math.Round(((xAxisOfStick - (centerOfStick.X + (stick.Width / 2))) / space.Width) * AxisScale * 2, 2);

            }

            else if (currentPosition.X < centerOfStick.X && currentPosition.X > spaceLeftLimit)
            {
                //send left
                Canvas.SetLeft(stick, xAxisOfStick);
                Canvas.SetLeft(extraButtonA, xAxisOfExtraButtonA);
                stickBase.X2 = xAxisOfStick - centerOfStick.X;
                XAxis = Math.Round((((stickBase.X2 + (stick.Width / 2)) / space.Width) * AxisScale * 2), 2);
            }

            if (currentPosition.Y < centerOfStick.Y && currentPosition.Y > spaceTopLimit)
            {
                //send up
                Canvas.SetTop(stick, yAxisOfStick);
                Canvas.SetTop(extraButtonB, yAxisOfExtraButtonB);
                stickBase.Y2 = yAxisOfStick - centerOfStick.Y;
                YAxis = Math.Round(((stickBase.Y2 + (stick.Height / 2)) / space.Width) * AxisScale * 2, 2);

            }

            else if (currentPosition.Y > centerOfStick.Y && currentPosition.Y < spaceBottomLimit)
            {
                //send down
                Canvas.SetTop(stick, yAxisOfStick);
                Canvas.SetTop(extraButtonB, yAxisOfExtraButtonB);
                stickBase.Y2 = yAxisOfStick - centerOfStick.Y;
                YAxis = Math.Round(((stickBase.Y2 + (stick.Height / 2)) / space.Width) * AxisScale * 2, 2);
            }
        }

        private void MainWindow_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            ResetPosition();
        }

        public void ResetPosition()
        {
            Canvas.SetLeft(stick, centerOfStick.X);
            Canvas.SetTop(stick, centerOfStick.Y);
            Canvas.SetLeft(extraButtonA, centerOfExtraButtonA);
            Canvas.SetTop(extraButtonB, centerOfExtraButtonB);
            stickBase.X2 = 0;
            stickBase.Y2 = 0;
        }
        protected override void OnRenderSizeChanged(SizeChangedInfo sizeInfo)
        {
            joystickBase.Width = sizeInfo.NewSize.Width;
            joystickBase.Height = joystickBase.Width;
            var doubleValue = space.Width;
            
            stick.Width = (doubleValue - (doubleValue * 0.1)) * 0.1;
            stick.Height = stick.Width;
            var stickPosition = (doubleValue / 2) - (((doubleValue - (doubleValue * 0.1)) * 0.1) / 2);
            Canvas.SetLeft(stick, stickPosition);
            Canvas.SetTop(stick, stickPosition);
            centerOfStick = new Point(stickPosition, stickPosition);
            var extraButtonPosition = (joystickBase.Width / 2) - ((doubleValue * 0.1) / 2);
            Canvas.SetLeft(extraButtonA, extraButtonPosition);
            Canvas.SetTop(extraButtonB, extraButtonPosition);
            centerOfExtraButtonB = extraButtonPosition;
            centerOfExtraButtonA = extraButtonPosition;

            spaceRightLimit = space.Width - (stick.Width / 2);
            spaceBottomLimit = spaceRightLimit;
            spaceLeftLimit = stick.Width / 2;
            spaceTopLimit = spaceLeftLimit;
            ResetPosition();
        }
    }
}
