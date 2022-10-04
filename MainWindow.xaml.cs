using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Astral_Launcher
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool menuOpen;
        Storyboard pathAnimationStoryboard = new Storyboard();
        Storyboard pathAnimationStoryboard2 = new Storyboard();
        Storyboard pathAnimationStoryboard3 = new Storyboard();
        Storyboard pathAnimationStoryboard4 = new Storyboard();

        private string _status;
        private bool _done = true;
        private int _ticks;

        public MainWindow()
        {
            InitializeComponent();

            discord.Click += (s, e) => {
                string url = "https://discord.gg/vN9dA2Ya76";
                try
                {
                    Process.Start(url);
                }
                catch
                {
                    // hack because of this: https://github.com/dotnet/corefx/issues/10361
                    if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                    {
                        url = url.Replace("&", "^&");
                        Process.Start(new ProcessStartInfo(url) { UseShellExecute = true });
                    }
                    else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                    {
                        Process.Start("xdg-open", url);
                    }
                    else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                    {
                        Process.Start("open", url);
                    }
                    else
                    {
                        throw;
                    }
                };
            };

            website.Click += (s, e) => {
                string url = "https://www.astralclient.net/";
                try
                {
                    Process.Start(url);
                }
                catch
                {
                    // hack because of this: https://github.com/dotnet/corefx/issues/10361
                    if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                    {
                        url = url.Replace("&", "^&");
                        Process.Start(new ProcessStartInfo(url) { UseShellExecute = true });
                    }
                    else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                    {
                        Process.Start("xdg-open", url);
                    }
                    else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                    {
                        Process.Start("open", url);
                    }
                    else
                    {
                        throw;
                    }
                };
            };

            menuOpen = false;
            TranslateTransform animatedTranslateTransform =
                new TranslateTransform();
            this.RegisterName("AnimatedTranslateTransform", animatedTranslateTransform);
            mainBorder.RenderTransform = animatedTranslateTransform;

            TranslateTransform animatedTranslateTransform2 =
                new TranslateTransform();
            this.RegisterName("AnimatedTranslateTransform2", animatedTranslateTransform2);
            menuPanel.RenderTransform = animatedTranslateTransform2;

            PathGeometry animationPath = new PathGeometry();
            PathFigure pFigure = new PathFigure();
            pFigure.StartPoint = new Point(0, 0);
            PolyQuadraticBezierSegment pBezierSegment = new PolyQuadraticBezierSegment();
            pBezierSegment.Points.Add(new Point(135, 0));
            pBezierSegment.Points.Add(new Point(150, 0));
            pFigure.Segments.Add(pBezierSegment);
            animationPath.Figures.Add(pFigure);

            animationPath.Freeze();

            DoubleAnimationUsingPath translateXAnimation =
                new DoubleAnimationUsingPath();
            translateXAnimation.PathGeometry = animationPath;
            translateXAnimation.Duration = TimeSpan.FromSeconds(.7);

            translateXAnimation.Source = PathAnimationSource.X;

            Storyboard.SetTargetName(translateXAnimation, "AnimatedTranslateTransform");
            Storyboard.SetTargetProperty(translateXAnimation,
                new PropertyPath(TranslateTransform.XProperty));

            DoubleAnimationUsingPath translateYAnimation =
                new DoubleAnimationUsingPath();
            translateYAnimation.PathGeometry = animationPath;
            translateYAnimation.Duration = TimeSpan.FromSeconds(5);

            translateYAnimation.Source = PathAnimationSource.Y;

            Storyboard.SetTargetName(translateYAnimation, "AnimatedTranslateTransform");
            Storyboard.SetTargetProperty(translateYAnimation,
                new PropertyPath(TranslateTransform.YProperty));

            pathAnimationStoryboard.Children.Add(translateXAnimation);
            pathAnimationStoryboard.Children.Add(translateYAnimation);



            PathGeometry animationPath2 = new PathGeometry();
            PathFigure pFigure2 = new PathFigure();
            pFigure2.StartPoint = new Point(150, 0);
            PolyQuadraticBezierSegment pBezierSegment2 = new PolyQuadraticBezierSegment();
            pBezierSegment2.Points.Add(new Point(135, 0));
            pBezierSegment2.Points.Add(new Point(0, 0));
            pFigure2.Segments.Add(pBezierSegment2);
            animationPath2.Figures.Add(pFigure2);

            animationPath2.Freeze();

            DoubleAnimationUsingPath translateXAnimation2 =
                new DoubleAnimationUsingPath();
            translateXAnimation2.PathGeometry = animationPath2;
            translateXAnimation2.Duration = TimeSpan.FromSeconds(.7);

            translateXAnimation2.Source = PathAnimationSource.X;

            Storyboard.SetTargetName(translateXAnimation2, "AnimatedTranslateTransform");
            Storyboard.SetTargetProperty(translateXAnimation2,
                new PropertyPath(TranslateTransform.XProperty));

            DoubleAnimationUsingPath translateYAnimation2 =
                new DoubleAnimationUsingPath();
            translateYAnimation2.PathGeometry = animationPath2;
            translateYAnimation2.Duration = TimeSpan.FromSeconds(5);

            translateYAnimation2.Source = PathAnimationSource.Y;

            Storyboard.SetTargetName(translateYAnimation2, "AnimatedTranslateTransform");
            Storyboard.SetTargetProperty(translateYAnimation2,
                new PropertyPath(TranslateTransform.YProperty));

            pathAnimationStoryboard2.Children.Add(translateXAnimation2);
            pathAnimationStoryboard2.Children.Add(translateYAnimation2);



            PathGeometry animationPath3 = new PathGeometry();
            PathFigure pFigure3 = new PathFigure();
            pFigure3.StartPoint = new Point(0, 0);
            PolyQuadraticBezierSegment pBezierSegment3 = new PolyQuadraticBezierSegment();
            pBezierSegment3.Points.Add(new Point(135, 0));
            pBezierSegment3.Points.Add(new Point(250, 0));
            pFigure3.Segments.Add(pBezierSegment3);
            animationPath3.Figures.Add(pFigure3);

            animationPath3.Freeze();

            DoubleAnimationUsingPath translateXAnimation3 =
                new DoubleAnimationUsingPath();
            translateXAnimation3.PathGeometry = animationPath3;
            translateXAnimation3.Duration = TimeSpan.FromSeconds(.7);

            translateXAnimation3.Source = PathAnimationSource.X;

            Storyboard.SetTargetName(translateXAnimation3, "AnimatedTranslateTransform2");
            Storyboard.SetTargetProperty(translateXAnimation3,
                new PropertyPath(TranslateTransform.XProperty));

            DoubleAnimationUsingPath translateYAnimation3 =
                new DoubleAnimationUsingPath();
            translateYAnimation3.PathGeometry = animationPath3;
            translateYAnimation3.Duration = TimeSpan.FromSeconds(5);

            translateYAnimation3.Source = PathAnimationSource.Y;

            Storyboard.SetTargetName(translateYAnimation3, "AnimatedTranslateTransform2");
            Storyboard.SetTargetProperty(translateYAnimation3,
                new PropertyPath(TranslateTransform.YProperty));

            pathAnimationStoryboard3.Children.Add(translateXAnimation3);
            pathAnimationStoryboard3.Children.Add(translateYAnimation3);



            PathGeometry animationPath4 = new PathGeometry();
            PathFigure pFigure4 = new PathFigure();
            pFigure4.StartPoint = new Point(250, 0);
            PolyQuadraticBezierSegment pBezierSegment4 = new PolyQuadraticBezierSegment();
            pBezierSegment4.Points.Add(new Point(135, 0));
            pBezierSegment4.Points.Add(new Point(0, 0));
            pFigure4.Segments.Add(pBezierSegment4);
            animationPath4.Figures.Add(pFigure4);

            animationPath4.Freeze();

            DoubleAnimationUsingPath translateXAnimation4 =
                new DoubleAnimationUsingPath();
            translateXAnimation4.PathGeometry = animationPath4;
            translateXAnimation4.Duration = TimeSpan.FromSeconds(.7);

            translateXAnimation4.Source = PathAnimationSource.X;

            Storyboard.SetTargetName(translateXAnimation4, "AnimatedTranslateTransform2");
            Storyboard.SetTargetProperty(translateXAnimation4,
                new PropertyPath(TranslateTransform.XProperty));

            DoubleAnimationUsingPath translateYAnimation4 =
                new DoubleAnimationUsingPath();
            translateYAnimation4.PathGeometry = animationPath4;
            translateYAnimation4.Duration = TimeSpan.FromSeconds(5);

            translateYAnimation4.Source = PathAnimationSource.Y;

            Storyboard.SetTargetName(translateYAnimation4, "AnimatedTranslateTransform2");
            Storyboard.SetTargetProperty(translateYAnimation4,
                new PropertyPath(TranslateTransform.YProperty));

            pathAnimationStoryboard4.Children.Add(translateXAnimation4);
            pathAnimationStoryboard4.Children.Add(translateYAnimation4);
        }

        private void SetStatus(string status, bool popup = false)
        {
            Console.Write(status);

            if (popup)
            {
                MessageBox.Show(status);
                return;
            }


            if (status == "done")
            {
                _done = true;
                _status = string.Empty;
                _ticks = 0;
            }
            else
            {
                _done = false;
                _status = status;
            }
        }

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void Label_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void Button_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (!_done) return;

            SetStatus("selecting DLL");
            var diag = new OpenFileDialog
            {
                Filter = "dll files (*.dll)|*.dll",
                RestoreDirectory = true
            };

            if (diag.ShowDialog().GetValueOrDefault())
                Task.Run(() => Inject(diag.FileName));
            else
                SetStatus("done");
        }

        private void Button_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }

        void Label_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //pathAnimationStoryboard.Begin(mainBorder);
            if (menuOpen == true)
            {
                pathAnimationStoryboard2.Begin(mainBorder);
                pathAnimationStoryboard4.Begin(menuPanel);
                menuOpen = false;
            }
            else
            {
                pathAnimationStoryboard.Begin(mainBorder);
                pathAnimationStoryboard3.Begin(menuPanel);
                menuOpen = true;
            }
        }

        private void Discord_Click(object sender, MouseButtonEventArgs e)
        {
            Console.Write("hi");
            string url = "https://google.com";
            try
            {
                Process.Start(url);
            }
            catch
            {
                // hack because of this: https://github.com/dotnet/corefx/issues/10361
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                {
                    url = url.Replace("&", "^&");
                    Process.Start(new ProcessStartInfo(url) { UseShellExecute = true });
                }
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                {
                    Process.Start("xdg-open", url);
                }
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                {
                    Process.Start("open", url);
                }
                else
                {
                    throw;
                }
            }
        }

        private void Website_Click(object sender, MouseButtonEventArgs e)
        {

        }

        private void Button_MouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
        {
            Console.WriteLine("hi");
        }
    }
}
