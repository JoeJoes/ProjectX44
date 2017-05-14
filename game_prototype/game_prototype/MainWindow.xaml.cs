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
using System.Windows.Threading;

namespace game_prototype
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer timer = new DispatcherTimer();
        //projectile test;
        Random r = new Random();
        public List<projectile> active_projectiles = new List<projectile>();
        public List<barrier> active_barriers = new List<barrier>();
        //public List<barrier[]> collision_barriers = new List<barrier[]>();
        //public double wind;
        //public double global_gravity = 1;

        int counter = 00;

        int Player1_lifes = 100;
        int Player2_lifes = 100;

        int turn = 1;
        //bool fired = false;

        public Rectangle weapon = new Rectangle();
        double weaponAngle = 364.5;
        int ammo = 0;
        bool fired = false;

        public MainWindow()
        {
            InitializeComponent();
            timer.Interval = new TimeSpan(100);
            timer.Tick += timer_Tick;
            timer.Start();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //List<projectile> test = new List<projectile>();
            //test.Add(new projectile(1,new Point(0,0),new Vector(r.Next(5,20),r.Next(5,20))));
            //GameField.Children.Add(test.Last());
            //wind = 0;
            
            active_barriers.Add(new barrier(new Point(20, 40), Colors.Lime));
            active_barriers[0].isPlayer(1);
            //active_barriers[0].hitbox;
            //active_barriers.Last().DestroyMe += destroy_barrier;
            GameField.Children.Add(active_barriers.Last());

            active_barriers.Add(new barrier(new Point(this.ActualWidth-56, 40), Colors.Red));
            active_barriers[1].isPlayer(2);
            //active_barriers.Last().DestroyMe += destroy_barrier;
            GameField.Children.Add(active_barriers.Last());

            int gameWidth = (int)this.ActualWidth / 20;
            int g = 0;
            int i = 0;

            for (; g<8;g++)
            {
                for (int j = 0; j < 2; j++)
                {
                    active_barriers.Add(new barrier(new Point(g*20, j*20),Colors.Black));
                    active_barriers.Last().DestroyMe += destroy_barrier;
                    GameField.Children.Add(active_barriers.Last());
                }
            }
            i = g;
            do
            {
                int rnd = r.Next(2, (int)this.ActualHeight / 20 - 10);
                for (; g < i + 8; g++)
                {  
                    for (int j = 0; j < rnd; j++)
                    {
                        active_barriers.Add(new barrier(new Point(g * 20, j * 20), Colors.Black));
                        active_barriers.Last().DestroyMe += destroy_barrier;
                        GameField.Children.Add(active_barriers.Last());
                    }
                }
                i = g;
            }
            while (g < gameWidth - 8);

            i = g;
            for (; g < i+8; g++)
            {
                for (int j = 0; j < 2; j++)
                {
                    active_barriers.Add(new barrier(new Point(g * 20, j * 20), Colors.Black));
                    active_barriers.Last().DestroyMe += destroy_barrier;
                    GameField.Children.Add(active_barriers.Last());
                }
            }
            //active_barriers[0].hitbox.Fill = Brushes.Yellow;

            //barrier Player1 = new barrier(new Point(20, 40), Colors.Lime);
            //Player1.DestroyMe += destroy_barrier;
            //GameField.Children.Add(Player1);

            //GameField.Children.Add(block);3


            //r1.int

            GameField.Focus();
            GameField.Children.Add(weapon);
            drawWeapon(turn > 0 ? (new Point(active_barriers[0]._loc.X + active_barriers[0].Width / 2, active_barriers[0]._loc.Y + active_barriers[0].Height / 2)) : 
                                  (new Point(active_barriers[1]._loc.X + active_barriers[1].Width / 2, active_barriers[1]._loc.Y + active_barriers[1].Height / 2)), 
                       weaponAngle = turn > 0 ? 360 : 180);
        }
        
        void timer_Tick(object sender, EventArgs e)
        {
            if ((AI1_check.IsChecked == true && turn > 0) && !fired)
            {
                active_projectiles.Add(new projectile(0, new Point(active_barriers[0]._loc.X + 5, 65), new Vector((float)Math.Cos(Math.PI * r.Next(315, 359) / 180.0) * 5, -(float)Math.Sin(Math.PI * r.Next(315, 359) / 180.0) * 5)));
                active_projectiles.Last().DestroyMe += destroy_projectile;
                GameField.Children.Add(active_projectiles.Last());
                fired = true;
            }
            if ((AI2_check.IsChecked == true && turn < 0) && !fired)
            {
                active_projectiles.Add(new projectile(0, new Point(active_barriers[1]._loc.X - 5, 65), new Vector((float)Math.Cos(Math.PI * r.Next(182, 226) / 180.0) * 5, -(float)Math.Sin(Math.PI * r.Next(182, 226) / 180.0) * 5)));
                active_projectiles.Last().DestroyMe += destroy_projectile;
                GameField.Children.Add(active_projectiles.Last());
                fired = true;
            }

            //List<projectile> test = new List<projectile>();
            /*if (counter == 50)
            {
                active_projectiles.Add(new projectile(0, new Point(active_barriers[1]._loc.X-5, 65), new Vector(-r.Next(10, 15) * 0.3, r.Next(10, 15) * 0.3)));
                active_projectiles.Last().DestroyMe += destroy_projectile;
                GameField.Children.Add(active_projectiles.Last());
                //counter = 0;
            }
            if (counter >= 100)
            {
                active_projectiles.Add(new projectile(0, new Point(active_barriers[0]._loc.X + 5, 65), new Vector(r.Next(10, 15)*0.3, r.Next(10, 15)*0.3)));
                active_projectiles.Last().DestroyMe += destroy_projectile;
                GameField.Children.Add(active_projectiles.Last());
                counter = 0;
            }
            else counter++;*/

            //active_projectiles[1]
            //active_barriers[1]._loc



            foreach (projectile p in active_projectiles.Reverse<projectile>()) 
            {
                //(new Rect(b._loc, new Size(b.ActualWidth, b.ActualHeight))).IntersectsWith((new Rect(b._loc, new Size(b.ActualWidth, b.ActualHeight))));
                //var collisions = active_barriers.Where(b => Rect.Intersect(new Rect(p._loc, new Size(p.ActualWidth,p.ActualHeight)), new Rect(b._loc,new Size(b.ActualWidth,b.ActualHeight))) != null).Select(b => active_barriers[active_barriers.IndexOf(b)]);
                
                var collisions = active_barriers.Where(b => (new Rect(b._loc, new Size(b.ActualWidth, b.ActualHeight))).IntersectsWith(new Rect(p._loc, new Size(p.ActualWidth, p.ActualHeight)))).Select(b => active_barriers[active_barriers.IndexOf(b)]);
                if(collisions.Count()!=0)
                {
                    int explosion_radius = 70;
                    if (p._type == 0)
                    {
                        var explosion = active_barriers.Where(b => (new Vector((b._loc.X + (b.Height / 2)) - (p._loc.X + (p.Width / 2)), (b._loc.Y + (b.Height / 2)) - (p._loc.Y + (p.Height / 2)))).Length <= explosion_radius).Select(b => active_barriers[active_barriers.IndexOf(b)]);


                        foreach (barrier destroy in explosion.Reverse<barrier>())
                        {
                            switch (destroy._isPlayer)
                            {
                                case 1:
                                    Player1_lifes -= 20;
                                    break;
                                case 2:
                                    Player2_lifes -= 20;
                                    break;
                                case 0:
                                    destroy_barrier(destroy);
                                    break;
                            }
                        }
                    }
                    else
                    {
                        foreach (barrier destroy in collisions.Reverse<barrier>())
                            {
                            
                            switch(destroy._isPlayer)
                                {
                                case 1:
                                    Player1_lifes -= 10;
                                    break;
                                case 2:
                                    Player2_lifes -= 10;
                                    break;
                                case 0:
                                    destroy_barrier(destroy);
                                    break;
                                }
                                
                                     
                                
                            //else destroy_barrier(destroy);
                            }
                    }
                    

                    destroy_projectile(p);
                    //collision_barriers.Add(new barrier[] );

                    Player2_life.Value = Player2_lifes;
                    Player2_lifeNum.Text = Player2_lifes.ToString();

                    Player1_life.Value = Player1_lifes;
                    Player1_lifeNum.Text = Player1_lifes.ToString();

                    if(Player1_lifes <= 0)
                    {
                        MessageBoxResult newGame = MessageBox.Show(this, "Hráč 2 vyhrál.", "Konec hry", MessageBoxButton.YesNo, MessageBoxImage.Asterisk);
                        if (newGame == MessageBoxResult.Yes) {
                            System.Diagnostics.Process.Start(Application.ResourceAssembly.Location);
                            Application.Current.Shutdown();
                        }//new game
                        if (newGame == MessageBoxResult.No) Environment.Exit(1);
                    }
                    if (Player2_lifes <= 0)
                    {
                        MessageBoxResult newGame = MessageBox.Show(this, "Hráč 1 vyhrál.", "Konec hry", MessageBoxButton.YesNo, MessageBoxImage.Asterisk);
                        if (newGame == MessageBoxResult.Yes)
                        {
                            System.Diagnostics.Process.Start(Application.ResourceAssembly.Location);
                            Application.Current.Shutdown();
                        }//new game
                        if (newGame == MessageBoxResult.No) Environment.Exit(1);
                    }
                }
            }

            rotateWeapon(weaponAngle);

            //active_barriers[1]

            if (active_projectiles.Count < 1 && fired)
            {
                turn = turn > 0 ? -turn : -turn + 1;
                drawWeapon(turn > 0 ? (new Point(active_barriers[0]._loc.X + active_barriers[0].ActualWidth / 2, active_barriers[0]._loc.Y + active_barriers[0].ActualHeight / 2)) : (new Point(active_barriers[1]._loc.X + active_barriers[1].ActualWidth / 2, active_barriers[1]._loc.Y + active_barriers[0].ActualHeight / 2)), weaponAngle = turn > 0 ? 360 : 180);
                fired = false;
            }
            
            //var collisions = active_projectiles.Where(p => p = Rect.Intersect(new Rect(new Point(0,0),new Point(1,1)),new Rect());
        }
        
        void destroy_projectile(object sender)
        {
            active_projectiles[active_projectiles.IndexOf((projectile)sender)].DestroyMe -= destroy_projectile;
            //active_projectiles[active_projectiles.IndexOf((projectile)sender)].
            GameField.Children.Remove(active_projectiles[active_projectiles.IndexOf((projectile)sender)]);
            active_projectiles.Remove((projectile)sender);
        }

        void destroy_barrier(object sender)
        {
            active_barriers[active_barriers.IndexOf((barrier)sender)].DestroyMe -= destroy_barrier;
            GameField.Children.Remove(active_barriers[active_barriers.IndexOf((barrier)sender)]);
            active_barriers.Remove((barrier)sender);
        }

        private void GameField_KeyDown(object sender, KeyEventArgs e)
        {
            int altStr = 0;
            //if ((AI1_check.IsChecked == true && turn > 0) || (AI2_check.IsChecked == true && turn < 0)) return;
            switch(e.Key)
            {
                case Key.Up:
                    if (fired) break;
                    if ((AI1_check.IsChecked == true && turn > 0) || (AI2_check.IsChecked == true && turn < 0)) break;
                    label.Content = "up " + turn + " " + weaponAngle;
                    weaponAngle += turn > 0 ? weaponAngle <= 180 ? 0 : -0.5 : weaponAngle >= 360 ? 0 : 0.5;
                    break;
                case Key.Down:
                    if (fired) break;
                    if ((AI1_check.IsChecked == true && turn > 0) || (AI2_check.IsChecked == true && turn < 0)) break;
                    label.Content = "down " + turn + " " + weaponAngle;
                    weaponAngle += turn > 0 ? weaponAngle >= 360 ? 0 : 0.5 : weaponAngle <= 180 ? 0 : -0.5;
                    break;
                case Key.Space:
                    if (fired) break;
                    if ((AI1_check.IsChecked == true && turn > 0) || (AI2_check.IsChecked == true && turn < 0)) break;
                    label.Content = "fire " + turn;
                    //Vector fireArc;

                    if(ammo == 0)
                    {
                        
                    }
                    //switch (ammo)
                    //{
                    //    case 0:
                    //        fireArc = 
                    //        break;
                    //    case 1:

                    //        break;
                    //}
                    
                    active_projectiles.Add(new projectile(ammo, new Point(active_barriers[turn > 0 ? 0 : 1]._loc.X + (turn > 0 ? active_barriers[turn > 0 ? 0 : 1].Width + 5 : -5 - 10), active_barriers[turn > 0 ? 0 : 1]._loc.Y + 5), new Vector((float)Math.Cos(Math.PI * weaponAngle / 180.0) * 5, -(float)Math.Sin(Math.PI * weaponAngle / 180.0) * 5)));
                    active_projectiles.Last().DestroyMe += destroy_projectile;
                    GameField.Children.Add(active_projectiles.Last());
                    fired = true;
                    break;
                case Key.NumPad1:
                    if (fired) break;
                    if ((AI1_check.IsChecked == true && turn > 0) || (AI2_check.IsChecked == true && turn < 0)) break;
                    label.Content = "ammo1 " + turn;
                    ammo = 0;
                    break;
                case Key.NumPad2:
                    if (fired) break;
                    if ((AI1_check.IsChecked == true && turn > 0) || (AI2_check.IsChecked == true && turn < 0)) break;
                    label.Content = "ammo2 " + turn;
                    ammo = 1;
                    break;
                case Key.Escape:
                    Environment.Exit(1);
                    break;
            }
        }

        public void drawWeapon(Point loc, double angle)
        {
            weapon.Width = 20;
            weapon.Height = 4;

            weapon.Fill = Brushes.Black;

            Canvas.SetBottom(weapon, loc.Y-2);
            Canvas.SetLeft(weapon, loc.X);

            weapon.RenderTransformOrigin = new Point(0, 0.5);
            RotateTransform rotation = new RotateTransform();
            rotation.Angle = angle;
            weapon.RenderTransform = rotation;
        }

        public void rotateWeapon(double angle)
        {
            weapon.RenderTransformOrigin = new Point(0, 0.5);
            RotateTransform rotation = new RotateTransform();
            rotation.Angle = angle;
            weapon.RenderTransform = rotation;
        }

        int strenght()
        {
            int _strenght = 0;


            
            return _strenght;
        }

        private void AI1_check_Click(object sender, RoutedEventArgs e)
        {
            Keyboard.ClearFocus();
        }

        private void AI2_check_Click(object sender, RoutedEventArgs e)
        {
            Keyboard.ClearFocus();
        }
    }

    public class projectile : Canvas
    {
        private double[][] projectile_types = { new double[] { 10, 10, 0.5, 1, 50 },
                                                new double[] { 5, 5, 1, 0.5, 10 } };
        //lenght, width, speed multiplier, gravity multiplier, force 
        private double _gravity = 0.005;

        public int _type { get; private set; }
        private Vector _velocity;
        //public Point _loc { get { return _loc; } private set { _loc = value; } }
        public Point _loc { get; private set; }
        private Rectangle hitbox;

        private DispatcherTimer updater = new DispatcherTimer();

        public delegate void selfDestroyer(object sender);
        public event selfDestroyer DestroyMe;

        /// <summary>
        /// Create new projectile on default coordinates (0,0). Obsolete.
        /// </summary>
        /// <param name="type">Type of projectile</param>
        public projectile(int type)
        {
            _type = type;
            this.Height = projectile_types[type][0];
            this.Width = projectile_types[type][1];

            this.HorizontalAlignment = HorizontalAlignment.Left;
            this.VerticalAlignment = VerticalAlignment.Bottom;

            hitbox = new Rectangle();

            hitbox.Fill = Brushes.Black;
            hitbox.Height = this.Height;
            hitbox.Width = this.Width;
            hitbox.Margin = new Thickness(0, 0, 0, 0);

            this.Children.Add(hitbox);

            _loc = new Point(0, 0);

            Canvas.SetBottom(this, -this.Height / 2);
            Canvas.SetLeft(this, -this.Width / 2);

            start_updater();
        }

        /// <summary>
        /// Create new projectile on set coordinates. Obsolete.
        /// </summary>
        /// <param name="type">Type of projectile</param>
        /// <param name="locX">X coordinate</param>
        /// <param name="locY">Y coordinate</param>
        public projectile(int type, Point loc)
        {
            _type = type;
            this.Height = projectile_types[type][0];
            this.Width = projectile_types[type][1];

            this.HorizontalAlignment = HorizontalAlignment.Left;
            this.VerticalAlignment = VerticalAlignment.Bottom;

            hitbox = new Rectangle();

            hitbox.Fill = Brushes.Black;
            hitbox.Height = this.Height;
            hitbox.Width = this.Width;
            hitbox.Margin = new Thickness(0, 0, 0, 0);

            this.Children.Add(hitbox);

            _loc = loc;

            Canvas.SetBottom(this, _loc.Y-this.Height / 2);
            Canvas.SetLeft(this, _loc.X-this.Width / 2);

            start_updater();
        }

        /// <summary>
        /// Create new projectile with starting point and velocity specified
        /// </summary>
        /// <param name="type">Type of projectile</param>
        /// <param name="loc">Point of origin</param>
        /// <param name="velocity">Projectile velocity</param>
        public projectile(int type, Point loc, Vector velocity)
        {
            _type = type;
            _velocity = velocity;
            this.Height = projectile_types[type][0];
            this.Width = projectile_types[type][1];

            this.HorizontalAlignment = HorizontalAlignment.Left;
            this.VerticalAlignment = VerticalAlignment.Bottom;

            hitbox = new Rectangle();

            hitbox.Fill = Brushes.Black;
            hitbox.Height = this.Height;
            hitbox.Width = this.Width;
            hitbox.Margin = new Thickness(0, 0, 0, 0);

            this.Children.Add(hitbox);

            _loc = loc;

            Canvas.SetBottom(this, _loc.Y - this.Height / 2);
            Canvas.SetLeft(this, _loc.X - this.Width / 2);

            start_updater();
        }

        protected virtual void OnDestroyMe(object sender)
        {
            selfDestroyer destroyer = DestroyMe;
            if (destroyer != null)
            {
                destroyer(this);
                updater.Stop();
            }
        }

        private void start_updater()
        {
            updater.Interval = new TimeSpan(100);
            updater.Tick += updater_Tick;
            updater.Start();
        }

        private void gravity()
        {
            if (this._velocity == null) return;

            //this._loc.X += _velocity.X * projectile_types[this._type][2];
            //this._loc.Y += _velocity.Y;
            this._loc = new Point(this._loc.X + _velocity.X * projectile_types[this._type][2], this._loc.Y + _velocity.Y);

            //_loc = new Point(_velocity.X * projectile_types[this._type][2], _velocity.Y);

            Canvas.SetLeft(this, this._loc.X);
            Canvas.SetBottom(this, this._loc.Y);

            rotate();

            _velocity = Vector.Add(_velocity, new Vector(0, -_gravity * projectile_types[this._type][3])); 
        }

        private void rotate()
        {
            this.RenderTransformOrigin = new Point(0.5, 0.5);
            RotateTransform rotation = new RotateTransform();
            rotation.Angle = -Vector.AngleBetween(new Vector(1, 0), _velocity);
            this.RenderTransform = rotation;
        }

        private void updater_Tick(object sender, EventArgs e)
        {
            gravity();

            //if (this._locX > (this.Parent as Control).Width) destroyMe(this);

            try
            {
                if (this._loc.X > (this.Parent as FrameworkElement).ActualWidth) OnDestroyMe(this);
                if (this._loc.Y < -30) OnDestroyMe(this);
            }
            catch(Exception exc)
            {
                this.updater.Stop();
            }



            //VisualTreeHelper.
        }
    }

    public class barrier : Canvas
    {
        public delegate void selfDestroyer(object sender);
        public event selfDestroyer DestroyMe;

        //public Point _loc { get { return _loc; } private set { _loc = value; } }
        public Point _loc { get; private set; }
        private Color _color;
        public Rectangle hitbox;
        public int _isPlayer { get; private set; }

        /// <summary>
        /// Create new barrier on specified coordinates. Size of barrier is 20x20.
        /// </summary>
        /// <param name="loc">Location of barier</param>
        /// <param name="color">Color of barrier</param>
        public barrier(Point loc, Color color)
        {
            this.Height = 20;
            this.Width = 20;
            this._color = color;

            this.HorizontalAlignment = HorizontalAlignment.Left;
            this.VerticalAlignment = VerticalAlignment.Bottom;

            hitbox = new Rectangle();

            hitbox.Fill = new SolidColorBrush(_color);
            hitbox.Height = this.Height;
            hitbox.Width = this.Width;
            hitbox.Margin = new Thickness(0, 0, 0, 0);

            //hitbox.Stroke = Brushes.Yellow;

            this.Children.Add(hitbox);

            _loc = loc;

            Canvas.SetBottom(this, _loc.Y);
            Canvas.SetLeft(this, _loc.X);
        }

        protected virtual void OnDestroyMe(object sender)
        {
            selfDestroyer destroyer = DestroyMe;
            if (destroyer != null)
            {
                destroyer(this);
                //updater.Stop();
            }
        }

        public void isPlayer(int player)
        {
            this._isPlayer = player;
        }
    }

    
}
