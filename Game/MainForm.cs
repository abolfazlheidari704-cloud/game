using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Game
{
    public partial class MainForm : Form
    {
        private const int BoardSize = 8;
        private const int InitialLives = 3;
        private readonly Random random = new Random();
        private readonly PictureBox[,] cells = new PictureBox[BoardSize, BoardSize];

        private Point player;
        private Point goal;
        private Point bomb;
        private int score;
        private int lives;
        private bool isGameOver;

        private Image playerImage;
        private Image goalImage;
        private Image bombImage;
        private Image wallImage;

        public MainForm()
        {
            InitializeComponent();
            LoadImages();
            CreateBoard();
            ResetGame();
        }

        private void LoadImages()
        {
            var assetsRoot = FindAssetsRoot();
            playerImage = Image.FromFile(Path.Combine(assetsRoot, "child.png"));
            goalImage = Image.FromFile(Path.Combine(assetsRoot, "next.png"));
            bombImage = Image.FromFile(Path.Combine(assetsRoot, "bomb.png"));
            wallImage = Image.FromFile(Path.Combine(assetsRoot, "stone.jpg"));
        }

        private string FindAssetsRoot()
        {
            var current = AppDomain.CurrentDomain.BaseDirectory;
            for (var i = 0; i < 6; i++)
            {
                if (File.Exists(Path.Combine(current, "child.png")))
                {
                    return current;
                }

                current = Path.GetFullPath(Path.Combine(current, ".."));
            }

            throw new FileNotFoundException("تصاویر بازی پیدا نشدند.");
        }

        private void CreateBoard()
        {
            boardPanel.Controls.Clear();
            var cellSize = boardPanel.Width / BoardSize;

            for (var y = 0; y < BoardSize; y++)
            {
                for (var x = 0; x < BoardSize; x++)
                {
                    var box = new PictureBox
                    {
                        Width = cellSize,
                        Height = cellSize,
                        Left = x * cellSize,
                        Top = y * cellSize,
                        BorderStyle = BorderStyle.FixedSingle,
                        BackColor = Color.FromArgb(219, 234, 254),
                        SizeMode = PictureBoxSizeMode.StretchImage,
                    };

                    boardPanel.Controls.Add(box);
                    cells[x, y] = box;
                }
            }
        }

        private void ResetGame()
        {
            player = new Point(1, 1);
            score = 0;
            lives = InitialLives;
            isGameOver = false;

            goal = SpawnFreeCell(new List<Point> { player });
            bomb = SpawnFreeCell(new List<Point> { player, goal });

            messageLabel.Text = "برای شروع یکی از کلیدهای جهت‌دار را بزن.";
            Render();
        }

        private Point SpawnFreeCell(ICollection<Point> occupied)
        {
            Point candidate;
            do
            {
                candidate = new Point(random.Next(0, BoardSize), random.Next(0, BoardSize));
            }
            while (IsWall(candidate) || occupied.Contains(candidate));

            return candidate;
        }

        private bool IsWall(Point p)
        {
            return p.X == 0
                   || p.Y == 0
                   || p.X == BoardSize - 1
                   || p.Y == BoardSize - 1
                   || (p.X == 3 && p.Y > 1 && p.Y < 6)
                   || (p.Y == 5 && p.X > 3 && p.X < 7);
        }

        private void Render()
        {
            scoreLabel.Text = $"امتیاز: {score}";
            livesLabel.Text = $"جان: {lives}";

            for (var y = 0; y < BoardSize; y++)
            {
                for (var x = 0; x < BoardSize; x++)
                {
                    var cellPoint = new Point(x, y);
                    var cell = cells[x, y];
                    cell.Image = null;

                    if (IsWall(cellPoint))
                    {
                        cell.Image = wallImage;
                    }

                    if (cellPoint == goal)
                    {
                        cell.Image = goalImage;
                    }

                    if (cellPoint == bomb)
                    {
                        cell.Image = bombImage;
                    }

                    if (cellPoint == player)
                    {
                        cell.Image = playerImage;
                    }
                }
            }
        }

        private void MovePlayer(int dx, int dy)
        {
            if (isGameOver)
            {
                return;
            }

            var next = new Point(player.X + dx, player.Y + dy);
            if (IsWall(next))
            {
                messageLabel.Text = "این مسیر بسته است.";
                return;
            }

            player = next;

            if (player == goal)
            {
                score++;
                messageLabel.Text = "آفرین! یک ستاره گرفتی ⭐";
                goal = SpawnFreeCell(new List<Point> { player, bomb });
            }

            if (player == bomb)
            {
                lives--;
                if (lives <= 0)
                {
                    isGameOver = true;
                    messageLabel.Text = "بازی تمام شد! روی شروع دوباره بزن.";
                }
                else
                {
                    messageLabel.Text = "اوه! به بمب خوردی 💣";
                    player = new Point(1, 1);
                    bomb = SpawnFreeCell(new List<Point> { player, goal });
                }
            }

            if (!isGameOver && score >= 5)
            {
                isGameOver = true;
                messageLabel.Text = "تبریک! مرحله مبتدی را کامل کردی 🎉";
            }

            Render();
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                MovePlayer(0, -1);
            }
            else if (e.KeyCode == Keys.Down)
            {
                MovePlayer(0, 1);
            }
            else if (e.KeyCode == Keys.Left)
            {
                MovePlayer(-1, 0);
            }
            else if (e.KeyCode == Keys.Right)
            {
                MovePlayer(1, 0);
            }
        }

        private void RestartButton_Click(object sender, EventArgs e)
        {
            ResetGame();
        }
    }
}
