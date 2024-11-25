using BallGames.Common;
using System.Media;

namespace FruitNinjaWinForms
{
    public partial class MainForm : Form
    {
        System.Windows.Forms.Timer timer;
        System.Windows.Forms.Timer timerBanana;
        int bananaDuration = 7;
        bool bananaMode;
        FruitBall fruit;
        List<Ball> fruits;
        PalletsRepository palleteRepository = new PalletsRepository();
        Pallete pallete;
        int speed = 1;
        int currentSpeed;
        int currentInterval;
        int points = 0;
        Random random = new Random();


        public MainForm()
        {
            InitializeComponent();
            pallete = palleteRepository.Pallete1;
            fruits = new List<Ball>();
            bananaMode = false;

            timer = new System.Windows.Forms.Timer();
            timer.Interval = 2000;
            timer.Tick += Timer_Tick;
            timer.Start();

            timerBanana = new System.Windows.Forms.Timer();
            timerBanana.Interval = 1000;
            timerBanana.Tick += TimerBanana_Tick;
        }

        private void TimerBanana_Tick(object? sender, EventArgs e)
        {
            if (bananaDuration > 0)
            {
                bananaDuration--;
            }
            else
            {
                ExitBananaMode();
            }
        }
       
        private void ShowSpeed()
        {
            speedLabel.Text = "speed: " + (speed).ToString();
        }

        private void Timer_Tick(object? sender, EventArgs e)
        {
            var number = random.Next(1, 101);
            if (number < 75)
            {
                CreateFruit();
            }
            else if (number < 85)
            {
                CreateBanana();
            }
            else
            {
                CreateBomb();
            }

            if (timer.Interval > 500 && !bananaMode)
            {
                timer.Interval -= 50;
                speed++;
                ShowSpeed();
            }
        }

        private void CreateFruit()
        {
            fruit = new FruitBall(this, new Point(0, 0));
            fruits.Add(fruit);
            fruit.SetRandomRadius(20, 40);
            fruit.Color = BallBrushes.GetRandomFromPallete(pallete);
            fruit.Brush = new SolidBrush(fruit.Color);
            fruit.SetTimerInterval(17);
            if (bananaMode)
            {
                fruit.SetTimerInterval(100);
            }
            fruit.Start();
        }
        private void CreateBomb()
        {
            fruit = new FruitBall(this, new Point(0, 0));
            fruits.Add(fruit);
            fruit.SetRandomRadius(20, 40);
            fruit.Color = Color.Black;
            fruit.Brush = new SolidBrush(fruit.Color);
            fruit.SetTimerInterval(24);
            if (bananaMode)
            {
                fruit.SetTimerInterval(100);
            }
            fruit.Start();
        }
        private void CreateBanana()
        {
            fruit = new FruitBall(this, new Point(0, 0));
            fruits.Add(fruit);
            fruit.SetRandomRadius(20, 40);
            fruit.Color = Color.Yellow;
            fruit.Brush = new SolidBrush(fruit.Color);
            fruit.SetTimerInterval(20);
            if (bananaMode)
            {
                fruit.SetTimerInterval(100);
            }
            fruit.Start();
        }

        private void MainForm_MouseMove(object sender, MouseEventArgs e)
        {
            var itemsToRemove = new List<Ball>();
            foreach (var fruit in fruits)
            {
                if (fruit.IsPointInside(e.Location))
                {
                    if (fruit.Color == Color.Black)
                    {
                        fruit.Stop();
                        fruit.Clear();
                        this.fruits.Clear();
                        timer.Stop();
                        PlaySound(@"zvuk-vzriva-salyuta.wav");
                        Explosion(e.Location);
                        MessageBox.Show("Бомбы не вкусные!");
                        restartButton.Visible = true;
                        break;
                    }
                    else if (fruit.Color == Color.Yellow)
                    {
                        fruit.Stop();
                        fruit.Clear();
                        var bananaBurst = new BallBurst(this, fruit);
                        bananaBurst.Burst();
                        itemsToRemove.Add(fruit);
                        if (!bananaMode)
                        {
                            EnterBananaMode();
                        }
                        else
                        {
                            PlaySound(@"pop_1.wav");
                            AddPoints(fruit);
                        }
                        break;
                    }
                    else
                    {
                        PlaySound(@"pop_1.wav");
                        AddPoints(fruit);
                        fruit.Stop();
                        fruit.Clear();
                        var ballBurst = new BallBurst(this, fruit);
                        ballBurst.Burst();
                        itemsToRemove.Add(fruit);
                        break;
                    }
                }
            }
            fruits = fruits.Except(itemsToRemove).ToList();
        }

        private void EnterBananaMode()
        {
            bananaMode = true;
            PlaySound(@"banana_powerup.wav");
            currentInterval = timer.Interval;
            currentSpeed = speed;
            timerBanana.Start();
            BackColor = Color.LightYellow;
            //timer.Interval = 2000;
            speedLabel.ForeColor = Color.CadetBlue;
            speedLabel.Text = "speed: " + (speed).ToString();
            foreach (Ball fruit in fruits)
            {
                fruit.SetTimerInterval(100);
            }
        }
        private void ExitBananaMode()
        {
            bananaMode = false;
            timerBanana.Stop();
            bananaDuration = 7;
            BackColor = Color.White;
            //timer.Interval = currentInterval;
            speedLabel.ForeColor = Color.Black;
            ShowSpeed();
        }


        private void Explosion(Point point)
        {
            var random = new Random();
            var count = random.Next(15, 51);
            var pr = new PalletsRepository();
            var pallete = pr.Pallete3;
            for (int i = 0; i < count; i++)
            {
                var ball = new SalutBall(this, point);
                ball.SetRandomRadius(2, 15);
                ball.Color = BallBrushes.GetRandomFromPallete(pallete);
                ball.Brush = new SolidBrush(ball.Color);
                ball.SetTimerInterval(15);
                ball.Start();
            }
        }

        private void AddPoints(Ball ball)
        {
            int pointsByBall = 50 - ball.Radius;
            points += pointsByBall;
            pointsChangeLabel.Text = "+" + pointsByBall.ToString();
            pointsLabel.Text = points.ToString();

        }

        private void restartButton_Click(object sender, EventArgs e)
        {
            speed = 1;
            ShowSpeed();
            points = 0;
            pointsLabel.Text = points.ToString();
            pointsChangeLabel.Text = "";
            timer.Interval = 2000;
            ExitBananaMode();
            timer.Start();
            restartButton.Hide();
        }
        private void PlaySound(string path)
        {
            SoundPlayer player = new SoundPlayer(path);
            player.Play();
        }
    }
}
